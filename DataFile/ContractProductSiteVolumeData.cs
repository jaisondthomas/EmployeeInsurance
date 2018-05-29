using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Forecaster.Interfaces;

namespace DataFile
{
    public class ContractProductSiteVolumeData : IDataContext<SiteVolume>
    {
       
        private readonly IFile<SiteVolume> _volume;

        public ContractProductSiteVolumeData(IFile<SiteVolume> volume)
        {
          _volume = volume;
        }

        public bool IsFileExist()
        {
            return _volume.IsFileExist();
        }

        public IEnumerable<SiteVolume> ReadVolumes()
        {
            return _volume.Read();
        }

        public bool IsVolumesAvailable()
        {
            return ReadVolumes().Any();
        }

        public IEnumerable<SiteVolume> Records()
        {
            VolumeFileNotFound(IsFileExist());

            return IsVolumesAvailable()
                ? ReadVolumes()
                : EmptyVolumes();
        }

        public IEnumerable<SiteVolume> EmptyVolumes()
        {
            return new List<SiteVolume>();
        }

        public void VolumeFileNotFound(bool isFileFound)
        {
            if (!isFileFound)
                throw new Exception("Contract product site volumes file not found");
        }
    }
}