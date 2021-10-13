using Faker.Types.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class ConfigElement
    {
        private BasicInterface _customType;
        private MemberInfo _memberInfo;

        public ConfigElement(BasicInterface customType, MemberInfo memberInfo)
        {
            _customType = customType;
            _memberInfo = memberInfo;
        }

        public BasicInterface GetCustomType
        {
            get
            {
                return _customType;
            }
        }

        public MemberInfo GetMemberInfo
        {
            get
            {
                return _memberInfo;
            }
        }
    }
}
