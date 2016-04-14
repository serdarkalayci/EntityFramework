using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Globalization;
using System.Linq;
using System.Threading;
using DynamicMappingData;

namespace DynamicMappingRuntime {

    public static class CompiledModels
    {
        private static readonly Dictionary<string, DbCompiledModel> _compiledModels = new Dictionary<string, DbCompiledModel>(); // Farklı diller için oluşturulan DbCompiledModel'lerin tutulacağı dictionary

        static CompiledModels()
        {
            // Connection ve DbModelBuilder hazırlanıyor.
            var connectionFactory = new LocalDbConnectionFactory("DynamicMappingContext");
            var connection = connectionFactory.CreateConnection("DynamicMappingContext");
            var builder = new DbModelBuilder(DbModelBuilderVersion.V4_1);
            builder.Configurations.Add(new EntityTypeConfiguration<PersonBase>());

            // Türkçe için DbCompiledModel hazırlanıyor ve dictionary'ye ekleniyor.
            builder.Entity<Person>().ToTable("Person_TR");
            _compiledModels.Add("TR", builder.Build(connection).Compile());

            // İngilizce için DbCompiledModel hazırlanıyor ve dictionary'ye ekleniyor.
            builder.Entity<Person>().ToTable("Person_EN");
            _compiledModels.Add("EN", builder.Build(connection).Compile());

        }

        public static DbCompiledModel GetCompiledModel(string languageCode)
        {
            Database.SetInitializer<DynamicMappingContext>(null);
            return _compiledModels[languageCode];
        }
    }
}
