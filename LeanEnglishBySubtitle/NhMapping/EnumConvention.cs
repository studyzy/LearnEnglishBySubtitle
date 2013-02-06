using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Studyzy.LeanEnglishBySubtitle.NhMapping
{
    public class EnumConvention : IUserTypeConvention
    {
        #region IUserTypeConvention Members

        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum);
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType(instance.Property.PropertyType);
            Debug.WriteLine("-----IUserTypeConvention----" + instance.EntityType + " " + instance.Property.PropertyType);
        }

        #endregion
    }
}
