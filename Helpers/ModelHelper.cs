using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Helpers
{
    public class ModelHelper
    {
        public static string ToStringHelper(object obj)
        {
            return "{" + string.Join("}\n{", obj.GetType()
                                .GetProperties()
                                .Select(prop => prop.Name + " : " + prop.GetValue(obj).ToString()) + "}");
        }

    }
}
