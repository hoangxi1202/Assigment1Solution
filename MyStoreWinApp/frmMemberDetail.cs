using DataAccess.Repository;
using BusinessObject;
namespace MyStoreWinApp;

public partial class frmMemberDetail : Form
{
    public frmMemberDetail()
    {
        InitializeComponent();
    }
    public bool InsertOrUpdate { get; set; }
    public MemberObject MemberInfo { get; set; }
    public IMemberRepository MemberRepository { get; set; }

    private void frmMemberDetail_Load(object sender, EventArgs e)
    {
        txtMemberID.Enabled = !InsertOrUpdate;
        if (InsertOrUpdate == true)
        {
            txtMemberID.Text = MemberInfo.MemberID;
            txtMemberName.Text = MemberInfo.MemberName;
            txtEmail.Text = MemberInfo.Email;
            txtPassword.Text = MemberInfo.Password;
            txtCity.Text = MemberInfo.City;
            txtCountry.Text = MemberInfo.Country;
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var member = new MemberObject
            {
                MemberID = txtMemberID.Text,
                MemberName = txtMemberName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
            };
            if (InsertOrUpdate == false)
            {
                MemberRepository.InsertMember(member);
            }
            else
            {
                MemberRepository.UpdateMember(member);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new member" : "Update a member");
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();
}
