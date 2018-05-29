using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Forecaster.Interfaces;

namespace DataFile
{
    public class ContractProductSiteData : IDataContext<ContractProductSite>
    {
        
        private readonly IFile<ContractProductSite> _site;

        public ContractProductSiteData(IFile<ContractProductSite> site)
        {
            _site = site;
        }

        public bool IsFileExist()
        {
            return _site.IsFileExist();
        }

        public IEnumerable<ContractProductSite> ReadSites()
        {
            return _site.Read();
        }

        public bool IsSitesAvailable()
        {
            return ReadSites().Any();
        }

        public IEnumerable<ContractProductSite> Records()
        {
            SitesFileNotFound(IsFileExist());

            return IsSitesAvailable()
                ? ReadSites()
                : EmptySites();
        }

        public IEnumerable<ContractProductSite> EmptySites()
        {
            return new List<ContractProductSite>();
        }

        public void SitesFileNotFound(bool isFileFound)
        {
            if (!isFileFound)
                throw new Exception("Contract product sites file not found");
        }
    }
}