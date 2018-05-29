using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Entities;
using Forecaster.Interfaces;

namespace DataFile
{
    public class ContractProductReader : IFile<ContractProduct>
    {
        private readonly string _filePath;

        public ContractProductReader(string filePath)
        {
            _filePath = filePath;
        }


        public bool IsFileExist()
        {
            return  System.IO.File.Exists(_filePath);
        }

        public IEnumerable<ContractProduct> Read()
        {
            try
            {
                var xmldoc = XDocument.Load(_filePath);

                return xmldoc.Descendants("ContractProduct").Select(
                    p => new ContractProduct
                    {
                        Id = ContractProductValidator.ContractId(p.Element("Id")
                            ?.Value),
                        ContractAmendmentId =
                            ContractProductValidator.ContractId(p
                                .Element("ContractAmendmentId")?.Value),
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading contract products failed - {0}", e);
                throw;
            }
        }
    }
}