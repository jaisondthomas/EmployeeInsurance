using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Forecaster.Interfaces;

namespace Forecaster.Repository
{
    public class ContractProductSiteVolumeRepository : INterfaceRepository<SiteVolume>
    {
        private readonly IDataContext<SiteVolume> _datafile;

        public ContractProductSiteVolumeRepository(IDataContext<SiteVolume> datafile)
        {
            _datafile = datafile;
        }

        public IEnumerable<SiteVolume> Records(Func<SiteVolume, bool> predicate = null)
        {
            return predicate != null
                ? _datafile.Records().Where(predicate)
                : _datafile.Records();
        }
    }
}