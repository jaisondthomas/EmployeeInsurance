using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Forecaster.Interfaces;

namespace DataFile
{
    public class ContractProductData : IDataContext<ContractProduct>
    {
        
        private readonly IFile<ContractProduct> _product;

        public ContractProductData(IFile<ContractProduct> product)
        {
           _product = product;
        }

        public bool IsFileExist()
        {
            return _product.IsFileExist();
        }

        public IEnumerable<ContractProduct> ReadProducts()
        {
            return _product.Read();
        }

        public bool IsProductAvailable()
        {
            return ReadProducts().Any();
        }

        public IEnumerable<ContractProduct> Records()
        {
            ProductFileNotFound(IsFileExist());

            return IsProductAvailable() ? ReadProducts() : EmptyProducts();
        }

        public IEnumerable<ContractProduct> EmptyProducts()
        {
            return new List<ContractProduct>();
        }

        public void ProductFileNotFound(bool isFound)
        {
            if (!isFound) throw new Exception("Contract products file not found");
        }
    }
}