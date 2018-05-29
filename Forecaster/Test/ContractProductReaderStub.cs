using System.Collections.Generic;
using Entities;
using Forecaster.Interfaces;

namespace Forecaster.Test
{
    public class ContractProductReaderStub : IFile<ContractProduct>
    {
        private string _filePath;

        public ContractProductReaderStub(string filePath)
        {
            _filePath = filePath;
        }

        public bool IsFileExist()
        {
            return  true;
        }

        public IEnumerable<ContractProduct> Read()
        {
            var contractProducts = new List<ContractProduct>
            {
                new ContractProduct {Id = 1, ContractAmendmentId = 30}
            };
            return contractProducts;
        }

        public static string ReadProductId()
        {
            return "1";
        }

        public static string ReadContractId()
        {
            return "1";
        }
       

        public static List<ContractProduct> Products()
        {
            var product1 =
                new ContractProduct { Id = 3, ContractAmendmentId = 1 };
            var product2 =
                new ContractProduct { Id = 4, ContractAmendmentId = 1 };

            var product3 =
                new ContractProduct { Id = 5, ContractAmendmentId = 2 };
            var products =
                new List<ContractProduct> { product1, product2, product3 };
            return products;
        }

        public static List<ContractProduct> NoProducts()
        {
            return new List<ContractProduct>();
        }
    }
}