using System;
using System.Diagnostics;
using FluentNHibernate;
using FluentNHibernate.Automapping;


namespace Studyzy.LeanEnglishBySubtitle.NhMapping
{


    public class AutoMapConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            try
            {
                return (type.IsClass && type.Namespace.StartsWith("Studyzy.LeanEnglishBySubtitle.Entities"));
            }
            catch
            {
                Debug .WriteLine(type.ToString());
                return false;
            }
            //return type.In(typeof (IbEmployee), typeof (Employee), typeof (EmployeeBackup));
        }
        public override bool ShouldMap(Member member)
        {
            return member.IsProperty && member.IsPublic && member.CanWrite;
        }


     
    }
}