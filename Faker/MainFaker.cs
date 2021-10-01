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
        public MainFaker()
        {
            
        }
        public T Create<T>()
        {
            Type type = typeof(T);
            object obj = Create(type);
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        public object Create(Type type)
        {
            BasicInterface obj = _basic.BasicTypes.Find(x => x.TypeGetting == type);
            if (obj != null)
                return obj.getObj();
            else
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
                return newObj;
            }
        }
    }
}
