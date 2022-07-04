using DataAccess;
using DataAccess.Repository;
using BusinessObject;

namespace MyStoreWinApp
{
    public partial class frmMemberManagement : Form
    {
        IMemberRepository memberRepository = new MemberRepository();

        BindingSource source;
        public IEnumerable<MemberObject> Members { get; set; }
        public frmMemberManagement()
        {
            InitializeComponent();
        }

        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtMemberName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
        }

        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            
        }
        private void DgvCarList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }
        //clear

        //

        public void LoadMemberList(IEnumerable<MemberObject> members)
        {
            try
            {
                // The BindingSource component is designed to simplify
                // the process of binding controls to an underlying data source
                source = new BindingSource();
                source.DataSource = members;
                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtMemberName.DataBindings.Add("Text", source, "MemberName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (members.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var members = memberRepository.GetMembers();
            LoadMemberList(members);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch frmSearch = new frmSearch();
            if (frmSearch.ShowDialog() == DialogResult.OK)
            {
                Members = frmSearch.Members;
                LoadMemberList(Members);
            }
        }
    }
}
