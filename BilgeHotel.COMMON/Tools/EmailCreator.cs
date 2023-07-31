using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.COMMON.Tools
{
    public static class EmailCreator
    {
        public static string CreateEmail(string name, string surname)
        {
            char[] turkish = { 'ı', 'ğ', 'ç', 'ş', 'ö', 'ü', ' ' };
            char[] english = { 'i', 'g', 'c', 's', 'o', 'u', '_' };
            string email = $"{name}{surname}@bilgehotel.com".ToLower();


            for (int i = 0; i <= email.Length; i++)
            {
                for (int a = 0; a < turkish.Length; a++)
                {
                    email = email.Replace(turkish[a], english[a]);
                }

            }

            return email;
        }
    }
}
