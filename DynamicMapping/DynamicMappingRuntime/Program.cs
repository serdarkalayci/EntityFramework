using DynamicMappingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMappingRuntime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Current language is TR");
            DynamicMappingContext contextTr = new DynamicMappingContext("TR");
            Person employeeTr = (Person)contextTr.PersonBase.Where(c => c.Id == 1).First();
            Console.WriteLine("Id:{0}   Name:{1}        DoB:{2}     Occupation:{3}", employeeTr.Id, employeeTr.Name, employeeTr.DateOfBirth, employeeTr.JobDescription);
            Console.WriteLine();
            Console.WriteLine("Current language is EN");
            DynamicMappingContext contextEn = new DynamicMappingContext("EN");
            Person employeeEn = (Person)contextEn.PersonBase.Where(c => c.Id == 1).First();
            Console.WriteLine("Id:{0}   Name:{1}        DoB:{2}     Occupation:{3}", employeeEn.Id, employeeEn.Name, employeeEn.DateOfBirth, employeeEn.JobDescription);

            Console.ReadLine();
        }
    }
}
