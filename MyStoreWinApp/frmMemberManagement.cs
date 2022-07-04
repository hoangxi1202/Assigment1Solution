using DataAccess;
using DataAccess.Repository;
using BusinessObject;

namespace MyStoreWinApp
{
    public partial class frmMemberManagement : Form
    {
        public frmMemberManagement()
        {
            InitializeComponent();
        }

        IMemberRepository memberRepository = new MemberRepository();
        public bool IsAdmin { get; set; }
        public MemberObject Mem { get; set; }
        public IEnumerable<MemberObject> Members { get; set; }
        BindingSource source;

        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            if (IsAdmin == false)
            {
                btnLoad.Enabled = false;
                btnSearch.Enabled = false;
                btnSearch.Enabled = false;
                btnNew.Enabled = false;
                var members = new List<MemberObject>();
                members.Add(Mem);
                LoadMemberList(members);
            }
            //
            dgvMemberList.CellDoubleClick += DgvCarList_CellDoubleClick;
        }
        private void DgvCarList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail()
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                MemberInfo = GetMemberObject(),
                MemberRepository = memberRepository
            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {

                if (IsAdmin == false)
                {
                    var members = new List<MemberObject>();
                    members.Add(memberRepository.GetMemberByID(Mem.MemberID));
                    LoadMemberList(members);
                }
                else
                {
                    var members = memberRepository.GetMembers();
                    LoadMemberList(members);
                }
                
                //
                source.Position = source.Position - 1;
            }



        }
        //clear

        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtMemberName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
        }
        //
        private MemberObject GetMemberObject()
        {
            MemberObject member = null;
            try
            {
                member = new MemberObject
                {
                    MemberID = txtMemberID.Text,
                    MemberName = txtMemberName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return member;
        }
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

       
        //
       

        

        private void btnNew_Click(object sender, EventArgs e)
        {

            frmMemberDetail frmMemberDetail = new frmMemberDetail()
            {
                Text = "Add car",
                InsertOrUpdate = false,
                MemberRepository = memberRepository

            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                var members = memberRepository.GetMembers();
                LoadMemberList(members);
                source.Position = source.Count - 1;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (IsAdmin == false)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                try
                {
                    var member = GetMemberObject();
                    memberRepository.DeleteMember(member.MemberID);
                    var members1 = memberRepository.GetMembers();
                    LoadMemberList(members1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a member");
                }
            }

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
