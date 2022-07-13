using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sumArray = new List<string>();
            string[] arrayNumbers = new string[] { "1", "2", "3" };
            string[] newArrayNumbers = new string[] { "2", "3", "4" };
            sumArray.AddRange(arrayNumbers);
            sumArray.AddRange(newArrayNumbers);
            var clearList = sumArray.Distinct();

            foreach (string number in clearList)
            {

                Console.Write(number + " ");
            }
        }
    }
}
