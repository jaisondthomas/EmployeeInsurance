using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Forecaster.Entities;
using Forecaster.Test;
using Forecaster.VolumeForecaster;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForecasterTest
{
    [TestClass]
    public class SiteVolumeCalculatorTest
    {
      
        [TestMethod]
        public void IsContractHasBothStartDateAndEndDate()
        {
            var contract = ContractReaderStub.Contract();

            var actualResult =
                SiteVolumeCalculator.IsContractHasBothStartDateAndEndDate(contract);

            Assert.AreEqual(true, actualResult);
        }


        [TestMethod]
        public void IsContractEndDateAfterStartDate()
        {
            var contract = ContractReaderStub.Contract();

            var actualResult =
                SiteVolumeCalculator.IsContractEndDateAfterStartDate(contract);

            Assert.AreEqual(true, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No product available for the contract")]
        public void NoProductAvailableForTheContract()
        {
            var contract = ContractReaderStub.Contract();
            var products = ContractProductReaderStub.NoProducts();

           SiteVolumeCalculator.NoProductAvailableForContract(contract, products);
            
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullContractForTheProducts()
        {
            
            var products = ContractProductReaderStub.NoProducts();

            SiteVolumeCalculator.NoProductAvailableForContract(null, products);

        }

      
        [TestMethod]
        [ExpectedException(typeof(Exception), "No site available for the product")]
        public void NoSiteAvailableForProduct()
        {
            var products = ContractProductReaderStub.Products();
            var sites = ContractProductSiteReaderStub.NoSites();

         
           SiteVolumeCalculator.NoSiteAvailableForProduct(products,
                    sites);


         
        }


        [TestMethod]
        public void IsVolumeAvailableForContractProductSite()
        {
            var sites = ContractProductSiteReaderStub.Sites();
            var volumes = ContractProductSiteVolumeReaderStub.AllVolumes();
            var actualResult =
                SiteVolumeCalculator.IsVolumeAvailableForContractProductSite(sites,
                    volumes);


            Assert.AreEqual(true, actualResult);
        }

        [TestMethod]
        public void SiteVolumesForTheContract()
        {
            var contract = ContractReaderStub.Contract();
            var volumes = ContractProductSiteVolumeReaderStub.AllVolumes();
            
            var actualResult =
                SiteVolumeCalculator.SiteVolumesForContract(contract,
                    volumes);

            Assert.AreEqual(200, actualResult.ElementAt(0).Volume);
            Assert.AreEqual(100, actualResult.ElementAt(1).Volume);
        }


        [TestMethod]
        public void CurrentContractBillingMonths()
        {

            var contract = ContractReaderStub.Contract();
            var volumes = ContractProductSiteVolumeReaderStub.SomeVolumes();
            var siteVolumes =
                SiteVolumeCalculator.SiteVolumesForContract(contract,
                    volumes);

            var billingMonths =
                SiteVolumeCalculator.BillingMonths(
                        siteVolumes);


            Assert.AreEqual(1, billingMonths[0].Item1);
            Assert.AreEqual(2016, billingMonths[0].Item2);

           
        }

        [TestMethod]
        public void ExpectedBillingMonthsForTheContract()
        {
            var contract = ContractReaderStub.Contract();

            var expectedBillingMonths =
                SiteVolumeCalculator.ExpectedBillingMonthsForTheContract(contract);

            Assert.AreEqual(1, expectedBillingMonths[0].Item1);
            Assert.AreEqual(2016, expectedBillingMonths[0].Item2);
            Assert.AreEqual(2, expectedBillingMonths[1].Item1);
            Assert.AreEqual(2016, expectedBillingMonths[1].Item2);
            
        }


        [TestMethod]
        public void MissingBillingMonths()
        {
            var contract = ContractReaderStub.Contract();
            var volumes = ContractProductSiteVolumeReaderStub.NoVolumes();

            var expectedBillingMonths =
                SiteVolumeCalculator.ExpectedBillingMonthsForTheContract(contract);
            var actualBillingMonths = SiteVolumeCalculator.BillingMonths(volumes);

            var missingBillingMonths =
                SiteVolumeCalculator.MissingBillingMonths(
                    expectedBillingMonths, actualBillingMonths);

            Assert.AreEqual(2, missingBillingMonths);
        }

        [TestMethod]
        public void IsAllVolumesExistForTheContract()
        {
            var contract = ContractReaderStub.Contract();
            var volumes = ContractProductSiteVolumeReaderStub.AllVolumes();


            var expectedBillingMonths =
                SiteVolumeCalculator.ExpectedBillingMonthsForTheContract(contract);
            var actualBillingMonths = SiteVolumeCalculator.BillingMonths(volumes);

            var totalNumberOfMissingBillingMonths =
                SiteVolumeCalculator.MissingBillingMonths(
                    expectedBillingMonths, actualBillingMonths);

            var actualResult =
                SiteVolumeCalculator.IsAllVolumesExistForTheContract(
                    totalNumberOfMissingBillingMonths);

            Assert.AreEqual(true, actualResult);
        }


        [TestMethod]
        public void GroupedSiteVolumes()
        {
            var contract = ContractReaderStub.Contract();
            var volumes = ContractProductSiteVolumeReaderStub.AllVolumes();

            var allSiteVolumesForTheContract =
                SiteVolumeCalculator.SiteVolumesForContract(contract,
                    volumes);

            var groupedSiteVolumes =
                SiteVolumeCalculator.GroupedSiteVolumes(allSiteVolumesForTheContract);

            Assert.AreEqual(200, groupedSiteVolumes.ElementAt(0).Volume);
            Assert.AreEqual(new DateTime(2016, 1, 1),
                groupedSiteVolumes.ElementAt(0).BillingMonth);
            Assert.AreEqual(20, groupedSiteVolumes.ElementAt(0).SiteId);
            Assert.AreEqual(100, groupedSiteVolumes.ElementAt(1).Volume);
            Assert.AreEqual(new DateTime(2016, 2, 1),
                groupedSiteVolumes.ElementAt(1).BillingMonth);
            Assert.AreEqual(20, groupedSiteVolumes.ElementAt(1).SiteId);
        }


        [TestMethod]
        public void TotalSiteVolume()
        {

            var contract = ContractReaderStub.Contract();
            var volumes = ContractProductSiteVolumeReaderStub.AllVolumes();

            var allSiteVolumesForTheContract =
                SiteVolumeCalculator.SiteVolumesForContract(contract,
                    volumes);
            var groupedSiteVolumes =
                SiteVolumeCalculator.GroupedSiteVolumes(allSiteVolumesForTheContract);


            var totalContractedSiteVolume =
                SiteVolumeCalculator.TotalSiteVolume(groupedSiteVolumes);

            Assert.AreEqual(300, totalContractedSiteVolume);
        }


        [TestMethod]
        public void TotalContractedVolumeForAllVolumeAvailableContract()
        {
            var contract = ContractReaderStub.Contract();
            var contracts = ContractReaderStub.Contracts();
            var products = ContractProductReaderStub.Products();
            var sites = ContractProductSiteReaderStub.Sites();
            var volumes = ContractProductSiteVolumeReaderStub.AllVolumes();

            var forecaster =
                new SiteVolumeCalculator();

            var actualResult =
                forecaster.TotalContractedVolume(
                    contract, contracts,
                    products,
                    sites,
                    volumes
                );

            Assert.AreEqual(300, actualResult);
        }

      
       
        [TestMethod]
        public void IsNoVolumeContract()
        {

            var contract = ContractReaderStub.Contract();
            var volumes = ContractProductSiteVolumeReaderStub.NoVolumes();
            var allSiteVolumesForTheContract =
                SiteVolumeCalculator.SiteVolumesForContract(contract,
                    volumes);

            var result =
                SiteVolumeCalculator.IsNoVolumeContract(allSiteVolumesForTheContract);

            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void PreviousContractForTheClient()
        {

            var contract = ContractReaderStub.Contract();
            var contracts = ContractReaderStub.Contracts();
            
            var previousContract =
                SiteVolumeCalculator.PreviousContractForClient(
                    contract, contracts);

            Assert.AreEqual(33, previousContract.ClientId);
            Assert.AreEqual(new DateTime(2015, 3, 1), previousContract.EndDate);
        }

        [TestMethod]
        public void ExcludeCurrentContractForTheClient()
        {

            var contract = ContractReaderStub.Contract();
            var contracts = ContractReaderStub.Contracts();

            var previousContract =
                SiteVolumeCalculator.PreviousContractForClient(
                    contract, contracts);

            Assert.AreEqual(33, previousContract.ClientId);
            Assert.AreEqual(new DateTime(2015, 3, 1), previousContract.EndDate);
            Assert.AreEqual(2, previousContract.Id);
        }


        [TestMethod]
        public void ProductsForTheContract()
        {

            var contract = ContractReaderStub.Contract();
            var products = ContractProductReaderStub.Products();


            var result =
                SiteVolumeCalculator.ContractProducts(contract,
                    products);

            Assert.AreEqual(1, result.ElementAt(0).ContractAmendmentId);
            Assert.AreEqual(1, result.ElementAt(1).ContractAmendmentId);
        }


        [TestMethod]
        public void ProductSites()
        {


            var products = ContractProductReaderStub.Products();
            var sites = ContractProductSiteReaderStub.Sites();


            var result =
                SiteVolumeCalculator.ProductSites(products,sites);

            Assert.AreEqual(3, result.ElementAt(0).ContractProductId);
         }


        [TestMethod]
        public void SiteVolumes()
        {

            var sites = ContractProductSiteReaderStub.Sites();
            var volumes = ContractProductSiteVolumeReaderStub.AllVolumes();

            var contractProductSiteVolumes =
                SiteVolumeCalculator.SiteVolumes(sites, volumes);

            Assert.AreEqual(200,
                contractProductSiteVolumes.ElementAt(0).Volume);
            Assert.AreEqual(100,
                contractProductSiteVolumes.ElementAt(1).Volume);
        }


        [TestMethod]
        public void TotalContractedVolumeForNoVolumeAvailableContract()
        {

            var contract = ContractReaderStub.Contract();
            var contracts = ContractReaderStub.Contracts();
            var products = ContractProductReaderStub.Products();
            var sites = ContractProductSiteReaderStub.Sites();
            var volumes = ContractProductSiteVolumeReaderStub.PreviousSiteVolumes();
           
            var forecaster =
                new SiteVolumeCalculator();

            var totalContractedSiteVolume =
                forecaster.TotalContractedVolume(contract,
                    contracts,
                    products, sites, volumes);

            Assert.AreEqual(150, totalContractedSiteVolume);
        }


        
        [TestMethod]
        public void IsContractHasSomeVolume()
        {



            var contract = ContractReaderStub.Contract();
            var volumes = ContractProductSiteVolumeReaderStub.SomeVolumes();

            var actualResult =
                SiteVolumeCalculator.IsContractHasSomeVolume(contract, volumes);

            Assert.AreEqual(true, actualResult);
        }


        [TestMethod]
        public void CurrentContractVolumes()
        {
            var contract = ContractReaderStub.Contract();
            var volumes = ContractProductSiteVolumeReaderStub.AllVolumes();

            var actualResult =
                SiteVolumeCalculator.CurrentContractVolumes(contract,
                    volumes);

            Assert.AreEqual(200, actualResult.ElementAt(0).Volume);
            Assert.AreEqual(20, actualResult.ElementAt(0).SiteId);
            Assert.AreEqual(new DateTime(2016, 1, 1), actualResult.ElementAt(0).BillingMonth);
            Assert.AreEqual(100, actualResult.ElementAt(1).Volume);
            Assert.AreEqual(20, actualResult.ElementAt(1).SiteId);
            Assert.AreEqual(new DateTime(2016, 2, 1), actualResult.ElementAt(1).BillingMonth);
        }


        [TestMethod]
        public void VolumesExcludedCurrentContractBillingMonths()
        {
            var currentContract = ContractReaderStub.Contract();
            var contracts = ContractReaderStub.Contracts();
            var previousSiteVolumes =
                ContractProductSiteVolumeReaderStub.PreviousSiteVolumes();
            var currentContractSiteVolumes =
                ContractProductSiteVolumeReaderStub.CurrentSiteVolume();
            var previousContractForTheClient =
                SiteVolumeCalculator.PreviousContractForClient(currentContract,
                    contracts);
            var previousContractSiteVolumes =
                SiteVolumeCalculator.SiteVolumesForContract(
                    previousContractForTheClient,
                    previousSiteVolumes);
            var currentContractBillingMonths =
                SiteVolumeCalculator.BillingMonths(
                    currentContractSiteVolumes);

            var actualResult =
                SiteVolumeCalculator
                    .VolumesExcludedCurrentContractBillingMonths(
                        currentContractBillingMonths, previousContractSiteVolumes);

            //march 3rd 2015
            Assert.AreEqual(50, actualResult.ElementAt(0).Volume);
            Assert.AreEqual(30, actualResult.ElementAt(0).SiteId);
            Assert.AreEqual(new DateTime(2015, 3, 1),
                actualResult.ElementAt(0).BillingMonth);
        }

        [TestMethod]
        public void IsContractHasStartDate()
        {
            var contract = ContractReaderStub.Contract();

            var actualResult =
                SiteVolumeCalculator.IsContractHasStartDate(contract);

            Assert.AreEqual(true, actualResult);
        }

        [TestMethod]
        public void TotalContractedVolumeForSomeVolumesAvailableContract()
        {
            var contract = ContractReaderStub.Contract();
            var contracts = ContractReaderStub.Contracts();
            var products = ContractProductReaderStub.Products();
            var sites = ContractProductSiteReaderStub.Sites();
            var volumes = ContractProductSiteVolumeReaderStub.SomeVolumes();

            var forecaster =
                new SiteVolumeCalculator();

            var actualResult =
                forecaster.TotalContractedVolume(
                    contract, contracts,
                    products,
                    sites,
                    volumes
                );

            Assert.AreEqual(250, actualResult);
        }

        [TestMethod] public void NotAllVolumesAvailableAndNotNoVolumesAvailableContract()
        {
            var contract = ContractReaderStub.Contract();
            var contracts = ContractReaderStub.Contracts();
            var products = ContractProductReaderStub.Products();
            var sites = ContractProductSiteReaderStub.Sites();
            var volumes = ContractProductSiteVolumeReaderStub.NotAllVolumeNotNoVolume();

            var forecaster =
                new SiteVolumeCalculator();

            var actualResult =
                forecaster.TotalContractedVolume(
                    contract, contracts,
                    products,
                    sites,
                    volumes
                );

            Assert.AreEqual(250, actualResult);
        }


        [TestMethod]
        public void DecoupleSiteVolumeCalculatorFromForecaster()
        {
            var contract = ContractReaderStub.Contract();
            var contracts = ContractReaderStub.Contracts();
            var products = ContractProductReaderStub.Products();
            var sites = ContractProductSiteReaderStub.Sites();
            var volumes = ContractProductSiteVolumeReaderStub.SomeVolumes();

            var volumeCalculator =
                new SiteVolumeCalculator();
            var volumeForecaster = new SiteVolumeForecaster(volumeCalculator);

            var actualResult = volumeForecaster.TotalContractedVolume(
                contract, contracts,
                products,
                sites,
                volumes);
         
            Assert.AreEqual(250, actualResult);
        }

       



    }
}