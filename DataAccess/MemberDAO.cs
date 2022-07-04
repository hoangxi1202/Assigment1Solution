using System.Data;
using BusinessObject;
using Microsoft.Data.SqlClient;
namespace DataAccess;

public class MemberDAO : BaseDAL
{
    private static MemberDAO instance = null;
    private static readonly object instanceLock = new object();
    private MemberDAO() { }
    public static MemberDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new MemberDAO();
                }
                return instance;
            }
        }
    }
    public bool CheckLogin(string userName, string password)
    {
        bool result = false;
        MemberObject c = GetMemberByEmail(userName);
        if (c != null)
        {
            if (c.Password.Equals(password))
            {
                result = true;
            }
            else
            {
                throw new Exception("Password is not correct!");
            }
        }
        else
        {
            throw new Exception("User name does not exist.");
        }

        CloseConnection();

        return result;
    }
    public bool IsAdmin(string userName, string password)
    {
        bool result = false;
        MemberObject c = GetAdminAccount();
        if (c.Email.Equals(userName) && c.Password.Equals(password))
        {
            result = true;
        }

        return result;
    }
    public MemberObject GetMemberByEmail(string email)
    {
        MemberObject member = null;
        IDataReader dataReader = null;
        string SQLSelect = "Select MemberID, MemberName, Email, Password, City, Country  " +
            " from Members where Email = @Email";
        try
        {
            var param = dataProvider.CreateParameter("@Email", 50, email, DbType.String);
            dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
            if (dataReader.Read())
            {
                member = new MemberObject
                {
                    MemberID = dataReader.GetString(0),
                    MemberName = dataReader.GetString(1),
                    Email = dataReader.GetString(2),
                    Password = dataReader.GetString(3),
                    City = dataReader.GetString(4),
                    Country = dataReader.GetString(5)
                };
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            dataReader?.Close();
            CloseConnection();
        }
        return member;
    }

    public IEnumerable<MemberObject> GetMemberList()
    {
        IDataReader dataReader = null;
        string SQLSelect = "Select MemberID, MemberName, Email, Password, City, Country from Members";
        var members = new List<MemberObject>();
        try
        {
            dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
            while (dataReader.Read())
            {
                members.Add(new MemberObject
                {
                    MemberID = dataReader.GetString(0),
                    MemberName = dataReader.GetString(1),
                    Email = dataReader.GetString(2),
                    Password = dataReader.GetString(3),
                    City = dataReader.GetString(4),
                    Country = dataReader.GetString(5)
                });
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            dataReader.Close();
            CloseConnection();
        }
        return members;
    }

    public IEnumerable<MemberObject> SortDesByName()
    {
        var members = GetMemberList();
        var sortedList = members.OrderByDescending(x => x.MemberName).ToList();
        return sortedList;
    }

    public IEnumerable<MemberObject> GetMemberByCityAndName(string city, string country)
    {
        IDataReader? dataReader = null;
        string SQLSelect = "Select MemberID, MemberName, Email, Password, City, Country " +
            " from Members" +
            " where City = @City and Country =@Country";
        var members = new List<MemberObject>();
        try
        {
            var param = new List<SqlParameter>();
            param.Add(dataProvider.CreateParameter("@City", 50, city, DbType.String));
            param.Add(dataProvider.CreateParameter("@Country", 50, country, DbType.String));
            dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param.ToArray());
            while (dataReader.Read())
            {
                members.Add(new MemberObject
                {
                    MemberID = dataReader.GetString(0),
                    MemberName = dataReader.GetString(1),
                    Email = dataReader.GetString(2),
                    Password = dataReader.GetString(3),
                    City = dataReader.GetString(4),
                    Country = dataReader.GetString(5)
                });
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            dataReader.Close();
            CloseConnection();
        }
        return members;
    }
    public MemberObject GetMemberByID(string memberID)
    {
        MemberObject member = null;
        IDataReader dataReader = null;
        string SQLSelect = "Select MemberID, MemberName, Email, Password, City, Country  " +
            " from Members where MemberID = @MemberID";
        try
        {
            var param = dataProvider.CreateParameter("@MemberID", 4, memberID, DbType.String);
            dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
            if (dataReader.Read())
            {
                member = new MemberObject
                {
                    MemberID = dataReader.GetString(0),
                    MemberName = dataReader.GetString(1),
                    Email = dataReader.GetString(2),
                    Password = dataReader.GetString(3),
                    City = dataReader.GetString(4),
                    Country = dataReader.GetString(5)
                };
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            dataReader?.Close();
            CloseConnection();
        }
        return member;
    }

    public void Remove(string memberID)
    {
        try
        {
            MemberObject c = GetMemberByID(memberID);
            if (c != null)
            {
                string SQLDelete = "Delete Members where MemberID = @MemberID";
                var param = dataProvider.CreateParameter("@MemberID", 50, memberID, DbType.String);
                dataProvider.Delete(SQLDelete, CommandType.Text, param);
            }
            else
            {
                throw new Exception("The member does not already exist.");
            }


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }

    public IEnumerable<MemberObject> GetMemberByName(string member)
    {
        IDataReader dataReader = null;
        string SQLSelect = "Select MemberID, MemberName, Email, Password, City, Country " +
            " from Members" +
            " where MemberName like @Member or MemberID =@Member";
        var members = new List<MemberObject>();
        try
        {
            var param = dataProvider.CreateParameter("@Member", 50, "%" + member + "%", DbType.String);
            dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
            while (dataReader.Read())
            {
                members.Add(new MemberObject
                {
                    MemberID = dataReader.GetString(0),
                    MemberName = dataReader.GetString(1),
                    Email = dataReader.GetString(2),
                    Password = dataReader.GetString(3),
                    City = dataReader.GetString(4),
                    Country = dataReader.GetString(5)
                });
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            dataReader.Close();
            CloseConnection();
        }
        return members;
    }
}

