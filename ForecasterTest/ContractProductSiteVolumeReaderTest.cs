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
    public class ContractProductSiteVolumeReaderTest
    {
        [TestMethod]
        public void IsContractProductSiteVolumeFileAvailable()
        {
            var filePath = string.Empty; ;
            var file = new ContractProductSiteVolumeReaderStub(filePath);
            var datafile = new ContractProductSiteVolumeData(file);

            var result = datafile.IsFileExist();

            Assert.IsTrue(result);


        }



        [TestMethod]
        public void ReadContractProductSiteVolumes()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteVolumeReaderStub(filePath);
            var datafile = new ContractProductSiteVolumeData(reader);

            var result = datafile.ReadVolumes();

            Assert.AreEqual(100, result.ElementAt(0).Volume);
            Assert.AreEqual(002, result.ElementAt(0).SiteId);
            Assert.AreEqual(new DateTime(2018, 5, 3), result.ElementAt(0).BillingMonth);


        }

        [TestMethod]
        public void IsContractProductSiteVolumesAvailable()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteVolumeReaderStub(filePath);
            var datafile = new ContractProductSiteVolumeData(reader);
            
            var result = datafile.IsVolumesAvailable();

            Assert.IsTrue(result);



        }


        [TestMethod]
        public void AllContractProductSiteVolumes()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteVolumeReaderStub(filePath);
            var dataFile = new ContractProductSiteVolumeData(reader);

            var result = dataFile.Records();

            Assert.AreEqual(100, result.ElementAt(0).Volume);
            Assert.AreEqual(002, result.ElementAt(0).SiteId);
            Assert.AreEqual(new DateTime(2018, 5, 3), result.ElementAt(0).BillingMonth);



        }


        [TestMethod]
        public void EmptyContractProductSiteVolumes()
        {
            var filePath = string.Empty; ;
            var reader = new ContractProductSiteVolumeReaderStub(filePath);
            var dataFile = new ContractProductSiteVolumeData(reader);
            
            var result = dataFile.EmptyVolumes();

            Assert.AreEqual(0, result.Count());

        }


        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Contract product site volumes file not found")]
        public void ContractProductSiteVolumesFileNotFound()
        {
            var filePath = string.Empty; ;

            var reader = new ContractProductSiteVolumeReaderStub(filePath);
            var dataFile = new ContractProductSiteVolumeData(reader);
            var isFileFound = false;

            dataFile.VolumeFileNotFound(isFileFound);
        }

        [TestMethod]
        public void IsSiteIdNotNull()
        {
            var id = ContractProductSiteVolumeReaderStub.ReadSiteId();

            var result = ContractProductSiteVolumeValidator.IsSiteIdNotNull(id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SiteIdToLong()
        {
            var id = ContractProductSiteVolumeReaderStub.ReadSiteId();

            var result = ContractProductSiteVolumeValidator.SiteIdToLong(id);

            Assert.AreEqual(typeof(long), result.GetType());
        }

        [TestMethod]
        public void SiteId()
        {
            var id = ContractProductSiteVolumeReaderStub.ReadSiteId();

            var result = ContractProductSiteVolumeValidator.SiteId(id);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void IsBillingMonthNotNull()
        {
            var month = ContractProductSiteVolumeReaderStub.ReadBillingMonth();

            var result = ContractProductSiteVolumeValidator.IsBillingMonthNotNull(month);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BillingMonthToDateType()
        {
            var month = ContractProductSiteVolumeReaderStub.ReadBillingMonth();

            var result = ContractProductSiteVolumeValidator.BillingMonthToDateType(month);

            Assert.AreEqual(typeof(DateTime), result.GetType());
        }

        [TestMethod]
        public void BillingMonth()
        {
            var month = ContractProductSiteVolumeReaderStub.ReadBillingMonth();

            var result = ContractProductSiteVolumeValidator.BillingMonth(month);

            Assert.AreEqual(new DateTime(2016, 2, 1), result);
        }


        [TestMethod]
        public void IsVolumeNotNull()
        {
            var volume = ContractProductSiteVolumeReaderStub.ReadVolume();

            var result = ContractProductSiteVolumeValidator.IsVolumeNotNull(volume);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VolumeToDecimalType()
        {
            var volume = ContractProductSiteVolumeReaderStub.ReadVolume();

            var result = ContractProductSiteVolumeValidator.VolumeToDecimalType(volume);

            Assert.AreEqual(typeof(decimal), result.GetType());
        }

        [TestMethod]
        public void Volume()
        {
            var volume = ContractProductSiteVolumeReaderStub.ReadVolume();

            var result = ContractProductSiteVolumeValidator.Volume(volume);

            Assert.AreEqual(100, result);
        }
    }
}
