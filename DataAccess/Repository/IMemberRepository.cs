using BusinessObject;
namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMembers();
        void InsertMember(MemberObject member);
        void UpdateMember(MemberObject member);
        void DeleteMember(string memberID);
        MemberObject GetMemberByID(string memberID);
        MemberObject GetMemberByEmail(string email);
        IEnumerable<MemberObject> GetMemberByName(string memberName);
        IEnumerable<MemberObject> GetMemberByCityAndCountry(string city, string country);

        IEnumerable<MemberObject> SortDesByName();
        bool CheckLogin(string userName, string password);
        bool IsAdmin(string userName, string password);
    }
}
