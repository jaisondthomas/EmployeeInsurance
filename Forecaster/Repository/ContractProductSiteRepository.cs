using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Forecaster.Interfaces;

namespace Forecaster.Repository
{
    public class ContractProductSiteRepository : INterfaceRepository<ContractProductSite>
    {
        private readonly IDataContext<ContractProductSite> _datafile;

        public ContractProductSiteRepository(IDataContext<ContractProductSite> datafile)
        {
            _datafile = datafile;
        }

        public IEnumerable<ContractProductSite> Records(Func<ContractProductSite, bool> predicate = null)
        {
            return predicate != null
                ? _datafile.Records().Where(predicate)
                : _datafile.Records();
        }
    }
}