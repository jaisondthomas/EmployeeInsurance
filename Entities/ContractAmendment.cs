using System;

namespace Forecaster.Entities
{
    public class ContractAmendment
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long Id { get; set; }
        public long ClientId { get; set; }
    }
}