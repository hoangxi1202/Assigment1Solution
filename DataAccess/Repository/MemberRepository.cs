using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    internal class MemberRepository
    {
        public IEnumerable<MemberObject> SortDesByName() => MemberDAO.Instance.SortDesByName();
        public IEnumerable<MemberObject> GetMemberByCityAndCountry(string city, string country) => MemberDAO.Instance.GetMemberByCityAndName(city, country);
    }
}
