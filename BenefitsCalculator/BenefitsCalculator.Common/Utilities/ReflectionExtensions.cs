using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BenefitsCalculator.Common.Utilities
{
    public static class ReflectionExtensions
    {
        public static List<T> GetInterfaceImplementations<T>(this Assembly assemblyToSearch) where T : class
        {
            if (!typeof(T).IsInterface)
            {
                throw new InvalidOperationException($"{typeof(T).Name} must be an interface.");
            }

            var rules = (from type in assemblyToSearch.GetTypes()
                         where !type.IsAbstract && type.GetInterfaces().Contains(typeof(T))
                         select (T)Activator.CreateInstance(type));

            return rules.ToList();
        }
    }
}
