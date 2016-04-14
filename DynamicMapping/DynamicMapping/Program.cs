using DynamicMappingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMapping
{
    class Program
    {
        private static string _langCode;
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
                _langCode = args[0];
            else
                _langCode = "TR";
            if (_langCode != "TR" && _langCode != "EN")
            {
                Console.WriteLine("Unsupported language code, switching to TR");
                _langCode = "TR";
            }
            DynamicMappingContext context = new DynamicMappingContext(_langCode);
            Person employee = (Person)context.PersonBase.Where(c => c.Id == 1).First();
            Console.WriteLine("Current Language is {0}", _langCode);
            Console.WriteLine("Id:{0}   Name:{1}        DoB:{2}     Occupation:{3}", employee.Id, employee.Name, employee.DateOfBirth, employee.JobDescription);
            Console.ReadLine();  
        }
    }
}
