using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;
using Studyzy.LearnEnglishBySubtitle.Import.Hujiang.Entities;

namespace Studyzy.LearnEnglishBySubtitle.Import.Hujiang
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
  
    //public class UserNewWordMapping : IAutoMappingOverride<User_NewWord>
    //{
    //    public void Override(AutoMapping<User_NewWord> mapping)
    //    {
    //        mapping.Id(x => x.Word).GeneratedBy.Assigned();
    //    }

    //}
   
}
