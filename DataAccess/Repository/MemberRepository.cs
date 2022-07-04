

using BusinessObject;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool CheckLogin(string userName, string password) => MemberDAO.Instance.CheckLogin(userName, password);

        public void DeleteMember(string memberID) =>MemberDAO.Instance.Remove(memberID);

        public IEnumerable<MemberObject> GetMemberByCityAndCountry(string city, string country)
        
            => MemberDAO.Instance.GetMemberByCityAndName(city, country);
        

        public MemberObject GetMemberByEmail(string email) => MemberDAO.Instance.GetMemberByEmail(email);


        public MemberObject GetMemberByID(string memberID) => MemberDAO.Instance.GetMemberByID(memberID);

        public IEnumerable<MemberObject> GetMemberByName(string memberName) => MemberDAO.Instance.GetMemberByName(memberName);

        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetMemberList();

        public void InsertMember(MemberObject member) => MemberDAO.Instance.AddNew(member);

        public bool IsAdmin(string userName, string password) => MemberDAO.Instance.IsAdmin(userName, password);

        public IEnumerable<MemberObject> SortDesByName() => MemberDAO.Instance.SortDesByName();

        public void UpdateMember(MemberObject member) => MemberDAO.Instance.Update(member);
    }
}
