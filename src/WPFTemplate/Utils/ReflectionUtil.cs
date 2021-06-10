using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WPFTemplate.Utils
{
    public class ReflectionUtil
    {
        /// <summary>
        /// 获取当前应用的所有程序集
        /// </summary>
        public static IEnumerable<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(m =>
                  m.FullName.Contains("WPFTemplate"));
        }

        /// <summary>
        /// 获取程序集中所有类型
        /// </summary>
        public static IEnumerable<Type> GetAssemblyTypes()
        {
            return GetAssemblies()
                .SelectMany(a => a.GetTypes());
        }

        /// <summary>
        /// 获取子类
        /// </summary>
        public static IEnumerable<Type> GetSubClass<T>()
        {
            return GetAssemblyTypes()
                .Where(t => typeof(T).IsAssignableFrom(t));
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        public static IEnumerable<Type> GetAssemblyTypes(string name)
        {
            return GetAssemblyTypes().Where(t => t.Name == name);
        }
    }
}
