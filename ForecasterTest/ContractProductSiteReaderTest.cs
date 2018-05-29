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
    public class ContractProductSiteReaderTest
    {
        [TestMethod]
        public void IsContractProductSiteFileAvailable()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteReaderStub(filePath);
            var dataFile = new ContractProductSiteData(reader);

            var result = dataFile.IsFileExist();

            Assert.IsTrue(result);


        }



        [TestMethod]
        public void ReadContractProductSites()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteReaderStub(filePath);
            var dataFile = new ContractProductSiteData(reader);

            var result = dataFile.ReadSites();

            Assert.AreEqual(1, result.ElementAt(0).ContractProductId);
            Assert.AreEqual(002, result.ElementAt(0).SiteId);


        }

        [TestMethod]
        public void IsContractProductSiteAvailable()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteReaderStub(filePath);
            var dataFile = new ContractProductSiteData(reader);
           
            var result = dataFile.IsSitesAvailable();

            Assert.IsTrue(result);


        }

        [TestMethod]
        public void AllContractProductSites()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteReaderStub(filePath);
            var dataFile = new ContractProductSiteData(reader);

            var result = dataFile.Records();

            Assert.AreEqual(1, result.ElementAt(0).ContractProductId);
            Assert.AreEqual(002, result.ElementAt(0).SiteId);



        }

        [TestMethod]
        public void EmptyContractProductSites()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteReaderStub(filePath);
            var dataFile = new ContractProductSiteData(reader);
          
            var result = dataFile.EmptySites();

            Assert.AreEqual(0, result.Count());




        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "Contract product sites file not found")]
        public void ContractProductSitesFileNotFound()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteReaderStub(filePath);
            var dataFile = new ContractProductSiteData(reader);
            var isFileFound = false;

            dataFile.SitesFileNotFound(isFileFound);
        }

        [TestMethod]
        public void IsContractProductIdNotNull()
        {
            var id = ContractProductSiteReaderStub.ReadContractProductId();

            var result = ContractProductSiteValidator.IsContractProductIdNotNull(id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContractProductIdToLongType()
        {
            var id = ContractProductSiteReaderStub.ReadContractProductId();

            var result = ContractProductSiteValidator.ContractProductIdToLongType(id);

            Assert.AreEqual(typeof(long), result.GetType());
        }

        [TestMethod]
        public void ContractProductId()
        {
            var id = ContractProductSiteReaderStub.ReadContractProductId();

            var result = ContractProductSiteValidator.ContractProductId(id);

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void IsSiteIdNotNull()
        {
            var id = ContractProductSiteReaderStub.ReadSiteId();

            var result = ContractProductSiteValidator.IsSiteIdNotNull(id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SiteIdToLongType()
        {
            var id = ContractProductSiteReaderStub.ReadSiteId();

            var result = ContractProductSiteValidator.SiteIdToLongType(id);

            Assert.AreEqual(typeof(long), result.GetType());
        }


        [TestMethod]
        public void SiteId()
        {
            var id = ContractProductSiteReaderStub.ReadSiteId();

            var result = ContractProductSiteValidator.SiteId(id);

            Assert.AreEqual(02, result);
        }

    }
}
