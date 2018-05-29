using System;
using System.Linq;
using DataFile;
using Forecaster.Repository;
using Forecaster.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForecasterTest
{
    [TestClass]
    public class RepositoryInteractorTest
    {
        [TestMethod]
        public void AllContracts()
        {
            var filePath = "Contracts.xml";
            var reader = new ContractReaderStub( filePath );
            var datafile = new ContractData(reader);
            var repository = new ContractRepository( datafile );
            var result =  repository.Contracts();

            Assert.AreEqual(1, result.ElementAt(0).Id);
            Assert.AreEqual(30, result.ElementAt(0).ClientId);
            Assert.AreEqual(new DateTime(2017, 1, 1), result.ElementAt(0).StartDate);
            Assert.AreEqual(new DateTime(2018, 1, 1), result.ElementAt(0).EndDate);
        }

        [TestMethod]
        public void ContractForContractId()
        {
            var filePath = "Contracts.xml";
            var reader = new ContractReaderStub(filePath);
            var datafile = new ContractData( reader);
            var repository = new ContractRepository(datafile);
            var result = repository.Contract( x => x.Id == 1 );

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(30, result.ClientId);
            Assert.AreEqual(new DateTime(2017, 1, 1), result.StartDate);
            Assert.AreEqual(new DateTime(2018, 1, 1), result.EndDate);
        }


        [TestMethod]
        public void AllContractProducts()
        {
            var filePath = "ContractProducts.xml";
            var reader = new ContractProductReaderStub(filePath);
            var datafile = new ContractProductData( reader);
            var repository = new ContractProductRepository(datafile);
            var result = repository.Records();

            Assert.AreEqual(1, result.ElementAt(0).Id);
            Assert.AreEqual(30, result.ElementAt(0).ContractAmendmentId);
        }


        [TestMethod]
        public void AllContractProductSites()
        {
            var filePath = "ContractProductSites.xml";
            var reader = new ContractProductSiteReaderStub(filePath);
            var datafile = new ContractProductSiteData( reader);
            var repository = new ContractProductSiteRepository(datafile);
            var result = repository.Records();

            Assert.AreEqual(1, result.ElementAt(0).ContractProductId);
            Assert.AreEqual(002, result.ElementAt(0).SiteId);
        }


        [TestMethod]
        public void AllContractProductSiteVolumes()
        {
            var filePath = "ContractProductSiteVolumes.xml";
            var reader = new ContractProductSiteVolumeReaderStub(filePath);
            var datafile = new ContractProductSiteVolumeData(reader);
            var repository = new ContractProductSiteVolumeRepository(datafile);
            var result = repository.Records();

            Assert.AreEqual(100, result.ElementAt(0).Volume);
            Assert.AreEqual(002, result.ElementAt(0).SiteId);
            Assert.AreEqual(new DateTime(2018, 5, 3), result.ElementAt(0).BillingMonth);

        }
    }
}
