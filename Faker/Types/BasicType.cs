using Faker.Types.Basic;
using Faker.Types.Basic.Collection;
using Faker.Types.Basic.Floating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types
{
    class BasicType
    {
        private List<BasicInterface> _basicTypes = new List<BasicInterface>();

        public BasicType()
        {
            _basicTypes.Add(new BasicBoolean());
            _basicTypes.Add(new BasicByte());
            _basicTypes.Add(new BasicSByte());
            _basicTypes.Add(new BasicChar());
            _basicTypes.Add(new BasicShort());
            _basicTypes.Add(new BasicUShort());
            _basicTypes.Add(new BasicInt());
            _basicTypes.Add(new BasicUInt());
            _basicTypes.Add(new BasicLong());
            _basicTypes.Add(new BasicULong());
            _basicTypes.Add(new BasicFloat());
            _basicTypes.Add(new BasicDouble());
            _basicTypes.Add(new BasicDecimal());
            _basicTypes.Add(new BasicString());
        }

        public List<BasicInterface> BasicTypes
        {
            get
            {
                return _basicTypes;
            }
        }

    }
}
