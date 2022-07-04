using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool CheckLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void DeleteMember(string memberID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberObject> GetMemberByCityAndCountry(string city, string country)
        {
            throw new NotImplementedException();
        }

        public MemberObject GetMemberByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public MemberObject GetMemberByID(string memberID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberObject> GetMemberByName(string member) => MemberDAO.Instance.GetMemberByName(member);

        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetMemberList();

        public void InsertMember(MemberObject member)
        {
            throw new NotImplementedException();
        }

        public bool IsAdmin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberObject> SortDesByName()
        {
            throw new NotImplementedException();
        }

        public void UpdateMember(MemberObject member)
        {
            throw new NotImplementedException();
        }
    }
}
