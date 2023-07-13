using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MyLibraries
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _serviceContainer = new Dictionary<Type, object>();

        public static void SetService<T>(T service) where T : class
        {
            var type = typeof(T);
            if (_serviceContainer.ContainsKey(type))
            {
                _serviceContainer[type] = service;
            }
            else
            {
                _serviceContainer.Add(type, service);
            }
        }

        public static T Resolve<T>()
        {
            var type = typeof(T);
            if (_serviceContainer.ContainsKey(type))
            {
                return (T)_serviceContainer[type];
            }
            else
            {
                throw new Exception($"Service of type {type} not found");
            }
        }
    }
}
