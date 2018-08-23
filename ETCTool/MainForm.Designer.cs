﻿namespace ETCTool
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
            this.MainTab = new MaterialSkin.Controls.MaterialTabControl();
            this.TabMain = new System.Windows.Forms.TabPage();
            this.TabClipbrd = new System.Windows.Forms.TabPage();
            this.TabPlm = new System.Windows.Forms.TabPage();
            this.TabAutoSave = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.StartAllFuntion = new MaterialSkin.Controls.MaterialRaisedButton();
            this.CheckClipbrdFuntion = new MaterialSkin.Controls.MaterialCheckBox();
            this.CheckPlmFuntion = new MaterialSkin.Controls.MaterialCheckBox();
            this.CheckCaxaFuntion = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.MainTabClipbrdStation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.MainTabPlmStation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.MainTabAutoSaveStation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.RunMode = new MaterialSkin.Controls.MaterialCheckBox();
            this.MainTab.SuspendLayout();
            this.TabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Controls.Add(this.TabMain);
            this.MainTab.Controls.Add(this.TabClipbrd);
            this.MainTab.Controls.Add(this.TabPlm);
            this.MainTab.Controls.Add(this.TabAutoSave);
            this.MainTab.Depth = 0;
            this.MainTab.Location = new System.Drawing.Point(2, 100);
            this.MainTab.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(518, 183);
            this.MainTab.TabIndex = 0;
            // 
            // TabMain
            // 
            this.TabMain.BackColor = System.Drawing.Color.White;
            this.TabMain.Controls.Add(this.RunMode);
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
            this.TabMain.Size = new System.Drawing.Size(510, 157);
            this.TabMain.TabIndex = 3;
            this.TabMain.Text = "主界面";
            // 
            // TabClipbrd
            // 
            this.TabClipbrd.Location = new System.Drawing.Point(4, 22);
            this.TabClipbrd.Name = "TabClipbrd";
            this.TabClipbrd.Padding = new System.Windows.Forms.Padding(3);
            this.TabClipbrd.Size = new System.Drawing.Size(510, 157);
            this.TabClipbrd.TabIndex = 0;
            this.TabClipbrd.Text = "CAXA剪切板";
            this.TabClipbrd.UseVisualStyleBackColor = true;
            // 
            // TabPlm
            // 
            this.TabPlm.Location = new System.Drawing.Point(4, 22);
            this.TabPlm.Name = "TabPlm";
            this.TabPlm.Padding = new System.Windows.Forms.Padding(3);
            this.TabPlm.Size = new System.Drawing.Size(490, 157);
            this.TabPlm.TabIndex = 1;
            this.TabPlm.Text = "PLM相关";
            this.TabPlm.UseVisualStyleBackColor = true;
            // 
            // TabAutoSave
            // 
            this.TabAutoSave.Location = new System.Drawing.Point(4, 22);
            this.TabAutoSave.Name = "TabAutoSave";
            this.TabAutoSave.Size = new System.Drawing.Size(510, 157);
            this.TabAutoSave.TabIndex = 2;
            this.TabAutoSave.Text = "Caxa自动保存";
            this.TabAutoSave.UseVisualStyleBackColor = true;
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
            this.materialTabSelector1.Size = new System.Drawing.Size(520, 31);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // StartAllFuntion
            // 
            this.StartAllFuntion.AutoSize = true;
            this.StartAllFuntion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartAllFuntion.Depth = 0;
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
            // CheckPlmFuntion
            // 
            this.CheckPlmFuntion.AutoSize = true;
            this.CheckPlmFuntion.Depth = 0;
            this.CheckPlmFuntion.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckPlmFuntion.Location = new System.Drawing.Point(6, 80);
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
            // CheckCaxaFuntion
            // 
            this.CheckCaxaFuntion.AutoSize = true;
            this.CheckCaxaFuntion.Depth = 0;
            this.CheckCaxaFuntion.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckCaxaFuntion.Location = new System.Drawing.Point(6, 114);
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
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(184, 52);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(42, 18);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "状态:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(184, 86);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(42, 18);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "状态:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(184, 120);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(45, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "状态:";
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
            this.MainTabClipbrdStation.Size = new System.Drawing.Size(269, 23);
            this.MainTabClipbrdStation.TabIndex = 7;
            this.MainTabClipbrdStation.TabStop = false;
            this.MainTabClipbrdStation.Text = "等待";
            this.MainTabClipbrdStation.UseSystemPasswordChar = false;
            this.MainTabClipbrdStation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainTabClipbrdStation_MouseClick);
            this.MainTabClipbrdStation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainTabClipbrdStation_MouseDoubleClick);
            // 
            // MainTabPlmStation
            // 
            this.MainTabPlmStation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabPlmStation.Depth = 0;
            this.MainTabPlmStation.Hint = "";
            this.MainTabPlmStation.Location = new System.Drawing.Point(233, 84);
            this.MainTabPlmStation.MaxLength = 32767;
            this.MainTabPlmStation.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTabPlmStation.Name = "MainTabPlmStation";
            this.MainTabPlmStation.PasswordChar = '\0';
            this.MainTabPlmStation.SelectedText = "";
            this.MainTabPlmStation.SelectionLength = 0;
            this.MainTabPlmStation.SelectionStart = 0;
            this.MainTabPlmStation.Size = new System.Drawing.Size(269, 23);
            this.MainTabPlmStation.TabIndex = 8;
            this.MainTabPlmStation.TabStop = false;
            this.MainTabPlmStation.Text = "等待";
            this.MainTabPlmStation.UseSystemPasswordChar = false;
            this.MainTabPlmStation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainTabPlmStation_MouseClick);
            this.MainTabPlmStation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainTabPlmStation_MouseDoubleClick);
            // 
            // MainTabAutoSaveStation
            // 
            this.MainTabAutoSaveStation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabAutoSaveStation.Depth = 0;
            this.MainTabAutoSaveStation.Hint = "";
            this.MainTabAutoSaveStation.Location = new System.Drawing.Point(233, 118);
            this.MainTabAutoSaveStation.MaxLength = 32767;
            this.MainTabAutoSaveStation.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTabAutoSaveStation.Name = "MainTabAutoSaveStation";
            this.MainTabAutoSaveStation.PasswordChar = '\0';
            this.MainTabAutoSaveStation.SelectedText = "";
            this.MainTabAutoSaveStation.SelectionLength = 0;
            this.MainTabAutoSaveStation.SelectionStart = 0;
            this.MainTabAutoSaveStation.Size = new System.Drawing.Size(269, 23);
            this.MainTabAutoSaveStation.TabIndex = 9;
            this.MainTabAutoSaveStation.TabStop = false;
            this.MainTabAutoSaveStation.Text = "等待";
            this.MainTabAutoSaveStation.UseSystemPasswordChar = false;
            this.MainTabAutoSaveStation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainTabAutoSaveStation_MouseClick);
            this.MainTabAutoSaveStation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainTabAutoSaveStation_MouseDoubleClick);
            // 
            // RunMode
            // 
            this.RunMode.AutoSize = true;
            this.RunMode.Depth = 0;
            this.RunMode.Font = new System.Drawing.Font("Roboto", 10F);
            this.RunMode.Location = new System.Drawing.Point(151, 9);
            this.RunMode.Margin = new System.Windows.Forms.Padding(0);
            this.RunMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RunMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.RunMode.Name = "RunMode";
            this.RunMode.Ripple = true;
            this.RunMode.Size = new System.Drawing.Size(121, 30);
            this.RunMode.TabIndex = 10;
            this.RunMode.Text = "开机自动自动";
            this.RunMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RunMode.UseVisualStyleBackColor = true;
            this.RunMode.CheckedChanged += new System.EventHandler(this.RunMode_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 280);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.materialTabSelector1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(520, 280);
            this.Name = "MainForm";
            this.Text = "工具集合";
            this.MainTab.ResumeLayout(false);
            this.TabMain.ResumeLayout(false);
            this.TabMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl MainTab;
        private System.Windows.Forms.TabPage TabClipbrd;
        private System.Windows.Forms.TabPage TabPlm;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.TabPage TabAutoSave;
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
        private MaterialSkin.Controls.MaterialCheckBox RunMode;
    }
}