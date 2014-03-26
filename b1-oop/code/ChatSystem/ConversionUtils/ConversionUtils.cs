using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class ConversionUtils
    {
        public static String ByteArrayToString(byte[] byteArray)
        {
            return System.Text.Encoding.UTF8.GetString(byteArray);
        }

        public static String ByteArrayToString(byte[] byteArray, int index, int count)
        {
            return System.Text.Encoding.UTF8.GetString(byteArray, index, count);
        }

        public static byte[] StringToByteArray(String message)
        {
            return System.Text.Encoding.UTF8.GetBytes(message);
        } 
    }
}
