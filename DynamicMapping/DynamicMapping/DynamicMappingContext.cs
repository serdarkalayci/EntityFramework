using DynamicMappingData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMapping
{
    public class DynamicMappingContext : DbContext
    {
        private string _langCode;
        public DbSet<PersonBase> PersonBase { get; set; }

        public DynamicMappingContext()
        {
            _langCode = "TR";
            Database.SetInitializer<DynamicMappingContext>(null);
        }

        public DynamicMappingContext(string languageCode)
        {
            _langCode = languageCode;
            Database.SetInitializer<DynamicMappingContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable(string.Format("Person_{0}", _langCode));
        }
    }


}
