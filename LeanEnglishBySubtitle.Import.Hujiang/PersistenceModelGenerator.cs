using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Data;


namespace Studyzy.LeanEnglishBySubtitle.Import.Hujiang
{
    public class PersistenceModelGenerator
    {
    

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

      
    }
}