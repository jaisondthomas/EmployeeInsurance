using System;
using System.Collections.Generic;
using Forecaster.Entities;
using Forecaster.Interfaces;

namespace Forecaster.Test
{
    public class ContractReaderStub : IFile<ContractAmendment>
    {
        public ContractReaderStub(string filePath)
        {
        }

        public bool IsFileExist()
        {
            return true;
        }

        public IEnumerable<ContractAmendment> Read()
        {
            var contracts = new List<ContractAmendment>
            {
                new ContractAmendment
                {
                    StartDate = new DateTime(2017, 1, 1),
                    EndDate = new DateTime(2018, 1, 1),
                    Id = 1,
                    ClientId = 30
                }
            };
            return contracts;
        }

        public static string ReadContractId()
        {
            return "1";
        }

        public static string ReadClientId()
        {
            return "30";
        }

        public static string ReadStartDate()
        {
            return "2018-02-10";
        }

        public static string ReadEndDate()
        {
            return "2018-02-10";
        }

        public static List<ContractAmendment> Contracts()
        {
            var contracts = new List<ContractAmendment>
            {
                new ContractAmendment
                {
                    Id = 2,
                    StartDate = new DateTime(2015, 1, 1),
                    EndDate = new DateTime(2015, 3, 1),
                    ClientId = 33
                },
                new ContractAmendment
                {
                    Id = 1,
                    StartDate = new DateTime(2016, 1, 1),
                    EndDate = new DateTime(2016, 2, 1),
                    ClientId = 33
                }
        };
            return contracts;
        }





        public static ContractAmendment Contract()
        {
            var contract =
                new ContractAmendment
                {
                    Id = 1,
                    StartDate = new DateTime(2016, 1, 1),
                    EndDate = new DateTime(2016, 2, 1),
                    ClientId = 33
                };
            return contract;
        }
    }
}