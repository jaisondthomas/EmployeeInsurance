using System;

namespace DataFile
{
    public static class ContractValidator 
    {
       
        public static long ContractId(string id)
        {
            return !string.IsNullOrEmpty(id) ? FileUtility.StringToLongType(id) : 0;
        }

        public static long ClientId(string id)
        {
            return !string.IsNullOrEmpty(id) ? FileUtility.StringToLongType(id) : 0;
        }

        public static DateTime StartDate(string date)
        {
            return !string.IsNullOrEmpty(date)
                ? FileUtility.StringToDateType(date)
                : new DateTime();
        }

        public static DateTime EndDate(string date)
        {
            return !string.IsNullOrEmpty(date)
                ? FileUtility.StringToDateType(date)
                : new DateTime();
        }
    }
}