using System.Collections.Generic;
using Entities;
using Forecaster.Entities;

namespace Forecaster.Interfaces
{
    public interface ISiteVolumeCalculator
    {
        decimal TotalContractedVolume(
            ContractAmendment contract, List<ContractAmendment> contracts,
            List<ContractProduct> contractProducts,
            List<ContractProductSite> contractProductSites,
            List<SiteVolume> siteVolumes);
    }
}