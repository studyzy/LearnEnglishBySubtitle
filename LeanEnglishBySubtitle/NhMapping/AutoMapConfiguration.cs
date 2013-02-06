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

            return (type.IsClass && type.Namespace.StartsWith("Studyzy.LeanEnglishBySubtitle.Entities"));
            //return type.In(typeof (IbEmployee), typeof (Employee), typeof (EmployeeBackup));
        }
        public override bool ShouldMap(Member member)
        {
            return member.IsProperty && member.IsPublic && member.CanWrite;
        }


     
    }
}