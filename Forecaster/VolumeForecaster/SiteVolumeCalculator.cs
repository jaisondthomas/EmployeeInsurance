using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Entities;
using Forecaster.Entities;
using Forecaster.Interfaces;

namespace Forecaster.VolumeForecaster
{
    public class SiteVolumeCalculator : ISiteVolumeCalculator
    {
        public static bool IsContractHasBothStartDateAndEndDate(
            ContractAmendment contract)
        {
            return !string.IsNullOrEmpty(
                       contract.StartDate.ToLongDateString()) &&
                   contract.EndDate.HasValue;
        }

        public static bool IsContractEndDateAfterStartDate(ContractAmendment contract)
        {
            return contract.StartDate < contract.EndDate;
        }


        public static void NoProductAvailableForContract(ContractAmendment contract,
            IEnumerable<ContractProduct> products)
        {
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            if (products.All(product => product.ContractAmendmentId != contract.Id))
            {
                throw new Exception("No product available for the contract");
            }
        }

        public static void NoSiteAvailableForProduct(
            IEnumerable<ContractProduct> products,
            IEnumerable<ContractProductSite> productSites)
        {
           var any = (from product in products
                from site in productSites
                where product.Id == site.ContractProductId
                select product).Any();

            if (!any)
            {
                throw new Exception("No site available for the product");
            }
        }

        public static bool IsVolumeAvailableForContractProductSite(
            IEnumerable<ContractProductSite> productSites,
            IEnumerable<SiteVolume> siteVolumes)
        {
            return (from productSite in productSites
                from siteVolume in siteVolumes
                where productSite.SiteId == siteVolume.SiteId
                select productSite).Any();
        }


        public static List<Tuple<int, int>>
            BillingMonths(
                IEnumerable<SiteVolume> siteVolumes)
        {
            return (from siteVolume in siteVolumes
                let month = siteVolume.BillingMonth.Month
                let year = siteVolume.BillingMonth.Year
                select new Tuple<int, int>(month, year)).ToList();
        }


        public static List<Tuple<int, int>>
            ExpectedBillingMonthsForTheContract(ContractAmendment contract)
        {
            var startDate = contract.StartDate;
            var endDate = contract.EndDate;
            var monthsForTheYear = new List<Tuple<int, int>>();

            while (startDate <= endDate)
            {
                var month = startDate.Month;
                var year = startDate.Year;
                startDate = startDate.AddMonths(1);
                monthsForTheYear.Add(new Tuple<int, int>(month, year));
            }
            return monthsForTheYear;
        }

        public static int MissingBillingMonths(
            List<Tuple<int, int>> expectedBillingMonths,
            List<Tuple<int, int>> actualBillingMonths)
        {
            var totalNumberOfMissingBillingMonths = expectedBillingMonths
                .Concat(actualBillingMonths)
                .Except(expectedBillingMonths.Intersect(actualBillingMonths))
                .Count();
            return totalNumberOfMissingBillingMonths;
        }

        public static bool IsAllVolumesExistForTheContract(
            int totalNumberOfMissingBillingMonths)
        {
            return totalNumberOfMissingBillingMonths <= 0;
        }

        public static List<SiteVolume> SiteVolumesForContract(
            ContractAmendment contract,
            List<SiteVolume> siteVolumes)
        {
            return siteVolumes
                .Where(x => x.BillingMonth >= contract.StartDate &&
                            x.BillingMonth <= contract.EndDate).ToList();
        }

        public static IEnumerable<SiteVolume> GroupedSiteVolumes(
            IEnumerable<SiteVolume> allSiteVolumesForTheContract)
        {
            var groupedResult = allSiteVolumesForTheContract
                .GroupBy(x => new {x.SiteId, x.BillingMonth})
                .Select(g => new SiteVolume
                {
                    SiteId = g.Key.SiteId,
                    BillingMonth = g.Key.BillingMonth,
                    Volume = g.Sum(x => x.Volume)
                }).ToList();

            return groupedResult;
        }

        public static decimal TotalSiteVolume(
            IEnumerable<SiteVolume> groupedSiteVolumes)
        {
            return groupedSiteVolumes.Sum(x => x.Volume);
        }

        public static bool IsNoVolumeContract(
            IEnumerable<SiteVolume> allSiteVolumesForTheContract)
        {
            return !allSiteVolumesForTheContract.Any();
        }

        public static ContractAmendment
            PreviousContractForClient(
                ContractAmendment currentContract,
                IEnumerable<ContractAmendment> contracts)
        {
            return contracts.FirstOrDefault(
                x => x.ClientId == currentContract.ClientId &&
                     x.EndDate < currentContract.StartDate &&
                     !x.Id.Equals(currentContract.Id));
        }

        public static IEnumerable<ContractProduct> ContractProducts(
            ContractAmendment previousContract,
            List<ContractProduct> contractProducts)
        {
            return contractProducts.Where(
                x => x.ContractAmendmentId == previousContract.Id);
        }

        public static IEnumerable<ContractProductSite> ProductSites(
            IEnumerable<ContractProduct> contractProducts,
            List<ContractProductSite> contractProductSites)
        {
            return (from product in contractProducts
                from site in contractProductSites
                where product.Id == site.ContractProductId
                select site).ToList();
        }

        public static IEnumerable<SiteVolume> SiteVolumes(
            IEnumerable<ContractProductSite> productSites,
            List<SiteVolume> siteVolumes)
        {
            return productSites.SelectMany(contractSite => siteVolumes)
                .ToList();
        }


