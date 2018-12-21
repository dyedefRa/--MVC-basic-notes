using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiparisTakip2.WebApi.App_Classes.Attribute
{
    public class ClassConverter
    {
        public static T2 Convert<T1, T2>(T1 Type1)
        {
            var t = Activator.CreateInstance<T2>();
            foreach (var propTarget in t.GetType().GetProperties())
                foreach (var propSource in typeof(T1).GetProperties())
                    if (propTarget.Name == propSource.Name && propTarget.PropertyType.Equals(propSource.PropertyType))
                        propTarget.SetValue(t, propSource.GetValue(Type1));
            return t;
        }
    }
}