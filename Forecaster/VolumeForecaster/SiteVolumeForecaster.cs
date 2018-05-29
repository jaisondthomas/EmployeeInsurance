using System.Collections.Generic;
using Entities;
using Forecaster.Entities;
using Forecaster.Interfaces;

namespace Forecaster.VolumeForecaster
{
   public class SiteVolumeForecaster
   {
        private readonly ISiteVolumeCalculator _calculator;
        public SiteVolumeForecaster(ISiteVolumeCalculator calculator)
        {
            _calculator = calculator;
        }

       public decimal TotalContractedVolume(ContractAmendment contract,
           List<ContractAmendment> contracts,
           List<ContractProduct> contractProducts,
           List<ContractProductSite> contractProductSites,
           List<SiteVolume> siteVolumes)
       {
           return _calculator.TotalContractedVolume(contract,
               contracts, contractProducts, contractProductSites, siteVolumes);
       }
        

    }
}