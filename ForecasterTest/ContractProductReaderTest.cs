using System;
using System.Collections.Generic;
using System.Linq;
using DataFile;
using Entities;
using Forecaster.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForecasterTest
{
    [TestClass]
    public class ContractProductReaderTest
    {
        [TestMethod]
        public void IsContractProductFileAvailable()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductReaderStub(filePath);
            var datafile = new ContractProductData(reader);

            var result = datafile.IsFileExist();

            Assert.IsTrue(result);


        }
        [TestMethod]
        public void ReadContractProducts()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductReaderStub(filePath);
            var datafile = new ContractProductData(reader);

            var result = datafile.ReadProducts();

            Assert.AreEqual(1, result.ElementAt(0).Id);
            Assert.AreEqual(30, result.ElementAt(0).ContractAmendmentId);


        }

        [TestMethod]
        public void IsContractProductAvailable()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductReaderStub(filePath);
            var datafile = new ContractProductData(reader);
           
            var result = datafile.IsProductAvailable();

            Assert.IsTrue(result);


        }


        [TestMethod]
        public void EmptyContractProducts()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductReaderStub(filePath);
            var dataFile = new ContractProductData(reader);

            var result = dataFile.EmptyProducts();

            Assert.AreEqual(0, result.Count());

        }

        [TestMethod]
        public void AllContractProducts()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductReaderStub(filePath);
            var dataFile = new ContractProductData(reader);
            var result = dataFile.Records();

            Assert.AreEqual(1, result.ElementAt(0).Id);
            Assert.AreEqual(30, result.ElementAt(0).ContractAmendmentId);


        }

       
        [TestMethod]
        public void IsProductIdNotNull()
        {
            var id = ContractProductReaderStub.ReadProductId();

            var result = ContractProductValidator.IsProductIdNotNull(id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ProductIdToLongType()
        {
            var id = ContractProductReaderStub.ReadProductId();

            var result = ContractProductValidator.ProductIdToLongType(id);

            Assert.AreEqual(typeof(long), result.GetType());
        }

        [TestMethod]
        public void ProductId()
        {
            var id = ContractProductReaderStub.ReadProductId();

            var result = ContractProductValidator.ProductId(id);

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void IsContractIdNotNull()
        {
            var id = ContractProductReaderStub.ReadContractId();

            var result = ContractProductValidator.IsContractIdNotNull(id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContractIdToLongType()
        {
            var id = ContractProductReaderStub.ReadContractId();

            var result = ContractProductValidator.ContractIdToLongType(id);

            Assert.AreEqual(typeof(long), result.GetType());
        }

        [TestMethod]
        public void ContractId()
        {
            var id = ContractProductReaderStub.ReadContractId();

            var result = ContractProductValidator.ContractId(id);

            Assert.AreEqual(1, result);
        }
    }
}
