using System;
using System.Collections.Generic;
using System.Linq;
using DataFile;
using Entities;
using Forecaster.Entities;
using Forecaster.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForecasterTest
{
    [TestClass]
    public class ContractReaderTest
    {
        [TestMethod]
        public void IsContractFileAvailable()
        {
            var filePath = string.Empty;

            var reader = new ContractReaderStub(filePath);
            var dataFile = new ContractData(reader);

            var result = dataFile.IsFileExist();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReadContracts()
        {
           

            var result = ContractData.ReadContracts();


            Assert.AreEqual(1, result.ElementAt(0).Id);
            Assert.AreEqual(30, result.ElementAt(0).ClientId);
            Assert.AreEqual(new DateTime(2017, 1, 1), result.ElementAt(0).StartDate);
            Assert.AreEqual(new DateTime(2018, 1, 1), result.ElementAt(0).EndDate);


        }


        [TestMethod]
        public void IsContractAvailable()
        {
           
            var result = ContractData.IsContractAvailable();

            Assert.IsTrue(result);
        }

       
        [TestMethod]
        public void EmptyContract()
        {
           
           
            var result = ContractData.EmptyContract();

            Assert.AreEqual(0, result.Count());
           


        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Contracts file not found")]
        public void ContractFileNotFound()
        {
           
            var fileStatus = false;

            ContractData.ContractFileNotFound(fileStatus);



        }

        [TestMethod]
        public void AllContracts()
        {
            var filePath = string.Empty; ;
            var reader = new ContractReaderStub(filePath);
            var dataFile = new ContractData( reader);

            var result = dataFile.Records();

            Assert.AreEqual(1, result.ElementAt(0).Id);
            Assert.AreEqual(30, result.ElementAt(0).ClientId);
            Assert.AreEqual(new DateTime(2017, 1, 1), result.ElementAt(0).StartDate);
            Assert.AreEqual(new DateTime(2018, 1, 1), result.ElementAt(0).EndDate);


        }

        //ContractId test
        [TestMethod]
        public void ContractIdIsEmptyString()
        {
           var result =   ContractValidator.ContractId("");
            Assert.AreEqual(0 , result);

        }
        [TestMethod]
        public void ContractIdIsNotEmptyOrNull()
        {
            var result = ContractValidator.ContractId("002ddd");
            Assert.AreEqual(0, result);

        }
        
        [TestMethod]
        public void ValidContractId()
        {
            var result = ContractValidator.ContractId("10");
            Assert.AreEqual(10, result);

        }

       
        [TestMethod]
        public void ClientIdIsEmpty()
        {
            var result = ContractValidator.ClientId("");
            Assert.AreEqual(0, result);

        }

        [TestMethod]
        public void ClientIdNotNullOrEmpty()
        {
            var result = ContractValidator.ClientId("002te");
            Assert.AreEqual(0, result);

        }

        [TestMethod]
        public void ClientIdUnknownCharacters()
        {
            var result = ContractValidator.ClientId("hai*");
            Assert.AreEqual(0 , result);

        }

        [TestMethod]
        public void ValidClientId()
        {
            var result = ContractValidator.ClientId("001");
            Assert.AreEqual(001, result);

        }
      
        [TestMethod]
        public void StartDateIsEmpty()
        {
            var result = ContractValidator.StartDate("");
            Assert.AreEqual(new DateTime(0001,01,01), result);
        }

        [TestMethod]
        public void StartDateNotNullOrEmpty()
        {
            var result = ContractValidator.StartDate("002te");
            Assert.AreEqual(new DateTime(0001, 01, 01), result);
        }

        [TestMethod]
        public void StartDateUnknownCharacters()
        {
            var result = ContractValidator.StartDate("hai*");
            Assert.AreEqual(new DateTime(0001, 01, 01), result);
        }

        [TestMethod]
        public void ValidStartDate()
        {
            var result = ContractValidator.StartDate("2016-02-01");
            Assert.AreEqual(new DateTime(2016, 02, 01), result);
        }

      
        [TestMethod]
        public void EndDateIsEmpty()
        {
            var result = ContractValidator.EndDate("");
            Assert.AreEqual(new DateTime(0001, 01, 01), result);
        }

        [TestMethod]
        public void EndDateNotNullOrEmpty()
        {
            var result = ContractValidator.EndDate("002te");
            Assert.AreEqual(new DateTime(0001, 01, 01), result);
        }

        [TestMethod]
        public void EndDateUnknownCharacters()
        {
            var result = ContractValidator.EndDate("hai*");
            Assert.AreEqual(new DateTime(0001, 01, 01), result);

        }

        [TestMethod]
        public void ValidEndDate()
        {
            var result = ContractValidator.EndDate("2016-02-01");
            Assert.AreEqual(new DateTime(2016, 02, 01), result);

        }
       




    }
}
