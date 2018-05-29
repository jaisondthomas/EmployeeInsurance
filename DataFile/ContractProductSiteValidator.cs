namespace DataFile
{
    public static class ContractProductSiteValidator
    {
        public static bool IsContractProductIdNotNull(string id)
        {
           return !string.IsNullOrEmpty(id);
        }

        public static long ContractProductIdToLongType(string id)
        {
            return FileUtility.StringToLongType(id);
        }

        public static long ContractProductId(string id)
        {
            long productId = 0;
            if (IsContractProductIdNotNull(id))
                productId = ContractProductIdToLongType(id);
            return productId;
        }

        public static bool IsSiteIdNotNull(string id)
        {
            return !string.IsNullOrEmpty(id);
        }

        public static long SiteIdToLongType(string id)
        {
            return  FileUtility.StringToLongType(id);
        }

        public static long SiteId(string id)
        {
            long siteId = 0;
            if (IsSiteIdNotNull(id))
                siteId = SiteIdToLongType(id);
            return siteId;
        }
    }
}