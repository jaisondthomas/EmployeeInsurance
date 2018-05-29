using System.Collections.Generic;
using Entities;
using Forecaster.Interfaces;

namespace Forecaster.Test
{
    public class ContractProductSiteReaderStub : IFile<ContractProductSite>
    {
        private string _filePath;

        public ContractProductSiteReaderStub(string filePath)
        {
            _filePath = filePath;
        }

        public bool IsFileExist()
        {
            return true;
        }

        public IEnumerable<ContractProductSite> Read()
        {
            var contractProductSites = new List<ContractProductSite>
            {
                new ContractProductSite {ContractProductId = 1, SiteId = 002}
            };
            return contractProductSites;
        }

        public static string ReadContractProductId()
        {
            return "1";
        }

        public static string ReadSiteId()
        {
            return "02";
        }

        public static List<ContractProductSite> Sites()
        {
            var site1 =
                new ContractProductSite { ContractProductId = 3, SiteId = 20 };
            var site2 =
                new ContractProductSite { ContractProductId = 3, SiteId = 30 };

            var site3 =
                new ContractProductSite { ContractProductId = 5, SiteId = 30 };

            var sites =
                new List<ContractProductSite> { site1, site2 , site3 };
            return sites;
        }

        public static List<ContractProductSite> NoSites()
        {
           return  new List<ContractProductSite>();
        }
    }
}