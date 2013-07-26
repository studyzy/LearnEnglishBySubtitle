using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;
using Studyzy.LearnEnglishBySubtitle.Entities;

namespace Studyzy.LearnEnglishBySubtitle.NhMapping
{

  
    //public class WordRankMapping : IAutoMappingOverride<VocabularyRank>
    //{
    //    public void Override(AutoMapping<VocabularyRank> mapping)
    //    {
    //        Debug.WriteLine("Override WordRankMapping");
    //        mapping.Id(x => x.Word).GeneratedBy.Assigned();
    //    }

    //}
 
    //public class EngDictionaryMapping : IAutoMappingOverride<EngDictionary>
    //{
    //    public void Override(AutoMapping<EngDictionary> mapping)
    //    {
    //        mapping.Id(x => x.Word).GeneratedBy.Assigned();

    //    }
    //}

    //public class WordOriginalMapMapping : IAutoMappingOverride<WordOriginalMap>
    //{
    //    public void Override(AutoMapping<WordOriginalMap> mapping)
    //    {
    //        Debug.WriteLine("Override WordOriginalMapMapping");
    //        mapping.Id(x => x.Word).GeneratedBy.Assigned();

    //    }
    //}
    //public class EasyWordMapping : IAutoMappingOverride<EasyWord>
    //{
    //    public void Override(AutoMapping<EasyWord> mapping)
    //    {
    //        Debug.WriteLine("Override EasyWordMapping");
    //        mapping.Id(x => x.Word).GeneratedBy.Assigned();
    //    }

    //}
    //public class UMapping : IAutoMappingOverride<UploadFile>
    //{
    //    public void Override(AutoMapping<UploadFile> mapping)
    //    {
    //        mapping.DiscriminateSubClassesOnColumn("TYPE").AlwaysSelectWithValue();
    //    }

    //}
    //public class BMapping : IAutoMappingOverride<UserB>
    //{
       
    //    public void Override(AutoMapping<UserB> mapping)
    //    {
    //        mapping.HasMany(a => a.Files).KeyColumn("USER_ID");//.Where("type= 'NHibernateTest.Entitys.UserB'");
    //    }
    //}

    //public class TypeFilter : FilterDefinition
    //{
    //    public const string FilterName = "TypeFilter";
    //    public const string Parameter = "TypeFlag";

    //    public TypeFilter()
    //    {
    //        WithName(FilterName).WithCondition("Type == \"ProjectFile\"");
    //    }
    //}

    //public class EmpUserMapping:IAutoMappingOverride<EmpUser>
    //{
    //    public void Override(AutoMapping<EmpUser> mapping)
    //    {
    //        mapping.HasManyToMany(u => u.Roles).Cascade.AllDeleteOrphan().Not.Inverse();
    //    }
    //}
    //public class EmpRoleMapping : IAutoMappingOverride<EmpRole>
    //{
    //    public void Override(AutoMapping<EmpRole> mapping)
    //    {
    //        mapping.HasManyToMany(u => u.Users).Cascade.None().Inverse();
    //    }
    //}
}
