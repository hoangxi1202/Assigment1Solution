using System;
using DataAccess.Repository;
using BusinessObject;
using System.Text.RegularExpressions;

namespace MyStoreWinApp
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }
        public IMemberRepository memberRepository = new MemberRepository();
        public IEnumerable<MemberObject> Members { get; set; }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            txtSearch.Hide();
            cmbCity.Hide();
            cmbCountry.Hide();
        }
        private int Choose()
        {
            switch (cmbType.Text)
            {
                case "Search by ID and Name":
                    return 1;
            }
            return 0;
        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Choose() == 1)
            {
                txtSearch.Show();
                cmbCity.Hide();
                cmbCountry.Hide();
            }            
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            try
            {
                SearchError errors = new SearchError();
                bool found = false;
                switch (Choose())
                {
                    case 1:
                        string search = txtSearch.Text;
                        if (string.IsNullOrEmpty(search) || search.Equals(" "))
                        {
                            found = true;
                            errors.SearchIDNameError = "search can not be empty";
                        }
                        if (found)
                        {
                            MessageBox.Show($"{errors.SearchIDNameError} \n ", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Members = memberRepository.GetMemberByName(search);
                        }
                        break;
                    case 0:
                        MessageBox.Show("Please choose type before", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        frmSearch frmSearch = new frmSearch();
                        frmSearch.ShowDialog();
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public record SearchError()
        {
            public string? SearchIDNameError { get; set; }
            public string? CityError { get; set; }
            public string? CountryError { get; set; }


        }
    }
}
