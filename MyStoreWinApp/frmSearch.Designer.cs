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
            this.SuspendLayout();
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(34, 24);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(40, 20);
            this.lbType.TabIndex = 0;
            this.lbType.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Search by ID and Name",
            "Fillter by City and Country",
            "Sort descending order by MemberName"});
            this.cmbType.Location = new System.Drawing.Point(115, 21);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(165, 28);
            this.cmbType.TabIndex = 1;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(51, 88);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(152, 27);
            this.txtSearch.TabIndex = 2;
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(51, 194);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(152, 28);
            this.cmbCountry.TabIndex = 3;
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.cmbCountry_SelectedIndexChanged);
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(51, 139);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(152, 28);
            this.cmbCity.TabIndex = 4;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedIndexChanged);
            // 
            // btnDo
            // 
            this.btnDo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDo.Location = new System.Drawing.Point(165, 280);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(137, 54);
            this.btnDo.TabIndex = 5;
            this.btnDo.Text = "Do";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 375);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lbType);
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "function";
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
    }
}