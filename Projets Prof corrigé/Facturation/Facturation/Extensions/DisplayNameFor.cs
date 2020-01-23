using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Facturation.Extensions
{
    public static class DisplayNameFor
    {
        public static string GetDisplayName<T, TResult>(T Type,Expression<Func<T,TResult>> expression){

            var result = expression.ReturnType;
            var attribute=((DisplayNameAttribute)(result.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault()));
            if (attribute != null) return attribute.DisplayName;
            return typeof(T).Name;
        }
    }
}
