namespace MyStoreWinApp
{
    partial class frmSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.btnDo = new System.Windows.Forms.Button();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lbCity = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(21, 24);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(52, 20);
            this.lbType.TabIndex = 0;
            this.lbType.Text = "Select:";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Search by ID and Name",
            "Fillter by City and Country",
            "Sort descending order by MemberName"});
            this.cmbType.Location = new System.Drawing.Point(93, 21);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(307, 28);
            this.cmbType.TabIndex = 1;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(93, 64);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "ID or Name";
            this.txtSearch.Size = new System.Drawing.Size(307, 27);
            this.txtSearch.TabIndex = 2;
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(93, 108);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(307, 28);
            this.cmbCountry.TabIndex = 3;
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.cmbCountry_SelectedIndexChanged);
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(93, 64);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(307, 28);
            this.cmbCity.TabIndex = 4;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedIndexChanged);
            // 
            // btnDo
            // 
            this.btnDo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDo.Location = new System.Drawing.Point(263, 168);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(137, 40);
            this.btnDo.TabIndex = 5;
            this.btnDo.Text = "Do";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(21, 67);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(53, 20);
            this.lbSearch.TabIndex = 6;
            this.lbSearch.Text = "Search";
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(21, 67);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(34, 20);
            this.lbCity.TabIndex = 7;
            this.lbCity.Text = "City";
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Location = new System.Drawing.Point(21, 111);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(60, 20);
            this.lbCountry.TabIndex = 8;
            this.lbCountry.Text = "Country";
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 244);
            this.Controls.Add(this.lbCountry);
            this.Controls.Add(this.lbCity);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lbType);
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search and Filter";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbType;
        private ComboBox cmbType;
        private TextBox txtSearch;
        private ComboBox cmbCountry;
        private ComboBox cmbCity;
        private Button btnDo;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label lbSearch;
        private Label lbCity;
        private Label lbCountry;
    }
}