using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Forecaster.Interfaces;

namespace Forecaster.Repository
{
    public class ContractProductRepository : INterfaceRepository<ContractProduct>
    {
        private readonly IDataContext<ContractProduct> _datafile;

        public ContractProductRepository(IDataContext<ContractProduct> datafile)
        {
            _datafile = datafile;
        }

        public IEnumerable<ContractProduct> Records(
            Func<ContractProduct, bool> predicate = null)
        {
            return predicate != null
                ? _datafile.Records().Where(predicate)
                : _datafile.Records();
        }
    }
}