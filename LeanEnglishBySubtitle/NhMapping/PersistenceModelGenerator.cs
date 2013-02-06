using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Data;


namespace Studyzy.LeanEnglishBySubtitle.NhMapping
{
    public class PersistenceModelGenerator
    {
        //public static IList<Type> IgnoredBaseTypes = new List<Type>
        //                                                 {
                                                        
        //                                                     typeof(Person),typeof(Entity)
                                                        
        //                                                 };

        //public static IList<Type> IncludeBaseTypes = new List<Type>
        //                                                 {
        //                                                     typeof (Employee)
        //                                                 };

        public static AutoPersistenceModel Generate(string[] domainAssemblies, string[] dalAssemblies)
        {
            AutoPersistenceModel mappings = AutoMap.Assemblies(
                new AutoMapConfiguration(), domainAssemblies.Select(Assembly.LoadFrom).ToArray());

            //foreach (Type ignoredBaseType in IgnoredBaseTypes)
            //{
            //    mappings.IgnoreBase(ignoredBaseType);
            //}
            //foreach (Type includeBaseType in IncludeBaseTypes)
            //{
            //    mappings.IncludeBase(includeBaseType);
            //}

            mappings.Conventions.Setup(GetConventions());


            foreach (string dalAssembly in dalAssemblies)
            {
                mappings.UseOverridesFromAssembly(Assembly.LoadFrom(dalAssembly));
            }
            
            return mappings;
        }

        /// <summary>
        ///     Resolves column name from type, return base type name until it is not an ignored base type when input type is a sub-class.
        /// </summary>
        /// <param name="type"> Type </param>
        /// <returns> Column name should use. </returns>
        public static string GetColumnName(Type type)
        {
       
            Type baseType = type;
            while (baseType != null && !new List<Type>
                                                         {
                                                        
                                                             typeof(Entity)
                                                        
                                                         }.Contains(baseType.BaseType))
            {
                baseType = baseType.BaseType;
            }
            return baseType.Name;
        }

        protected static Action<IConventionFinder> GetConventions()
        {
            return finder =>
                       {
                           //finder.Add<ClassNameConvention>();
                           //finder.Add<PrimaryKeyConvention>();
                           //finder.Add<JoinConvention>();
                           //finder.Add<JoinedSubclassConvention>();
                           ////finder.Add<CollectionConvention>();
                           //finder.Add<ReferenceConvention>();
                           //finder.Add<HasManyConvention>();
                           //finder.Add<SubClassNameConvention>();
                           //finder.Add<SubclassConvention>();
                           //finder.Add<PropertyConvention>();
                           finder.Add<EnumConvention>();
                           //finder.Add<HasManyToManyConvention>();
                           //finder.Add<HasOneToOneConvention>();
                           //finder.Add<ComponentConvention>();
                       };
        }
    }
}