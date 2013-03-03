using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using Iesi.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Event;
using NHibernate.Mapping;
using Studyzy.LeanEnglishBySubtitle.NhMapping;
using Environment = System.Environment;

namespace Studyzy.LeanEnglishBySubtitle
{
    public class NHibernateHelper
    {
        private readonly ISessionFactory _sessionFactory;

        public NHibernateHelper(string fileName)
        {
            _sessionFactory = GetSessionFactory(fileName);
        }

        public Configuration Configuration { get; set; }

        private ISessionFactory GetSessionFactory(string fileName)
        {
            Configuration = new Configuration().Configure("NHibernate.config");
            string path = Environment.CurrentDirectory + "\\"+fileName;
            Configuration.Properties["connection.connection_string"] = "Data Source=" + path + ";Version=3;";

            FluentConfiguration fluentConfiguration = Fluently.Configure(Configuration);
   
            InitMapping(fluentConfiguration);
            
            var sf= fluentConfiguration.BuildSessionFactory();
      
            return sf;
        }

        private void InitMapping(FluentConfiguration fluentConfiguration)
        {
            fluentConfiguration.Mappings(
                x =>
                    {
                        x.AutoMappings.Add(PersistenceModelGenerator.Generate(new string[] { "LeanEnglishBySubtitle.exe" },
                                                                              new string[] { "LeanEnglishBySubtitle.exe" }));
#if DEBUG
                        x.AutoMappings.ExportTo(@"D:\Temp");
#endif
                    });

         
        }

        public ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }

    }
}