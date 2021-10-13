using Faker.Types;
using Faker.Types.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class FakerConfig
    {
        private List<ConfigElement> _customTypes = new List<ConfigElement>();

        public void Add<ObjType, FieldType, GeneratorType>(Expression<Func<ObjType, FieldType>> expression)
        {
            BasicInterface generator = (BasicInterface)Activator.CreateInstance(typeof(GeneratorType));
            if (generator.TypeGetting != typeof(FieldType))
            {
                throw new ArgumentException("Invalid generator");
            }
            Expression expressionBody = expression.Body;
            if (expressionBody.NodeType != ExpressionType.MemberAccess)
            {
                throw new ArgumentException("Invalid expression");
            }
            _customTypes.Add(new ConfigElement(generator, ((MemberExpression)expressionBody).Member));
        }

        public List<ConfigElement> GetCustomTypes
        {
            get
            {
                return _customTypes;
            }
        }
    }
}
