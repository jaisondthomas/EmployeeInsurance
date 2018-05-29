using System;
using System.Collections.Generic;
using System.Linq;
using Forecaster.Entities;
using Forecaster.Interfaces;

namespace Forecaster.Repository
{
    public class ContractRepository : IContractRepository<ContractAmendment>
    {
        private readonly IDataContext<ContractAmendment>  _datafile;

        public ContractRepository(IDataContext<ContractAmendment> datafile)
        {
            _datafile = datafile;
        }

        public IEnumerable<ContractAmendment> Contracts(
            Func<ContractAmendment, bool> predicate = null)
        {
            return predicate != null
                ? _datafile.Records().Where(predicate)
                : _datafile.Records();
        }

        public ContractAmendment Contract(Func<ContractAmendment, bool> predicate)
        {
            return _datafile.Records().FirstOrDefault(predicate);
        }
    }
}