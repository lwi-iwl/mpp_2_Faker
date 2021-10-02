using Faker.Types;
using Faker.Types.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class MainFaker
    {
        private BasicType _basic = new BasicType();
        private List<Type> _sysTypes = typeof(Assembly).Assembly.GetExportedTypes().ToList();
        private List<Type> _pastTypes;
        public MainFaker()
        {
            
        }
        public T Create<T>()
        {
            _pastTypes = new List<Type>();
            Type type = typeof(T);
            object obj = Create(type);
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        private object Create(Type type)
        {
            BasicInterface obj = _basic.BasicTypes.Find(x => x.TypeGetting == type);
            if (obj != null)
                return obj.getObj();
            else if (type.IsGenericType && (type.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>))))
            {
                return CreateList(type);
            }
            else if (type.IsClass && !type.IsArray && !_sysTypes.Contains(type) && !_pastTypes.Contains(type))
            {
                return CreateCustom(type);
            }
            else
                return null;
        }

        private object CreateList(Type type)
        {
            object newObj = null;
            _pastTypes.Add(null);
            ConstructorInfo constructor = type.GetConstructors()[0];
            object[] parameters = new object[1];
            int max = new Random().Next(10, 20);
            newObj = constructor.Invoke(new object[] { });
            for (int i = 0; i < max; i++)
            {
                parameters[0] = Create(type.GetProperty("Item").PropertyType);
                type.GetMethod("Add").Invoke(newObj, parameters);
            }
            _pastTypes.Remove(_pastTypes.Last());
            _pastTypes.Add(type.GetProperty("Item").PropertyType);
            return newObj;
        }

        private object CreateCustom(Type type)
        {
            object newObj = null;
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                ParameterInfo[] pars = constructor.GetParameters();
                List<object> parameters = new List<object>();
                foreach (ParameterInfo p in pars)
                {
                    parameters.Add(Create(p.ParameterType));
                }
                newObj = Activator.CreateInstance(constructor.ReflectedType, parameters.ToArray());
            }
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo method in methods)
            {
                if (method.DeclaringType.GetProperties().Any(prop => prop.SetMethod == method))
                {
                    ParameterInfo[] pars = method.GetParameters();
                    List<object> parameters = new List<object>();
                    foreach (ParameterInfo p in pars)
                    {
                        parameters.Add(Create(p.ParameterType));
                    }
                    method.Invoke(newObj, parameters.ToArray());
                }
            }
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (FieldInfo field in fields)
            {

                field.SetValue(newObj, Create(field.FieldType));
            }
            if (!(_pastTypes.Last() == null))
                _pastTypes.Add(type);
            return newObj;
        }
    }
}
