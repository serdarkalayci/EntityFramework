using DynamicMappingData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMappingRuntime
{
    public class DynamicMappingContext : DbContext
    {

        public DbSet<PersonBase> PersonBase { get; set; }

        public DynamicMappingContext() :  base(CompiledModels.GetCompiledModel("TR"))
        {
            
        }

        public DynamicMappingContext(string languageCode) : base(CompiledModels.GetCompiledModel(languageCode))
        {
        }
    }


}
