using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Entities;
using Forecaster.Interfaces;

namespace DataFile
{
    public class ContractProductSiteVolumeReader : IFile<SiteVolume>
    {
        private readonly string _filePath;

        public ContractProductSiteVolumeReader(string filePath)
        {
            _filePath = filePath;
        }


        public bool IsFileExist()
        {
            return  System.IO.File.Exists(_filePath);
        }

        public IEnumerable<SiteVolume> Read()
        {
            try
            {
                var xmldoc = XDocument.Load(_filePath);

                return xmldoc.Descendants("SiteVolume").Select(
                    p => new SiteVolume
                    {
                        Volume = ContractProductSiteVolumeValidator.Volume(p
                            .Element("Volume")?.Value),
                        SiteId = ContractProductSiteVolumeValidator.SiteId(p
                            .Element("SiteId")?.Value),
                        BillingMonth =
                            ContractProductSiteVolumeValidator.BillingMonth(p
                                .Element("BillingMonth")?.Value)
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading contract product site volumes failed - {0}", e);
                throw;
            }
        }
    }
}