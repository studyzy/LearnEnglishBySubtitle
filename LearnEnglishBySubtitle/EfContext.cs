using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Studyzy.LearnEnglishBySubtitle.Entities;

namespace Studyzy.LearnEnglishBySubtitle
{
    public class EfContext : DbContext
    {
        public DbSet<Subtitle_NewWord> NewWords { get; set; }
        public DbSet<UserVocabulary> UserVocabulary { get; set; }
        public DbSet<IgnoreWord> IgnoreWords { get; set; }
    }
}
