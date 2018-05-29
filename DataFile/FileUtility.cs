using System;

namespace DataFile
{
    public static class FileUtility
    {
        public static long StringToLongType(string text)
        {
            long output;
            long.TryParse(text, out output);
            return output;
        }

        public static DateTime StringToDateType(string text)
        {
            DateTime date;
            DateTime.TryParse(text, out date);
            return date;
        }
    }
}