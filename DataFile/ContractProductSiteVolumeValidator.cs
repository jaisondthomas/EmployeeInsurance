using System;

namespace DataFile
{
    public static class ContractProductSiteVolumeValidator
    {
        public static bool IsSiteIdNotNull(string id)
        {
            return !string.IsNullOrEmpty(id);
        }

        public static long SiteIdToLong(string id)
        {
            return FileUtility.StringToLongType(id);
            
        }

        public static long SiteId(string id)
        {
            long siteId = 0;
            if (IsSiteIdNotNull(id))
                siteId = SiteIdToLong(id);
            return siteId;
        }

        public static bool IsBillingMonthNotNull(string month)
        {
            return !string.IsNullOrEmpty(month);
        }

        public static DateTime BillingMonthToDateType(string month)
        {
            return FileUtility.StringToDateType(month);
        }

        public static DateTime BillingMonth(string month)
        {
            var billingMonth = new DateTime();
            if (IsBillingMonthNotNull(month))
                billingMonth = BillingMonthToDateType(month);
            return billingMonth;
        }

        public static bool IsVolumeNotNull(string volume)
        {
            return !string.IsNullOrEmpty(volume);
        }

        public static decimal VolumeToDecimalType(string volume)
        {
            decimal vol;
            decimal.TryParse(volume, out vol);
            return vol;
        }

        public static decimal Volume(string volume)
        {
            decimal vol = 0;
            if (IsVolumeNotNull(volume))
                vol = VolumeToDecimalType(volume);
            return vol;
        }
    }
}