namespace ETCTool
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTab = new MaterialSkin.Controls.MaterialTabControl();
            this.TabMain = new System.Windows.Forms.TabPage();
            this.MainTabFileDecryptStation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.CheckFileDecrypt = new MaterialSkin.Controls.MaterialCheckBox();
            this.AutoRunMode = new MaterialSkin.Controls.MaterialCheckBox();
            this.MainTabAutoSaveStation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.MainTabPlmStation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.MainTabClipbrdStation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.CheckCaxaFuntion = new MaterialSkin.Controls.MaterialCheckBox();
            this.CheckPlmFuntion = new MaterialSkin.Controls.MaterialCheckBox();
            this.CheckClipbrdFuntion = new MaterialSkin.Controls.MaterialCheckBox();
            this.StartAllFuntion = new MaterialSkin.Controls.MaterialRaisedButton();
            this.TabCaxa = new System.Windows.Forms.TabPage();
            this.Buttom_StartCaxaAutoSave = new MaterialSkin.Controls.MaterialFlatButton();
            this.Buttom_StartCaxaClipbrd = new MaterialSkin.Controls.MaterialFlatButton();
            this.TabPlm = new System.Windows.Forms.TabPage();
            this.TabAnother = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.Notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyContextMenuStrip = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.ShowForm = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyStartRun = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitClose = new System.Windows.Forms.ToolStripMenuItem();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.MainTab.SuspendLayout();
            this.TabMain.SuspendLayout();
            this.TabCaxa.SuspendLayout();
            this.TabAnother.SuspendLayout();
            this.NotifyContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Controls.Add(this.TabMain);
            this.MainTab.Controls.Add(this.TabCaxa);
            this.MainTab.Controls.Add(this.TabPlm);
            this.MainTab.Controls.Add(this.TabAnother);
            this.MainTab.Depth = 0;
            this.MainTab.Location = new System.Drawing.Point(2, 100);
            this.MainTab.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(478, 183);
            this.MainTab.TabIndex = 0;
            // 
            // TabMain
            // 
            this.TabMain.BackColor = System.Drawing.Color.White;
            this.TabMain.Controls.Add(this.MainTabFileDecryptStation);
            this.TabMain.Controls.Add(this.materialLabel4);
            this.TabMain.Controls.Add(this.CheckFileDecrypt);
            this.TabMain.Controls.Add(this.AutoRunMode);
            this.TabMain.Controls.Add(this.MainTabAutoSaveStation);
            this.TabMain.Controls.Add(this.MainTabPlmStation);
            this.TabMain.Controls.Add(this.MainTabClipbrdStation);
            this.TabMain.Controls.Add(this.materialLabel3);
            this.TabMain.Controls.Add(this.materialLabel2);
            this.TabMain.Controls.Add(this.materialLabel1);
            this.TabMain.Controls.Add(this.CheckCaxaFuntion);
            this.TabMain.Controls.Add(this.CheckPlmFuntion);
            this.TabMain.Controls.Add(this.CheckClipbrdFuntion);
            this.TabMain.Controls.Add(this.StartAllFuntion);
            this.TabMain.Location = new System.Drawing.Point(4, 22);
            this.TabMain.Name = "TabMain";
            this.TabMain.Size = new System.Drawing.Size(470, 157);
            this.TabMain.TabIndex = 3;
            this.TabMain.Text = "主界面";
            // 
            // MainTabFileDecryptStation
            // 
            this.MainTabFileDecryptStation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabFileDecryptStation.Depth = 0;
            this.MainTabFileDecryptStation.Hint = "";
            this.MainTabFileDecryptStation.Location = new System.Drawing.Point(233, 149);
            this.MainTabFileDecryptStation.MaxLength = 32767;
            this.MainTabFileDecryptStation.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTabFileDecryptStation.Name = "MainTabFileDecryptStation";
            this.MainTabFileDecryptStation.PasswordChar = '\0';
            this.MainTabFileDecryptStation.SelectedText = "";
            this.MainTabFileDecryptStation.SelectionLength = 0;
            this.MainTabFileDecryptStation.SelectionStart = 0;
            this.MainTabFileDecryptStation.Size = new System.Drawing.Size(229, 23);
            this.MainTabFileDecryptStation.TabIndex = 13;
            this.MainTabFileDecryptStation.TabStop = false;
            this.MainTabFileDecryptStation.Text = "等待";
            this.MainTabFileDecryptStation.UseSystemPasswordChar = false;
            this.MainTabFileDecryptStation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainTabMainTabFileDecryptStationStation_MouseClick);
            this.MainTabFileDecryptStation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainTabMainTabFileDecryptStationStation_MouseDoubleClick);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(183, 151);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(45, 19);
            this.materialLabel4.TabIndex = 12;
            this.materialLabel4.Text = "状态:";
            // 
            // CheckFileDecrypt
            // 
            this.CheckFileDecrypt.AutoSize = true;
            this.CheckFileDecrypt.Depth = 0;
            this.CheckFileDecrypt.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckFileDecrypt.Location = new System.Drawing.Point(6, 145);
            this.CheckFileDecrypt.Margin = new System.Windows.Forms.Padding(0);
            this.CheckFileDecrypt.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckFileDecrypt.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckFileDecrypt.Name = "CheckFileDecrypt";
            this.CheckFileDecrypt.Ripple = true;
            this.CheckFileDecrypt.Size = new System.Drawing.Size(151, 30);
            this.CheckFileDecrypt.TabIndex = 11;
            this.CheckFileDecrypt.Text = "启动文件解密功能";
            this.CheckFileDecrypt.UseVisualStyleBackColor = true;
            this.CheckFileDecrypt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckFileDecrypt_MouseClick);
            // 
            // AutoRunMode
            // 
            this.AutoRunMode.AutoSize = true;
            this.AutoRunMode.Depth = 0;
            this.AutoRunMode.Font = new System.Drawing.Font("Roboto", 10F);
            this.AutoRunMode.Location = new System.Drawing.Point(151, 9);
            this.AutoRunMode.Margin = new System.Windows.Forms.Padding(0);
            this.AutoRunMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AutoRunMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.AutoRunMode.Name = "AutoRunMode";
            this.AutoRunMode.Ripple = true;
            this.AutoRunMode.Size = new System.Drawing.Size(121, 30);
            this.AutoRunMode.TabIndex = 10;
            this.AutoRunMode.Text = "开机自动自动";
            this.AutoRunMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AutoRunMode.UseVisualStyleBackColor = true;
            this.AutoRunMode.Click += new System.EventHandler(this.RunMode_Click);
            // 
            // MainTabAutoSaveStation
            // 
            this.MainTabAutoSaveStation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabAutoSaveStation.Depth = 0;
            this.MainTabAutoSaveStation.Hint = "";
            this.MainTabAutoSaveStation.Location = new System.Drawing.Point(233, 83);
            this.MainTabAutoSaveStation.MaxLength = 32767;
            this.MainTabAutoSaveStation.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTabAutoSaveStation.Name = "MainTabAutoSaveStation";
            this.MainTabAutoSaveStation.PasswordChar = '\0';
            this.MainTabAutoSaveStation.SelectedText = "";
            this.MainTabAutoSaveStation.SelectionLength = 0;
            this.MainTabAutoSaveStation.SelectionStart = 0;
            this.MainTabAutoSaveStation.Size = new System.Drawing.Size(229, 23);
            this.MainTabAutoSaveStation.TabIndex = 9;
            this.MainTabAutoSaveStation.TabStop = false;
            this.MainTabAutoSaveStation.Text = "等待";
            this.MainTabAutoSaveStation.UseSystemPasswordChar = false;
            this.MainTabAutoSaveStation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainTabClipbrdStation_MouseClick);
            this.MainTabAutoSaveStation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainTabClipbrdStation_MouseDoubleClick);
            // 
            // MainTabPlmStation
            // 
            this.MainTabPlmStation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabPlmStation.Depth = 0;
            this.MainTabPlmStation.Hint = "";
            this.MainTabPlmStation.Location = new System.Drawing.Point(233, 116);
            this.MainTabPlmStation.MaxLength = 32767;
            this.MainTabPlmStation.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTabPlmStation.Name = "MainTabPlmStation";
            this.MainTabPlmStation.PasswordChar = '\0';
            this.MainTabPlmStation.SelectedText = "";
            this.MainTabPlmStation.SelectionLength = 0;
            this.MainTabPlmStation.SelectionStart = 0;
            this.MainTabPlmStation.Size = new System.Drawing.Size(229, 23);
            this.MainTabPlmStation.TabIndex = 8;
            this.MainTabPlmStation.TabStop = false;
            this.MainTabPlmStation.Text = "等待";
            this.MainTabPlmStation.UseSystemPasswordChar = false;
            this.MainTabPlmStation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainTabPlmStation_MouseClick);
            this.MainTabPlmStation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainTabPlmStation_MouseDoubleClick);
            // 
            // MainTabClipbrdStation
            // 
            this.MainTabClipbrdStation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabClipbrdStation.Depth = 0;
            this.MainTabClipbrdStation.Hint = "";
            this.MainTabClipbrdStation.Location = new System.Drawing.Point(233, 50);
            this.MainTabClipbrdStation.MaxLength = 32767;
            this.MainTabClipbrdStation.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTabClipbrdStation.Name = "MainTabClipbrdStation";
            this.MainTabClipbrdStation.PasswordChar = '\0';
            this.MainTabClipbrdStation.SelectedText = "";
            this.MainTabClipbrdStation.SelectionLength = 0;
            this.MainTabClipbrdStation.SelectionStart = 0;
            this.MainTabClipbrdStation.Size = new System.Drawing.Size(229, 23);
            this.MainTabClipbrdStation.TabIndex = 7;
            this.MainTabClipbrdStation.TabStop = false;
            this.MainTabClipbrdStation.Text = "等待";
            this.MainTabClipbrdStation.UseSystemPasswordChar = false;
            this.MainTabClipbrdStation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainTabClipbrdStation_MouseClick);
            this.MainTabClipbrdStation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainTabClipbrdStation_MouseDoubleClick);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(183, 118);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(45, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "状态:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(183, 85);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(45, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "状态:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(183, 52);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(45, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "状态:";
            // 
            // CheckCaxaFuntion
            // 
            this.CheckCaxaFuntion.AutoSize = true;
            this.CheckCaxaFuntion.Depth = 0;
            this.CheckCaxaFuntion.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckCaxaFuntion.Location = new System.Drawing.Point(6, 79);
            this.CheckCaxaFuntion.Margin = new System.Windows.Forms.Padding(0);
            this.CheckCaxaFuntion.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckCaxaFuntion.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckCaxaFuntion.Name = "CheckCaxaFuntion";
            this.CheckCaxaFuntion.Ripple = true;
            this.CheckCaxaFuntion.Size = new System.Drawing.Size(157, 30);
            this.CheckCaxaFuntion.TabIndex = 3;
            this.CheckCaxaFuntion.Text = "启动CAXA自动保存";
            this.CheckCaxaFuntion.UseVisualStyleBackColor = true;
            this.CheckCaxaFuntion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckCaxaFuntion_MouseClick);
            // 
            // CheckPlmFuntion
            // 
            this.CheckPlmFuntion.AutoSize = true;
            this.CheckPlmFuntion.Depth = 0;
            this.CheckPlmFuntion.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckPlmFuntion.Location = new System.Drawing.Point(6, 112);
            this.CheckPlmFuntion.Margin = new System.Windows.Forms.Padding(0);
            this.CheckPlmFuntion.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckPlmFuntion.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckPlmFuntion.Name = "CheckPlmFuntion";
            this.CheckPlmFuntion.Ripple = true;
            this.CheckPlmFuntion.Size = new System.Drawing.Size(119, 30);
            this.CheckPlmFuntion.TabIndex = 2;
            this.CheckPlmFuntion.Text = "启动PLM监控";
            this.CheckPlmFuntion.UseVisualStyleBackColor = true;
            this.CheckPlmFuntion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckPlmFuntion_MouseClick);
            // 
            // CheckClipbrdFuntion
            // 
            this.CheckClipbrdFuntion.AutoSize = true;
            this.CheckClipbrdFuntion.Depth = 0;
            this.CheckClipbrdFuntion.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckClipbrdFuntion.Location = new System.Drawing.Point(6, 46);
            this.CheckClipbrdFuntion.Margin = new System.Windows.Forms.Padding(0);
            this.CheckClipbrdFuntion.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckClipbrdFuntion.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckClipbrdFuntion.Name = "CheckClipbrdFuntion";
            this.CheckClipbrdFuntion.Ripple = true;
            this.CheckClipbrdFuntion.Size = new System.Drawing.Size(172, 30);
            this.CheckClipbrdFuntion.TabIndex = 1;
            this.CheckClipbrdFuntion.Text = "启动CAXA剪切板监控";
            this.CheckClipbrdFuntion.UseVisualStyleBackColor = true;
            this.CheckClipbrdFuntion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckClipbrdFuntion_MouseClick);
            // 
            // StartAllFuntion
            // 
            this.StartAllFuntion.AutoSize = true;
            this.StartAllFuntion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartAllFuntion.Depth = 0;
            this.StartAllFuntion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.StartAllFuntion.Icon = null;
            this.StartAllFuntion.Location = new System.Drawing.Point(6, 3);
            this.StartAllFuntion.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartAllFuntion.Name = "StartAllFuntion";
            this.StartAllFuntion.Primary = true;
            this.StartAllFuntion.Size = new System.Drawing.Size(142, 36);
            this.StartAllFuntion.TabIndex = 0;
            this.StartAllFuntion.Text = "启动下列勾选功能";
            this.StartAllFuntion.UseVisualStyleBackColor = true;
            this.StartAllFuntion.Click += new System.EventHandler(this.StartAllFuntion_Click);
            this.StartAllFuntion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StartAllFuntion_MouseClick);
            // 
            // TabCaxa
            // 
            this.TabCaxa.Controls.Add(this.Buttom_StartCaxaAutoSave);
            this.TabCaxa.Controls.Add(this.Buttom_StartCaxaClipbrd);
            this.TabCaxa.Location = new System.Drawing.Point(4, 22);
            this.TabCaxa.Name = "TabCaxa";
            this.TabCaxa.Padding = new System.Windows.Forms.Padding(3);
            this.TabCaxa.Size = new System.Drawing.Size(470, 157);
            this.TabCaxa.TabIndex = 0;
            this.TabCaxa.Text = "CAXA相关";
            this.TabCaxa.UseVisualStyleBackColor = true;
            // 
            // Buttom_StartCaxaAutoSave
            // 
            this.Buttom_StartCaxaAutoSave.AutoSize = true;
            this.Buttom_StartCaxaAutoSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Buttom_StartCaxaAutoSave.BackColor = System.Drawing.Color.DimGray;
            this.Buttom_StartCaxaAutoSave.Depth = 0;
            this.Buttom_StartCaxaAutoSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Buttom_StartCaxaAutoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Buttom_StartCaxaAutoSave.Icon = ((System.Drawing.Image)(resources.GetObject("Buttom_StartCaxaAutoSave.Icon")));
            this.Buttom_StartCaxaAutoSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buttom_StartCaxaAutoSave.Location = new System.Drawing.Point(7, 57);
            this.Buttom_StartCaxaAutoSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Buttom_StartCaxaAutoSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.Buttom_StartCaxaAutoSave.Name = "Buttom_StartCaxaAutoSave";
            this.Buttom_StartCaxaAutoSave.Primary = false;
            this.Buttom_StartCaxaAutoSave.Size = new System.Drawing.Size(206, 36);
            this.Buttom_StartCaxaAutoSave.TabIndex = 2;
            this.Buttom_StartCaxaAutoSave.Text = "启动Caxa自动保存功能";
            this.Buttom_StartCaxaAutoSave.UseCompatibleTextRendering = true;
            this.Buttom_StartCaxaAutoSave.UseVisualStyleBackColor = false;
            this.Buttom_StartCaxaAutoSave.TextChanged += new System.EventHandler(this.Buttom_TextChanged);
            this.Buttom_StartCaxaAutoSave.Click += new System.EventHandler(this.Buttom_Click);
            // 
            // Buttom_StartCaxaClipbrd
            // 
            this.Buttom_StartCaxaClipbrd.AutoSize = true;
            this.Buttom_StartCaxaClipbrd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Buttom_StartCaxaClipbrd.BackColor = System.Drawing.Color.DimGray;
            this.Buttom_StartCaxaClipbrd.Depth = 0;
            this.Buttom_StartCaxaClipbrd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Buttom_StartCaxaClipbrd.Icon = ((System.Drawing.Image)(resources.GetObject("Buttom_StartCaxaClipbrd.Icon")));
            this.Buttom_StartCaxaClipbrd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buttom_StartCaxaClipbrd.Location = new System.Drawing.Point(7, 9);
            this.Buttom_StartCaxaClipbrd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Buttom_StartCaxaClipbrd.MouseState = MaterialSkin.MouseState.HOVER;
            this.Buttom_StartCaxaClipbrd.Name = "Buttom_StartCaxaClipbrd";
            this.Buttom_StartCaxaClipbrd.Primary = false;
            this.Buttom_StartCaxaClipbrd.Size = new System.Drawing.Size(191, 36);
            this.Buttom_StartCaxaClipbrd.TabIndex = 1;
            this.Buttom_StartCaxaClipbrd.Text = "启动Caxa剪切板监控";
            this.Buttom_StartCaxaClipbrd.UseCompatibleTextRendering = true;
            this.Buttom_StartCaxaClipbrd.UseVisualStyleBackColor = false;
            this.Buttom_StartCaxaClipbrd.TextChanged += new System.EventHandler(this.Buttom_TextChanged);
            this.Buttom_StartCaxaClipbrd.Click += new System.EventHandler(this.Buttom_Click);
            // 
            // TabPlm
            // 
            this.TabPlm.Location = new System.Drawing.Point(4, 22);
            this.TabPlm.Name = "TabPlm";
            this.TabPlm.Padding = new System.Windows.Forms.Padding(3);
            this.TabPlm.Size = new System.Drawing.Size(470, 157);
            this.TabPlm.TabIndex = 1;
            this.TabPlm.Text = "PLM相关";
            this.TabPlm.UseVisualStyleBackColor = true;
            // 
            // TabAnother
            // 
            this.TabAnother.Controls.Add(this.materialRaisedButton1);
            this.TabAnother.Location = new System.Drawing.Point(4, 22);
            this.TabAnother.Name = "TabAnother";
            this.TabAnother.Size = new System.Drawing.Size(470, 157);
            this.TabAnother.TabIndex = 2;
            this.TabAnother.Text = "其他相关";
            this.TabAnother.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.MainTab;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 63);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(480, 31);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // Notify
            // 
            this.Notify.ContextMenuStrip = this.NotifyContextMenuStrip;
            this.Notify.Icon = ((System.Drawing.Icon)(resources.GetObject("Notify.Icon")));
            this.Notify.Text = "ETC工具集合";
            this.Notify.Visible = true;
            this.Notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Notify_MouseDoubleClick);
            // 
            // NotifyContextMenuStrip
            // 
            this.NotifyContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NotifyContextMenuStrip.Depth = 0;
            this.NotifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowForm,
            this.NotifyStartRun,
            this.ExitClose});
            this.NotifyContextMenuStrip.MouseState = MaterialSkin.MouseState.HOVER;
            this.NotifyContextMenuStrip.Name = "NotifyContextMenuStrip";
            this.NotifyContextMenuStrip.Size = new System.Drawing.Size(149, 70);
            // 
            // ShowForm
            // 
            this.ShowForm.Name = "ShowForm";
            this.ShowForm.Size = new System.Drawing.Size(180, 22);
            this.ShowForm.Text = "显示主窗口";
            this.ShowForm.Click += new System.EventHandler(this.ShowForm_Click);
            // 
            // NotifyStartRun
            // 
            this.NotifyStartRun.Image = ((System.Drawing.Image)(resources.GetObject("NotifyStartRun.Image")));
            this.NotifyStartRun.Name = "NotifyStartRun";
            this.NotifyStartRun.Size = new System.Drawing.Size(180, 22);
            this.NotifyStartRun.Text = "启动勾选功能";
            this.NotifyStartRun.Click += new System.EventHandler(this.Buttom_Click);
            this.NotifyStartRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotifyStartRun_MouseDown);
            this.NotifyStartRun.TextChanged += new System.EventHandler(this.Buttom_TextChanged);
            // 
            // ExitClose
            // 
            this.ExitClose.Name = "ExitClose";
            this.ExitClose.Size = new System.Drawing.Size(180, 22);
            this.ExitClose.Text = "退出";
            this.ExitClose.Click += new System.EventHandler(this.ExitClose_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(6, 3);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(127, 36);
            this.materialRaisedButton1.TabIndex = 0;
            this.materialRaisedButton1.Text = "删除自启动服务";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.DeleteAutoRunService_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 280);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.materialTabSelector1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(480, 280);
            this.Name = "MainForm";
            this.Text = "工具集合";
            this.MainTab.ResumeLayout(false);
            this.TabMain.ResumeLayout(false);
            this.TabMain.PerformLayout();
            this.TabCaxa.ResumeLayout(false);
            this.TabCaxa.PerformLayout();
            this.TabAnother.ResumeLayout(false);
            this.TabAnother.PerformLayout();
            this.NotifyContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl MainTab;
        private System.Windows.Forms.TabPage TabCaxa;
        private System.Windows.Forms.TabPage TabPlm;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.TabPage TabAnother;
        private System.Windows.Forms.TabPage TabMain;
        private MaterialSkin.Controls.MaterialRaisedButton StartAllFuntion;
        private MaterialSkin.Controls.MaterialCheckBox CheckCaxaFuntion;
        private MaterialSkin.Controls.MaterialCheckBox CheckPlmFuntion;
        private MaterialSkin.Controls.MaterialCheckBox CheckClipbrdFuntion;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField MainTabClipbrdStation;
        private MaterialSkin.Controls.MaterialSingleLineTextField MainTabPlmStation;
        private MaterialSkin.Controls.MaterialSingleLineTextField MainTabAutoSaveStation;
        private MaterialSkin.Controls.MaterialCheckBox AutoRunMode;
        private System.Windows.Forms.NotifyIcon Notify;
        private MaterialSkin.Controls.MaterialSingleLineTextField MainTabFileDecryptStation;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialCheckBox CheckFileDecrypt;
        private MaterialSkin.Controls.MaterialFlatButton Buttom_StartCaxaClipbrd;
        private MaterialSkin.Controls.MaterialFlatButton Buttom_StartCaxaAutoSave;
        private MaterialSkin.Controls.MaterialContextMenuStrip NotifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ShowForm;
        private System.Windows.Forms.ToolStripMenuItem NotifyStartRun;
        private System.Windows.Forms.ToolStripMenuItem ExitClose;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}