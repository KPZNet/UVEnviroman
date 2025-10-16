namespace UVEnviroman
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblPythonVersion = new Label();
            cmbPythonVersion = new ComboBox();
            lblLocation = new Label();
            txtLocation = new TextBox();
            btnBrowseLocation = new Button();
            btnCreateEnvironment = new Button();
            txtOutput = new TextBox();
            lblOutput = new Label();
            lblEnvironmentName = new Label();
            txtEnvironmentName = new TextBox();
            btnResetLocation = new Button();
            panelLeft = new Panel();
            panelRight = new Panel();
            splitter = new Splitter();
            tabControl = new TabControl();
            tabCreateEnvironment = new TabPage();
            tabManagePackageSets = new TabPage();
            
            // Package Selection for Create Environment Tab
            cmbPackageSet = new ComboBox();
            lblPackageSet = new Label();
            lblSelectedPackages = new Label();
            lstSelectedPackages = new ListBox();
            
            // Package Set Management Tab
            lblPackageSetName = new Label();
            txtPackageSetName = new TextBox();
            lblPackageSetDescription = new Label();
            txtPackageSetDescription = new TextBox();
            lblManagePackages = new Label();
            txtNewPackage = new TextBox();
            btnAddToSet = new Button();
            lstPackageSetPackages = new ListBox();
            btnRemoveFromSet = new Button();
            btnSavePackageSet = new Button();
            btnDeletePackageSet = new Button();
            cmbExistingPackageSets = new ComboBox();
            lblExistingPackageSets = new Label();
            btnLoadPackageSet = new Button();
            btnNewPackageSet = new Button();
            
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            tabControl.SuspendLayout();
            tabCreateEnvironment.SuspendLayout();
            tabManagePackageSets.SuspendLayout();
            SuspendLayout();
            
            // Left Panel
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Width = 480;
            panelLeft.Padding = new Padding(15);
            panelLeft.BackColor = Color.FromArgb(250, 250, 250);
            panelLeft.Controls.Add(tabControl);
            
            // Tab Control
            tabControl.Dock = DockStyle.Fill;
            tabControl.Controls.Add(tabCreateEnvironment);
            tabControl.Controls.Add(tabManagePackageSets);
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            
            // Create Environment Tab
            tabCreateEnvironment.Text = "Create Environment";
            tabCreateEnvironment.UseVisualStyleBackColor = true;
            tabCreateEnvironment.Padding = new Padding(10);
            tabCreateEnvironment.Controls.Add(btnCreateEnvironment);
            tabCreateEnvironment.Controls.Add(lstSelectedPackages);
            tabCreateEnvironment.Controls.Add(lblSelectedPackages);
            tabCreateEnvironment.Controls.Add(cmbPackageSet);
            tabCreateEnvironment.Controls.Add(lblPackageSet);
            tabCreateEnvironment.Controls.Add(btnResetLocation);
            tabCreateEnvironment.Controls.Add(btnBrowseLocation);
            tabCreateEnvironment.Controls.Add(txtLocation);
            tabCreateEnvironment.Controls.Add(lblLocation);
            tabCreateEnvironment.Controls.Add(txtEnvironmentName);
            tabCreateEnvironment.Controls.Add(lblEnvironmentName);
            tabCreateEnvironment.Controls.Add(cmbPythonVersion);
            tabCreateEnvironment.Controls.Add(lblPythonVersion);
            tabCreateEnvironment.Controls.Add(lblTitle);
            
            // Manage Package Sets Tab
            tabManagePackageSets.Text = "Manage Package Sets";
            tabManagePackageSets.UseVisualStyleBackColor = true;
            tabManagePackageSets.Padding = new Padding(10);
            tabManagePackageSets.Controls.Add(btnNewPackageSet);
            tabManagePackageSets.Controls.Add(btnLoadPackageSet);
            tabManagePackageSets.Controls.Add(lblExistingPackageSets);
            tabManagePackageSets.Controls.Add(cmbExistingPackageSets);
            tabManagePackageSets.Controls.Add(btnDeletePackageSet);
            tabManagePackageSets.Controls.Add(btnSavePackageSet);
            tabManagePackageSets.Controls.Add(btnRemoveFromSet);
            tabManagePackageSets.Controls.Add(lstPackageSetPackages);
            tabManagePackageSets.Controls.Add(btnAddToSet);
            tabManagePackageSets.Controls.Add(txtNewPackage);
            tabManagePackageSets.Controls.Add(lblManagePackages);
            tabManagePackageSets.Controls.Add(txtPackageSetDescription);
            tabManagePackageSets.Controls.Add(lblPackageSetDescription);
            tabManagePackageSets.Controls.Add(txtPackageSetName);
            tabManagePackageSets.Controls.Add(lblPackageSetName);
            
            // Splitter
            splitter.Dock = DockStyle.Left;
            splitter.Width = 4;
            splitter.BackColor = Color.FromArgb(200, 200, 200);
            
            // Right Panel
            panelRight.Dock = DockStyle.Fill;
            panelRight.Padding = new Padding(15);
            panelRight.BackColor = SystemColors.Control;
            panelRight.Controls.Add(txtOutput);
            panelRight.Controls.Add(lblOutput);
            
            // CREATE ENVIRONMENT TAB CONTROLS
            
            // Title
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Text = "UV Python Environment Tool";
            
            // Python Version
            lblPythonVersion.AutoSize = true;
            lblPythonVersion.Location = new Point(0, 50);
            lblPythonVersion.Text = "?? Python Version:";
            
            cmbPythonVersion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPythonVersion.Location = new Point(0, 68);
            cmbPythonVersion.Size = new Size(200, 23);
            cmbPythonVersion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            
            // Environment Name
            lblEnvironmentName.AutoSize = true;
            lblEnvironmentName.Location = new Point(0, 105);
            lblEnvironmentName.Text = "?? Environment Name:";
            
            txtEnvironmentName.Location = new Point(0, 123);
            txtEnvironmentName.Size = new Size(430, 23);
            txtEnvironmentName.Text = "myenv";
            txtEnvironmentName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            
            // Location
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(0, 160);
            lblLocation.Text = "?? Location:";
            
            txtLocation.Location = new Point(0, 178);
            txtLocation.ReadOnly = true;
            txtLocation.Size = new Size(290, 23);
            txtLocation.BackColor = SystemColors.Window;
            txtLocation.BorderStyle = BorderStyle.FixedSingle;
            txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            
            btnBrowseLocation.Location = new Point(296, 177);
            btnBrowseLocation.Size = new Size(70, 25);
            btnBrowseLocation.Text = "Browse...";
            btnBrowseLocation.UseVisualStyleBackColor = true;
            btnBrowseLocation.Click += btnBrowseLocation_Click;
            btnBrowseLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            btnResetLocation.Location = new Point(372, 177);
            btnResetLocation.Size = new Size(58, 25);
            btnResetLocation.Text = "Reset";
            btnResetLocation.UseVisualStyleBackColor = true;
            btnResetLocation.Click += btnResetLocation_Click;
            btnResetLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            // Package Set Selection
            lblPackageSet.AutoSize = true;
            lblPackageSet.Location = new Point(0, 220);
            lblPackageSet.Text = "?? Package Set:";
            
            cmbPackageSet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPackageSet.Location = new Point(0, 238);
            cmbPackageSet.Size = new Size(430, 23);
            cmbPackageSet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbPackageSet.SelectedIndexChanged += cmbPackageSet_SelectedIndexChanged;
            
            // Selected Packages Display
            lblSelectedPackages.AutoSize = true;
            lblSelectedPackages.Location = new Point(0, 275);
            lblSelectedPackages.Text = "?? Selected Packages:";
            
            lstSelectedPackages.Location = new Point(0, 293);
            lstSelectedPackages.Size = new Size(430, 120);
            lstSelectedPackages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstSelectedPackages.BorderStyle = BorderStyle.FixedSingle;
            lstSelectedPackages.BackColor = Color.White;
            
            // Create Environment Button
            btnCreateEnvironment.BackColor = Color.FromArgb(0, 120, 215);
            btnCreateEnvironment.ForeColor = Color.White;
            btnCreateEnvironment.Location = new Point(0, 425);
            btnCreateEnvironment.Size = new Size(180, 40);
            btnCreateEnvironment.Text = "?? Create Environment";
            btnCreateEnvironment.UseVisualStyleBackColor = false;
            btnCreateEnvironment.FlatStyle = FlatStyle.Flat;
            btnCreateEnvironment.Click += btnCreateEnvironment_Click;
            btnCreateEnvironment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCreateEnvironment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            
            // MANAGE PACKAGE SETS TAB CONTROLS
            
            // Existing Package Sets
            lblExistingPackageSets.AutoSize = true;
            lblExistingPackageSets.Location = new Point(0, 0);
            lblExistingPackageSets.Text = "?? Existing Package Sets:";
            
            cmbExistingPackageSets.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExistingPackageSets.Location = new Point(0, 18);
            cmbExistingPackageSets.Size = new Size(280, 23);
            cmbExistingPackageSets.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            
            btnLoadPackageSet.Location = new Point(286, 17);
            btnLoadPackageSet.Size = new Size(70, 25);
            btnLoadPackageSet.Text = "Load";
            btnLoadPackageSet.UseVisualStyleBackColor = true;
            btnLoadPackageSet.Click += btnLoadPackageSet_Click;
            btnLoadPackageSet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            btnNewPackageSet.Location = new Point(362, 17);
            btnNewPackageSet.Size = new Size(68, 25);
            btnNewPackageSet.Text = "New";
            btnNewPackageSet.UseVisualStyleBackColor = true;
            btnNewPackageSet.Click += btnNewPackageSet_Click;
            btnNewPackageSet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            // Package Set Name
            lblPackageSetName.AutoSize = true;
            lblPackageSetName.Location = new Point(0, 60);
            lblPackageSetName.Text = "Name:";
            
            txtPackageSetName.Location = new Point(0, 78);
            txtPackageSetName.Size = new Size(430, 23);
            txtPackageSetName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            
            // Package Set Description
            lblPackageSetDescription.AutoSize = true;
            lblPackageSetDescription.Location = new Point(0, 115);
            lblPackageSetDescription.Text = "Description:";
            
            txtPackageSetDescription.Location = new Point(0, 133);
            txtPackageSetDescription.Size = new Size(430, 23);
            txtPackageSetDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            
            // Package Management
            lblManagePackages.AutoSize = true;
            lblManagePackages.Location = new Point(0, 170);
            lblManagePackages.Text = "Packages:";
            
            txtNewPackage.Location = new Point(0, 188);
            txtNewPackage.Size = new Size(280, 23);
            txtNewPackage.PlaceholderText = "Enter package name";
            txtNewPackage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNewPackage.KeyPress += txtNewPackage_KeyPress;
            
            btnAddToSet.Location = new Point(286, 187);
            btnAddToSet.Size = new Size(70, 25);
            btnAddToSet.Text = "Add";
            btnAddToSet.UseVisualStyleBackColor = true;
            btnAddToSet.Click += btnAddToSet_Click;
            btnAddToSet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            btnRemoveFromSet.Location = new Point(362, 187);
            btnRemoveFromSet.Size = new Size(68, 25);
            btnRemoveFromSet.Text = "Remove";
            btnRemoveFromSet.UseVisualStyleBackColor = true;
            btnRemoveFromSet.Click += btnRemoveFromSet_Click;
            btnRemoveFromSet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            lstPackageSetPackages.Location = new Point(0, 218);
            lstPackageSetPackages.Size = new Size(430, 140);
            lstPackageSetPackages.SelectionMode = SelectionMode.MultiExtended;
            lstPackageSetPackages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstPackageSetPackages.BorderStyle = BorderStyle.FixedSingle;
            lstPackageSetPackages.BackColor = Color.White;
            
            // Save/Delete Buttons
            btnSavePackageSet.BackColor = Color.FromArgb(40, 167, 69);
            btnSavePackageSet.ForeColor = Color.White;
            btnSavePackageSet.Location = new Point(0, 375);
            btnSavePackageSet.Size = new Size(100, 35);
            btnSavePackageSet.Text = "?? Save";
            btnSavePackageSet.UseVisualStyleBackColor = false;
            btnSavePackageSet.FlatStyle = FlatStyle.Flat;
            btnSavePackageSet.Click += btnSavePackageSet_Click;
            btnSavePackageSet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            
            btnDeletePackageSet.BackColor = Color.FromArgb(220, 53, 69);
            btnDeletePackageSet.ForeColor = Color.White;
            btnDeletePackageSet.Location = new Point(110, 375);
            btnDeletePackageSet.Size = new Size(100, 35);
            btnDeletePackageSet.Text = "??? Delete";
            btnDeletePackageSet.UseVisualStyleBackColor = false;
            btnDeletePackageSet.FlatStyle = FlatStyle.Flat;
            btnDeletePackageSet.Click += btnDeletePackageSet_Click;
            btnDeletePackageSet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            
            // Output Section
            lblOutput.AutoSize = true;
            lblOutput.Location = new Point(0, 0);
            lblOutput.Text = "?? Output:";
            
            txtOutput.Location = new Point(0, 18);
            txtOutput.Multiline = true;
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Both;
            txtOutput.Font = new Font("Consolas", 9F, FontStyle.Regular);
            txtOutput.BackColor = Color.FromArgb(248, 249, 250);
            txtOutput.Dock = DockStyle.Fill;
            txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            
            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            MinimumSize = new Size(800, 500);
            Controls.Add(panelRight);
            Controls.Add(splitter);
            Controls.Add(panelLeft);
            Text = "UV Python Environment Manager";
            Load += Form1_Load;
            Resize += Form1_Resize;
            
            panelLeft.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            tabControl.ResumeLayout(false);
            tabCreateEnvironment.ResumeLayout(false);
            tabCreateEnvironment.PerformLayout();
            tabManagePackageSets.ResumeLayout(false);
            tabManagePackageSets.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblPythonVersion;
        private ComboBox cmbPythonVersion;
        private Label lblLocation;
        private TextBox txtLocation;
        private Button btnBrowseLocation;
        private Button btnCreateEnvironment;
        private TextBox txtOutput;
        private Label lblOutput;
        private Label lblEnvironmentName;
        private TextBox txtEnvironmentName;
        private Button btnResetLocation;
        private Panel panelLeft;
        private Panel panelRight;
        private Splitter splitter;
        
        // Tab Control
        private TabControl tabControl;
        private TabPage tabCreateEnvironment;
        private TabPage tabManagePackageSets;
        
        // Package Set Selection
        private ComboBox cmbPackageSet;
        private Label lblPackageSet;
        private Label lblSelectedPackages;
        private ListBox lstSelectedPackages;
        
        // Package Set Management
        private Label lblPackageSetName;
        private TextBox txtPackageSetName;
        private Label lblPackageSetDescription;
        private TextBox txtPackageSetDescription;
        private Label lblManagePackages;
        private TextBox txtNewPackage;
        private Button btnAddToSet;
        private ListBox lstPackageSetPackages;
        private Button btnRemoveFromSet;
        private Button btnSavePackageSet;
        private Button btnDeletePackageSet;
        private ComboBox cmbExistingPackageSets;
        private Label lblExistingPackageSets;
        private Button btnLoadPackageSet;
        private Button btnNewPackageSet;
    }
}
