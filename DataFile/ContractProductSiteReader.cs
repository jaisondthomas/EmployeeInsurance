using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Entities;
using Forecaster.Interfaces;

namespace DataFile
{
    public class ContractProductSiteReader : IFile<ContractProductSite>
    {
        private readonly string _filePath;

        public ContractProductSiteReader(string filePath)
        {
            _filePath = filePath;
        }


        public bool IsFileExist()
        {
            return  System.IO.File.Exists(_filePath);
        }

        public IEnumerable<ContractProductSite> Read()
        {
            try
            {
                var xmldoc = XDocument.Load(_filePath);

                return xmldoc.Descendants("ContractProductSite").Select(
                    p => new ContractProductSite
                    {
                        ContractProductId =
                            ContractProductSiteValidator.ContractProductId(p
                                .Element("ContractProductId")?.Value),
                        SiteId = ContractProductSiteValidator.SiteId(p
                            .Element("SiteId")?.Value),
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading contract product sites failed - {0}", e);
                throw;
            }
        }
    }
}