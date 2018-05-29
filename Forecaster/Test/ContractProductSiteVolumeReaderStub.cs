using System;
using System.Collections.Generic;
using Entities;
using Forecaster.Entities;
using Forecaster.Interfaces;

namespace Forecaster.Test
{
    public class ContractProductSiteVolumeReaderStub : IFile<SiteVolume>
    {
        private readonly string _filePath;

        public ContractProductSiteVolumeReaderStub(string filePath)
        {
            _filePath = filePath;
        }

        public bool IsFileExist()
        {
            return true;
        }

        public IEnumerable<SiteVolume> Read()
        {
            var siteVolumes = new List<SiteVolume>
            {
                new SiteVolume
                {
                    Volume = 100,
                    SiteId = 002,
                    BillingMonth = new DateTime(2018, 5, 3)
                }
            };
            return siteVolumes;
        }

        public static string ReadSiteId()
        {
         return  "2";
        }

        public static string ReadBillingMonth()
        {
            return  new DateTime(2016,2,1).ToString();
        }

        public static string ReadVolume()
        {
            return "100";
        }

        public static List<SiteVolume> AllVolumes()
        {
            var volumes =
                new List<SiteVolume>
                {
                    new SiteVolume
                    {
                        Volume = 200,
                        SiteId = 20,
                        BillingMonth = new DateTime(2016, 1, 1)
                    },
                    new SiteVolume
                    {
                        Volume = 100,
                        SiteId = 20,
                        BillingMonth = new DateTime(2016, 2, 1)
                    }
                };
            return volumes;
        }

        public static List<SiteVolume> PreviousSiteVolumes()
        {
            var volumes =
                new List<SiteVolume>
                {
                    new SiteVolume
                    {
                        Volume = 50,
                        SiteId = 30,
                        BillingMonth = new DateTime(2015, 1, 1)
                    },
                    new SiteVolume
                    {
                        Volume = 50,
                        SiteId = 30,
                        BillingMonth = new DateTime(2015, 2, 1)
                    },
                    new SiteVolume
                    {
                        Volume = 50,
                        SiteId = 30,
                        BillingMonth = new DateTime(2015, 3, 1)
                    }
                };
            return volumes;
        }

        public static List<SiteVolume> SomeVolumes()
        {
            var volumes =
                new List<SiteVolume>
                {
                    new SiteVolume
                    {
                        Volume = 200,
                        SiteId = 20,
                        BillingMonth = new DateTime(2016, 1, 1)
                    },
                    new SiteVolume
                    {
                        Volume = 50,
                        SiteId = 30,
                        BillingMonth = new DateTime(2015, 2, 1)
                    }
                };
            return volumes;
        }

        public static List<SiteVolume> NoVolumes()
        {
          return  new List<SiteVolume>();
        }

        public static IEnumerable<SiteVolume> CurrentSiteVolume()
        {
            var currentContractSiteVolumes =
                new List<SiteVolume>
                {
                    new SiteVolume
                    {
                        Volume = 200,
                        SiteId = 30,
                        BillingMonth = new DateTime(2016, 1, 1)
                    },
                    new SiteVolume
                    {
                        Volume = 100,
                        SiteId = 30,
                        BillingMonth = new DateTime(2016, 2, 1) 
                    }
                   
                };
            return currentContractSiteVolumes;
        }

        public static List<SiteVolume> NotAllVolumeNotNoVolume()
        {
            var volumes =
                new List<SiteVolume>
                {
                    new SiteVolume
                    {
                        Volume = 250,
                        SiteId = 30,
                        BillingMonth = new DateTime(2016, 1, 1)
                    }
               };
            return volumes;
        }
    }
}