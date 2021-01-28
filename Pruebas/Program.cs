using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "http://";
            s = Regex.Replace(s, "https://", "http://", RegexOptions.IgnoreCase);

            Stack st = new Stack();
            st.Push(1);
            st.Push(2);
            st.Push(3);
            st.Pop();

            var uno = ConfigurationSettings.AppSettings[""];

            var dos = ConfigurationManager.AppSettings[""];


        }
    }
}