        public static bool IsContractHasSomeVolume(
            ContractAmendment currentContract,
            List<SiteVolume> siteVolumes)
        {
            return SiteVolumesForContract(currentContract, siteVolumes).Any();
        }

        public static List<SiteVolume> CurrentContractVolumes(
            ContractAmendment currentContract, List<SiteVolume> siteVolumes)
        {
            return siteVolumes
                .Where(x => x.BillingMonth >= currentContract.StartDate).ToList();
        }

       
        public static List<SiteVolume>
            VolumesExcludedCurrentContractBillingMonths(
                List<Tuple<int, int>> currentContractBillingMonths,
                IEnumerable<SiteVolume> previousContractVolumes)
        {
            var currentContractMonths =
                currentContractBillingMonths
                    .Select(
                        currentContractBillingMonth => new Tuple<int>(
                            currentContractBillingMonth.Item1)).ToList();


            var contractVolumes =
                previousContractVolumes as IList<SiteVolume> ??
                previousContractVolumes.ToList();

            var previousContractBillingMonths =
                contractVolumes
                    .Select(previousContractVolume => new Tuple<int>(
                        previousContractVolume.BillingMonth.Month)).ToList();

            //Ignore current contract already billed months ,
            //for previous contract, calculate total contracted volume for rest of the month 
            var includedVolumesForPreviousContract = previousContractBillingMonths
                .Concat(currentContractMonths)
                .Except(
                    previousContractBillingMonths.Intersect(
                        currentContractMonths));


            return (from previousContractVolume in contractVolumes
                from includeVolumeForTheMonth in includedVolumesForPreviousContract
                where previousContractVolume.BillingMonth.Month ==
                      includeVolumeForTheMonth.Item1
                select previousContractVolume).ToList();
        }

        public static bool IsContractHasStartDate(ContractAmendment contract)
        {
            return !string.IsNullOrEmpty(
                contract.StartDate.ToString(CultureInfo.InvariantCulture));
        }

        public decimal TotalContractedVolume(
            ContractAmendment contract, List<ContractAmendment> contracts,
            List<ContractProduct> contractProducts,
            List<ContractProductSite> contractProductSites,
            List<SiteVolume> siteVolumes)
        {
            decimal total = 0;

            NoProductAvailableForContract(contract, contractProducts);
            NoSiteAvailableForProduct(contractProducts, contractProductSites);


            if (!IsVolumeAvailableForContractProductSite(contractProductSites,
                siteVolumes))
                return total;

            var siteVolumesForTheContract =
                SiteVolumesForContract(contract,
                    siteVolumes);

            var expectedBillingMonths =
                ExpectedBillingMonthsForTheContract(contract);

            var actualBillingMonths =
                BillingMonths(siteVolumes);

            var missingBillingMonths =
                MissingBillingMonths(
                    expectedBillingMonths, actualBillingMonths);

            if (IsContractHasBothStartDateAndEndDate(contract) &&
                IsContractEndDateAfterStartDate(contract))
            {
                if (IsAllVolumesExistForTheContract(
                    missingBillingMonths))
                {
                    var groupedSiteVolumes =
                        GroupedSiteVolumes(siteVolumesForTheContract);

                    total =
                        TotalSiteVolume(groupedSiteVolumes);
                }
                else if (IsNoVolumeContract(siteVolumesForTheContract))
                {
                    var previousContract =
                        PreviousContractForClient(contract, contracts);

                    var previousProducts =
                        ContractProducts(previousContract,
                            contractProducts);

                    var previousProductSites =
                        ProductSites(previousProducts,
                            contractProductSites);

                    var previousSiteVolumes =
                        SiteVolumes(previousProductSites,
                            siteVolumes);

                    var groupedPerviousSiteVolumes =
                        GroupedSiteVolumes(previousSiteVolumes);

                    total = TotalSiteVolume(groupedPerviousSiteVolumes);
                }
            }

            var contractHasSomeVolume =
                IsContractHasSomeVolume(contract, siteVolumes) &&
                IsContractHasStartDate(contract) &&
                !IsAllVolumesExistForTheContract(missingBillingMonths) &&
                !IsNoVolumeContract(siteVolumesForTheContract);

            if (!contractHasSomeVolume) return total;
            {
                //calculate total contracted volume for the current contract
                var currentContractVolumes =
                    CurrentContractVolumes(contract, siteVolumes);

                var groupedCurrentContractVolume =
                    GroupedSiteVolumes(currentContractVolumes);

                var totalVolumeForCurrentContract =
                    TotalSiteVolume(groupedCurrentContractVolume);


                //calculate total contracted volume for the previous contract
                var previousContractForTheClient =
                    PreviousContractForClient(contract,
                        contracts);

                var volumesForPreviousContract = SiteVolumesForContract(
                    previousContractForTheClient,
                    siteVolumes);

                var currentContractBillingMonths =
                    BillingMonths(
                        currentContractVolumes);


                var volumesExcludedCurrentBillingMonths =
                    VolumesExcludedCurrentContractBillingMonths(
                        currentContractBillingMonths, volumesForPreviousContract);


                var groupedPreviousContractVolumes =
                    GroupedSiteVolumes(volumesExcludedCurrentBillingMonths);

                var totalVolumePreviousContract =
                    TotalSiteVolume(
                        groupedPreviousContractVolumes);

                //sum up both current contract volume and previous contract volume totals
                total = totalVolumeForCurrentContract + totalVolumePreviousContract;
            }

            return total;
        }


      
    }
}