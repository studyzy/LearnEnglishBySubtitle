using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;
using Studyzy.LeanEnglishBySubtitle.Entities;

namespace Studyzy.LeanEnglishBySubtitle.NhMapping
{

  
    public class CK_BookItemMapping : IAutoMappingOverride<CK_BookItem>
    {
        public void Override(AutoMapping<CK_BookItem> mapping)
        {
            mapping.Id(x => x.Id,"ItemId").GeneratedBy.Assigned();
            mapping.References(s => s.Book, "BookId").Not.Nullable();
            mapping.References(s => s.Unit, "UnitId").Not.Nullable();
        }
    }
    public class CK_BookUnitMapping : IAutoMappingOverride<CK_BookUnit>
    {
        public void Override(AutoMapping<CK_BookUnit> mapping)
        {
            mapping.Id(x => x.Id, "UnitId").GeneratedBy.Assigned();
            mapping.HasMany(s => s.Items).KeyColumn("UnitId").Cascade.AllDeleteOrphan().Inverse();
            mapping.References(s => s.Book, "BookId").Not.Nullable();
        }
    }
    public class CK_BooksMapping : IAutoMappingOverride<CK_Books>
    {
        public void Override(AutoMapping<CK_Books> mapping)
        {
            mapping.Id(x => x.Id, "BookId").GeneratedBy.Assigned();
            mapping.HasMany(c => c.Items).KeyColumn("BookId").Cascade.AllDeleteOrphan().Inverse();
            mapping.HasMany(c => c.Units).KeyColumn("BookId").Cascade.AllDeleteOrphan().Inverse();
        }
    }
    public class WordRankMapping : IAutoMappingOverride<VocabularyRank>
    {
        public void Override(AutoMapping<VocabularyRank> mapping)
        {
            mapping.Id(x => x.Word).GeneratedBy.Assigned();
        }

    }
    public class UserNewWordMapping : IAutoMappingOverride<User_NewWord>
    {
        public void Override(AutoMapping<User_NewWord> mapping)
        {
            mapping.Id(x => x.Word).GeneratedBy.Assigned();
        }

    }
    //public class EngDictionaryMapping : IAutoMappingOverride<EngDictionary>
    //{
    //    public void Override(AutoMapping<EngDictionary> mapping)
    //    {
    //        mapping.Id(x => x.Word).GeneratedBy.Assigned();

    //    }
    //}

    public class WordOriginalMapMapping : IAutoMappingOverride<WordOriginalMap>
    {
        public void Override(AutoMapping<WordOriginalMap> mapping)
        {
            mapping.Id(x => x.Word).GeneratedBy.Assigned();

        }
    }
    public class EasyWordMapping : IAutoMappingOverride<EasyWord>
    {
        public void Override(AutoMapping<EasyWord> mapping)
        {
            mapping.Id(x => x.Word).GeneratedBy.Assigned();
        }

    }
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
