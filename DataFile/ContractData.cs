using System;
using System.Collections.Generic;
using System.Linq;
using Forecaster.Entities;
using Forecaster.Interfaces;

namespace DataFile
{
    public class ContractData : IDataContext<ContractAmendment>
    {
        private static IFile<ContractAmendment> _contract;
       

        public ContractData(IFile<ContractAmendment> contract)
        {
            _contract = contract;
        }


        public bool IsFileExist()
        {
            return _contract.IsFileExist();
        }

        public static IEnumerable<ContractAmendment> ReadContracts()
        {
            return _contract.Read();
        }

        public static bool IsContractAvailable()
        {
            return ReadContracts().Any();
        }

        public IEnumerable<ContractAmendment> Records()
        {
          
            ContractFileNotFound(IsFileExist());

            return IsContractAvailable() ? ReadContracts() : EmptyContract();
        }

       
        public static IEnumerable<ContractAmendment> EmptyContract()
        {
            return new List<ContractAmendment>();
        }

        public static void ContractFileNotFound(bool isFileFound)
        {
            if(!isFileFound)
                throw new Exception("Contracts file not found");
        }
    }
}