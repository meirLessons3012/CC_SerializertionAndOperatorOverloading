using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_SerializertionAndOperatorOverloading
{
    internal static class MyStringExtentions
    {
        public static string LastLowerCase(this string text)
        {
            string resText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (i == text.Length - 1 || text[i + 1] == ' ') 
                    resText += text[i].ToString().ToLower();
                else resText += text[i];
            }
            return resText;
        }

        public static string GetSomeChars(this string text, int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += text[i];
            }
            return result ;
        }

        public static int GetRandomNumberWithout357(this Random random, int from, int till)
        {
            int res;
            do
            {
                res = random.Next(from, till);
            } while (res == 3 || res == 5 || res == 7);

            return res;
        }

        public static void ExtensionForInterface(this ICloneable cloneable)
        {
            cloneable.Clone();
        }

    }
}
