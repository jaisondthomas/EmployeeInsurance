namespace DataFile
{
    public static class ContractProductValidator
    {
        public static bool IsProductIdNotNull(string id)
        {
            return !string.IsNullOrEmpty(id);
        }

        public static bool IsContractIdNotNull(string id)
        {
            return !string.IsNullOrEmpty(id);
        }

        public static long ProductId(string id)
        {
            long productId = 0;
            if (IsProductIdNotNull(id))
                productId = ContractIdToLongType(id);
            return productId;
        }

        public static long ContractIdToLongType(string id)
        {
            return FileUtility.StringToLongType(id);
        }

        public static long ContractId(string id)
        {
            long contractId = 0;
            if (IsProductIdNotNull(id))
                contractId = ContractIdToLongType(id);
            return contractId;
        }

        public static long ProductIdToLongType(string id)
        {
            return FileUtility.StringToLongType(id);
        }
    }
}