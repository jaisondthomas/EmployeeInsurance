using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Forecaster.Entities;
using Forecaster.Interfaces;

namespace DataFile
{
    public class ContractReader : IFile<ContractAmendment>
    {
        private readonly string _filePath;

        public ContractReader(string filePath)
        {
            _filePath = filePath;
        }


        public bool IsFileExist()
        {
            return  System.IO.File.Exists(_filePath);
        }

        public IEnumerable<ContractAmendment> Read()
        {
            try
            {
                var xmldoc = XDocument.Load(_filePath);

                return xmldoc.Descendants("Contract").Select(
                    p => new ContractAmendment
                    {
                        Id = ContractValidator.ContractId( p.Element("Id")?.Value),
                        ClientId = ContractValidator.ClientId(p.Element("ClientId")?.Value),
                        StartDate =
                            ContractValidator.StartDate(p.Element("StartDate")?.Value),
                        EndDate =
                            ContractValidator.EndDate(p.Element("EndDate")?.Value)
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading contracts failed - {0}", e);
                throw;
            }
        }
    }
}