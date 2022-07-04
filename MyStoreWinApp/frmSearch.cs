using DataAccess.Repository;
using BusinessObject;

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
            lbCity.Hide();
            lbCountry.Hide();
            lbSearch.Hide();    
        }
        private int Choose()
        {
            switch (cmbType.Text)
            {
                case "Search by ID and Name":
                    return 1;
                case "Fillter by City and Country":
                    return 2;
                case "Sort descending order by MemberName":
                    return 3;
            }
            return 0;
        }
        private List<string> getAllCity()
        {
            List<string> list = new List<string>();
            try
            {
                var members = memberRepository.GetMembers();
                list = members.Select(x => x.City).Distinct().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }
        private List<string> getAllCountry()
        {
            List<string> list = new List<string>();
            try
            {
                var members = memberRepository.GetMembers();
                list = members.Select(x => x.Country).Distinct().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Choose() == 1)
            {
                txtSearch.Show();
                lbSearch.Show();
                lbCity.Hide();
                lbCountry.Hide();
                cmbCity.Hide();
                cmbCountry.Hide();
            }
            else if (Choose() == 2)
            {
                txtSearch.Hide();
                lbSearch.Hide();

                lbCity.Show();
                cmbCity.Show();
                foreach (var c in getAllCity())
                {
                    cmbCity.Items.Add(c);
                }
                lbCountry.Show();
                cmbCountry.Show();
                foreach (var c in getAllCountry())
                {
                    cmbCountry.Items.Add(c);
                }
            }
            else
            {
                lbCountry.Hide();
                lbCity.Hide();
                lbCountry.Hide();
                txtSearch.Hide();
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
                            errors.SearchIDNameError = "Search can not be empty";
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
                    case 2:
                        string city = cmbCity.Text;
                        if (string.IsNullOrEmpty(city) || city.Equals(" "))
                        {
                            found = true;
                            errors.CityError = "city can not be empty";
                        }

                        string country = cmbCountry.Text;
                        if (string.IsNullOrEmpty(country) || country.Equals(" "))
                        {
                            found = true;
                            errors.CountryError = "country can not be empty";
                        }

                        if (found)
                        {
                            MessageBox.Show($"{errors.CityError} \n " +
                                $"{errors.CountryError}", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Members = memberRepository.GetMemberByCityAndCountry(city, country);
                        }
                        break;
                    case 3:
                        Members = memberRepository.SortDesByName();
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
