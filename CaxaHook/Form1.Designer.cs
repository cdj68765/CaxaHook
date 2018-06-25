namespace CaxaHook
{
    partial class Form1
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
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn6 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn7 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn8 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn9 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            VisualPlus.Toolkit.Child.VisualListViewColumn visualListViewColumn10 = new VisualPlus.Toolkit.Child.VisualListViewColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SelectSavePath = new VisualPlus.Toolkit.Controls.Editors.VisualTextBox();
            this.visualSeparator1 = new VisualPlus.Toolkit.Controls.Layout.VisualSeparator();
            this.visualButton1 = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.TimeSpanNum = new VisualPlus.Toolkit.Controls.Interactivity.VisualNumericUpDown();
            this.Time_Span_Label = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.TimeSpanBar = new VisualPlus.Toolkit.Controls.DataVisualization.VisualProgressBar();
            this.RunOrStop = new VisualPlus.Toolkit.Controls.Interactivity.VisualToggle();
            this.visualLabel1 = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.PIDLabel = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.HookAddress = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.visualTabControl1 = new VisualPlus.Toolkit.Controls.Navigation.VisualTabControl();
            this.visualTabPage1 = new VisualPlus.Toolkit.Child.VisualTabPage();
            this.LogListBox = new VisualPlus.Toolkit.Controls.DataManagement.VisualListBox();
            this.visualTabPage2 = new VisualPlus.Toolkit.Child.VisualTabPage();
            this.AutoSaveList = new VisualPlus.Toolkit.Controls.DataManagement.VisualListViewEx();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.visualTabPage3 = new VisualPlus.Toolkit.Child.VisualTabPage();
            this.visualPanel1 = new VisualPlus.Toolkit.Controls.Layout.VisualPanel();
            this.OpenSaveFolder = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.OpenLast = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.CleanAllFile = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.visualLabel2 = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.visualLabel3 = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.ALLSAVECOUNT = new System.Windows.Forms.TextBox();
            this.OneSaveCount = new System.Windows.Forms.TextBox();
            this.visualTabControl1.SuspendLayout();
            this.visualTabPage1.SuspendLayout();
            this.visualTabPage2.SuspendLayout();
            this.visualTabPage3.SuspendLayout();
            this.visualPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectSavePath
            // 
            this.SelectSavePath.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SelectSavePath.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.SelectSavePath.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.SelectSavePath.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.SelectSavePath.Border.HoverVisible = true;
            this.SelectSavePath.Border.Rounding = 6;
            this.SelectSavePath.Border.Thickness = 1;
            this.SelectSavePath.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.SelectSavePath.Border.Visible = true;
            this.SelectSavePath.ButtonBorder.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.SelectSavePath.ButtonBorder.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.SelectSavePath.ButtonBorder.HoverVisible = true;
            this.SelectSavePath.ButtonBorder.Rounding = 6;
            this.SelectSavePath.ButtonBorder.Thickness = 1;
            this.SelectSavePath.ButtonBorder.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.SelectSavePath.ButtonBorder.Visible = true;
            this.SelectSavePath.ButtonColor.Disabled = System.Drawing.Color.Empty;
            this.SelectSavePath.ButtonColor.Enabled = System.Drawing.Color.Empty;
            this.SelectSavePath.ButtonColor.Hover = System.Drawing.Color.Empty;
            this.SelectSavePath.ButtonColor.Pressed = System.Drawing.Color.Empty;
            this.SelectSavePath.ButtonFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectSavePath.ButtonIndent = 3;
            this.SelectSavePath.ButtonText = "浏览";
            this.SelectSavePath.ButtonVisible = true;
            this.SelectSavePath.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.SelectSavePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SelectSavePath.ImageSize = new System.Drawing.Size(16, 16);
            this.SelectSavePath.ImageVisible = false;
            this.SelectSavePath.ImageWidth = 35;
            this.SelectSavePath.Location = new System.Drawing.Point(22, 75);
            this.SelectSavePath.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.SelectSavePath.Name = "SelectSavePath";
            this.SelectSavePath.PasswordChar = '\0';
            this.SelectSavePath.ReadOnly = true;
            this.SelectSavePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectSavePath.Size = new System.Drawing.Size(165, 25);
            this.SelectSavePath.TabIndex = 1;
            this.SelectSavePath.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.SelectSavePath.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SelectSavePath.TextStyle.Hover = System.Drawing.Color.Empty;
            this.SelectSavePath.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.SelectSavePath.Watermark.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SelectSavePath.Watermark.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.SelectSavePath.Watermark.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.SelectSavePath.Watermark.Text = "";
            this.SelectSavePath.Watermark.Visible = false;
            this.SelectSavePath.ButtonClicked += new VisualPlus.Toolkit.Controls.Editors.VisualTextBox.ButtonClickedEventHandler(this.SeletSaveButton);
            // 
            // visualSeparator1
            // 
            this.visualSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.visualSeparator1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualSeparator1.Line = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.visualSeparator1.Location = new System.Drawing.Point(200, 38);
            this.visualSeparator1.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualSeparator1.Name = "visualSeparator1";
            this.visualSeparator1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.visualSeparator1.Shadow = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.visualSeparator1.ShadowVisible = false;
            this.visualSeparator1.Size = new System.Drawing.Size(4, 270);
            this.visualSeparator1.TabIndex = 2;
            this.visualSeparator1.Text = "visualSeparator1";
            this.visualSeparator1.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualSeparator1.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualSeparator1.TextStyle.Hover = System.Drawing.Color.Empty;
            this.visualSeparator1.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // visualButton1
            // 
            this.visualButton1.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.visualButton1.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.visualButton1.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.visualButton1.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.visualButton1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.visualButton1.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.visualButton1.Border.HoverVisible = true;
            this.visualButton1.Border.Rounding = 6;
            this.visualButton1.Border.Thickness = 1;
            this.visualButton1.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.visualButton1.Border.Visible = true;
            this.visualButton1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualButton1.Image = null;
            this.visualButton1.Location = new System.Drawing.Point(22, 39);
            this.visualButton1.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualButton1.Name = "visualButton1";
            this.visualButton1.Size = new System.Drawing.Size(85, 30);
            this.visualButton1.TabIndex = 3;
            this.visualButton1.Text = "选择保存目录";
            this.visualButton1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.visualButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.visualButton1.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualButton1.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualButton1.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualButton1.TextStyle.Hover = System.Drawing.Color.Empty;
            this.visualButton1.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.visualButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SeletSaveButton);
            // 
            // TimeSpanNum
            // 
            this.TimeSpanNum.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TimeSpanNum.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TimeSpanNum.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TimeSpanNum.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.TimeSpanNum.Border.HoverVisible = true;
            this.TimeSpanNum.Border.Rounding = 6;
            this.TimeSpanNum.Border.Thickness = 1;
            this.TimeSpanNum.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.TimeSpanNum.Border.Visible = true;
            this.TimeSpanNum.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TimeSpanNum.ButtonFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.TimeSpanNum.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TimeSpanNum.ButtonOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.TimeSpanNum.ButtonWidth = 50;
            this.TimeSpanNum.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.TimeSpanNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TimeSpanNum.Location = new System.Drawing.Point(103, 111);
            this.TimeSpanNum.MaximumValue = ((long)(100));
            this.TimeSpanNum.MinimumValue = ((long)(1));
            this.TimeSpanNum.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.TimeSpanNum.Name = "TimeSpanNum";
            this.TimeSpanNum.Separator = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TimeSpanNum.Size = new System.Drawing.Size(84, 25);
            this.TimeSpanNum.TabIndex = 5;
            this.TimeSpanNum.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.TimeSpanNum.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TimeSpanNum.TextStyle.Hover = System.Drawing.Color.Empty;
            this.TimeSpanNum.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.TimeSpanNum.Value = ((long)(1));
            this.TimeSpanNum.ValueChanged += new VisualPlus.Delegates.ValueChangedEventHandler(this.TimeSpanNum_ValueChanged);
            // 
            // Time_Span_Label
            // 
            this.Time_Span_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.Time_Span_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Time_Span_Label.Location = new System.Drawing.Point(22, 108);
            this.Time_Span_Label.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.Time_Span_Label.Name = "Time_Span_Label";
            this.Time_Span_Label.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.Time_Span_Label.Outline = false;
            this.Time_Span_Label.OutlineColor = System.Drawing.Color.Red;
            this.Time_Span_Label.OutlineLocation = new System.Drawing.Point(0, 0);
            this.Time_Span_Label.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Time_Span_Label.ReflectionSpacing = 0;
            this.Time_Span_Label.ShadowColor = System.Drawing.Color.Black;
            this.Time_Span_Label.ShadowDirection = 315;
            this.Time_Span_Label.ShadowLocation = new System.Drawing.Point(0, 0);
            this.Time_Span_Label.ShadowOpacity = 100;
            this.Time_Span_Label.Size = new System.Drawing.Size(75, 30);
            this.Time_Span_Label.TabIndex = 6;
            this.Time_Span_Label.Text = "保存间隔(分)";
            this.Time_Span_Label.TextAlignment = System.Drawing.StringAlignment.Near;
            this.Time_Span_Label.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.Time_Span_Label.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.Time_Span_Label.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Time_Span_Label.TextStyle.Hover = System.Drawing.Color.Empty;
            this.Time_Span_Label.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // TimeSpanBar
            // 
            this.TimeSpanBar.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TimeSpanBar.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TimeSpanBar.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TimeSpanBar.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.TimeSpanBar.Border.HoverVisible = true;
            this.TimeSpanBar.Border.Rounding = 6;
            this.TimeSpanBar.Border.Thickness = 1;
            this.TimeSpanBar.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.TimeSpanBar.Border.Visible = true;
            this.TimeSpanBar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.TimeSpanBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TimeSpanBar.Hatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TimeSpanBar.Hatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TimeSpanBar.Hatch.Size = new System.Drawing.Size(2, 2);
            this.TimeSpanBar.Hatch.Style = System.Drawing.Drawing2D.HatchStyle.LightDownwardDiagonal;
            this.TimeSpanBar.Hatch.Visible = true;
            this.TimeSpanBar.LargeChange = 5;
            this.TimeSpanBar.Location = new System.Drawing.Point(22, 287);
            this.TimeSpanBar.MarqueeWidth = 20;
            this.TimeSpanBar.Maximum = 100;
            this.TimeSpanBar.Minimum = 0;
            this.TimeSpanBar.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.TimeSpanBar.Name = "TimeSpanBar";
            this.TimeSpanBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TimeSpanBar.PercentageVisible = false;
            this.TimeSpanBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(136)))), ((int)(((byte)(45)))));
            this.TimeSpanBar.ProgressImage = null;
            this.TimeSpanBar.Size = new System.Drawing.Size(165, 20);
            this.TimeSpanBar.SmallChange = 1;
            this.TimeSpanBar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.TimeSpanBar.TabIndex = 7;
            this.TimeSpanBar.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.TimeSpanBar.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TimeSpanBar.TextStyle.Hover = System.Drawing.Color.Empty;
            this.TimeSpanBar.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.TimeSpanBar.Value = 0;
            this.TimeSpanBar.ValueAlignment = System.Drawing.StringAlignment.Center;
            // 
            // RunOrStop
            // 
            this.RunOrStop.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RunOrStop.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RunOrStop.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.RunOrStop.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.RunOrStop.Border.HoverVisible = true;
            this.RunOrStop.Border.Rounding = 20;
            this.RunOrStop.Border.Thickness = 1;
            this.RunOrStop.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.RunOrStop.Border.Visible = true;
            this.RunOrStop.ButtonBorder.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.RunOrStop.ButtonBorder.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.RunOrStop.ButtonBorder.HoverVisible = true;
            this.RunOrStop.ButtonBorder.Rounding = 18;
            this.RunOrStop.ButtonBorder.Thickness = 1;
            this.RunOrStop.ButtonBorder.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.RunOrStop.ButtonBorder.Visible = true;
            this.RunOrStop.ButtonColorState.Disabled = System.Drawing.Color.Red;
            this.RunOrStop.ButtonColorState.Enabled = System.Drawing.Color.Red;
            this.RunOrStop.ButtonColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RunOrStop.ButtonColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.RunOrStop.ButtonSize = new System.Drawing.Size(20, 20);
            this.RunOrStop.Enabled = false;
            this.RunOrStop.FalseTextToggle = "";
            this.RunOrStop.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.RunOrStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RunOrStop.Location = new System.Drawing.Point(103, 140);
            this.RunOrStop.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.RunOrStop.Name = "RunOrStop";
            this.RunOrStop.ProgressImage = null;
            this.RunOrStop.Size = new System.Drawing.Size(55, 25);
            this.RunOrStop.TabIndex = 8;
            this.RunOrStop.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.RunOrStop.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RunOrStop.TextStyle.Hover = System.Drawing.Color.Empty;
            this.RunOrStop.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.RunOrStop.TrueTextToggle = "";
            this.RunOrStop.Type = VisualPlus.Toolkit.Controls.Interactivity.VisualToggle.ToggleTypes.OnOff;
            this.RunOrStop.ToggleChanged += new VisualPlus.Delegates.ToggleChangedEventHandler(this.RunOrStop_ToggleChanged);
            // 
            // visualLabel1
            // 
            this.visualLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.visualLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.Location = new System.Drawing.Point(61, 137);
            this.visualLabel1.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualLabel1.Name = "visualLabel1";
            this.visualLabel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.visualLabel1.Outline = false;
            this.visualLabel1.OutlineColor = System.Drawing.Color.Red;
            this.visualLabel1.OutlineLocation = new System.Drawing.Point(0, 0);
            this.visualLabel1.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.ReflectionSpacing = 0;
            this.visualLabel1.ShadowColor = System.Drawing.Color.Black;
            this.visualLabel1.ShadowDirection = 315;
            this.visualLabel1.ShadowLocation = new System.Drawing.Point(0, 0);
            this.visualLabel1.ShadowOpacity = 100;
            this.visualLabel1.Size = new System.Drawing.Size(36, 30);
            this.visualLabel1.TabIndex = 9;
            this.visualLabel1.Text = "运行:";
            this.visualLabel1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.visualLabel1.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel1.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualLabel1.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel1.TextStyle.Hover = System.Drawing.Color.Empty;
            this.visualLabel1.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // PIDLabel
            // 
            this.PIDLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PIDLabel.ForeColor = System.Drawing.Color.Red;
            this.PIDLabel.Location = new System.Drawing.Point(22, 170);
            this.PIDLabel.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.PIDLabel.Name = "PIDLabel";
            this.PIDLabel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.PIDLabel.Outline = false;
            this.PIDLabel.OutlineColor = System.Drawing.Color.Red;
            this.PIDLabel.OutlineLocation = new System.Drawing.Point(0, 0);
            this.PIDLabel.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PIDLabel.ReflectionSpacing = 0;
            this.PIDLabel.ShadowColor = System.Drawing.Color.Black;
            this.PIDLabel.ShadowDirection = 315;
            this.PIDLabel.ShadowLocation = new System.Drawing.Point(0, 0);
            this.PIDLabel.ShadowOpacity = 100;
            this.PIDLabel.Size = new System.Drawing.Size(165, 23);
            this.PIDLabel.TabIndex = 10;
            this.PIDLabel.Text = "CAXA PID：";
            this.PIDLabel.TextAlignment = System.Drawing.StringAlignment.Near;
            this.PIDLabel.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.PIDLabel.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.PIDLabel.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PIDLabel.TextStyle.Hover = System.Drawing.Color.Empty;
            this.PIDLabel.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // HookAddress
            // 
            this.HookAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.HookAddress.ForeColor = System.Drawing.Color.Red;
            this.HookAddress.Location = new System.Drawing.Point(22, 199);
            this.HookAddress.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.HookAddress.Name = "HookAddress";
            this.HookAddress.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.HookAddress.Outline = false;
            this.HookAddress.OutlineColor = System.Drawing.Color.Red;
            this.HookAddress.OutlineLocation = new System.Drawing.Point(0, 0);
            this.HookAddress.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HookAddress.ReflectionSpacing = 0;
            this.HookAddress.ShadowColor = System.Drawing.Color.Black;
            this.HookAddress.ShadowDirection = 315;
            this.HookAddress.ShadowLocation = new System.Drawing.Point(0, 0);
            this.HookAddress.ShadowOpacity = 100;
            this.HookAddress.Size = new System.Drawing.Size(165, 23);
            this.HookAddress.TabIndex = 11;
            this.HookAddress.Text = "Hook Address：";
            this.HookAddress.TextAlignment = System.Drawing.StringAlignment.Near;
            this.HookAddress.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.HookAddress.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.HookAddress.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HookAddress.TextStyle.Hover = System.Drawing.Color.Empty;
            this.HookAddress.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "打开目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // visualTabControl1
            // 
            this.visualTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visualTabControl1.Controls.Add(this.visualTabPage1);
            this.visualTabControl1.Controls.Add(this.visualTabPage2);
            this.visualTabControl1.Controls.Add(this.visualTabPage3);
            this.visualTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.visualTabControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualTabControl1.ItemSize = new System.Drawing.Size(100, 25);
            this.visualTabControl1.Location = new System.Drawing.Point(210, 39);
            this.visualTabControl1.MinimumSize = new System.Drawing.Size(144, 85);
            this.visualTabControl1.Name = "visualTabControl1";
            this.visualTabControl1.SelectedIndex = 0;
            this.visualTabControl1.SelectorAlignment = System.Windows.Forms.TabAlignment.Bottom;
            this.visualTabControl1.SelectorSpacing = 10;
            this.visualTabControl1.SelectorThickness = 5;
            this.visualTabControl1.SelectorType = VisualPlus.Toolkit.Controls.Navigation.VisualTabControl.SelectorTypes.Arrow;
            this.visualTabControl1.SelectorVisible = true;
            this.visualTabControl1.Separator = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.visualTabControl1.SeparatorSpacing = 2;
            this.visualTabControl1.SeparatorThickness = 2F;
            this.visualTabControl1.Size = new System.Drawing.Size(427, 268);
            this.visualTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.visualTabControl1.State = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualTabControl1.TabIndex = 13;
            this.visualTabControl1.TabMenu = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.visualTabControl1.TabSelector = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.visualTabControl1.TextRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // visualTabPage1
            // 
            this.visualTabPage1.BackColor = System.Drawing.Color.Transparent;
            this.visualTabPage1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.visualTabPage1.Border.Rounding = 6;
            this.visualTabPage1.Border.Thickness = 1;
            this.visualTabPage1.Border.Type = VisualPlus.Enumerators.ShapeType.Rectangle;
            this.visualTabPage1.Border.Visible = false;
            this.visualTabPage1.Controls.Add(this.LogListBox);
            this.visualTabPage1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualTabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(181)))), ((int)(((byte)(187)))));
            this.visualTabPage1.HeaderImage = null;
            this.visualTabPage1.Image = null;
            this.visualTabPage1.ImageSize = new System.Drawing.Size(16, 16);
            this.visualTabPage1.Location = new System.Drawing.Point(4, 29);
            this.visualTabPage1.Name = "visualTabPage1";
            this.visualTabPage1.Size = new System.Drawing.Size(419, 235);
            this.visualTabPage1.TabHover = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.visualTabPage1.TabIndex = 0;
            this.visualTabPage1.TabNormal = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.visualTabPage1.TabSelected = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(76)))), ((int)(((byte)(88)))));
            this.visualTabPage1.Text = "日志";
            this.visualTabPage1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.visualTabPage1.TextImageRelation = VisualPlus.Toolkit.Child.VisualTabPage.TextImageRelations.Text;
            this.visualTabPage1.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualTabPage1.TextSelected = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            // 
            // LogListBox
            // 
            this.LogListBox.AlternateColors = false;
            this.LogListBox.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.LogListBox.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.LogListBox.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.LogListBox.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.LogListBox.Border.HoverVisible = true;
            this.LogListBox.Border.Rounding = 6;
            this.LogListBox.Border.Thickness = 1;
            this.LogListBox.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.LogListBox.Border.Visible = true;
            this.LogListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogListBox.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.LogListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LogListBox.ItemAlternate = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(13)))));
            this.LogListBox.ItemHeight = 18;
            this.LogListBox.ItemLineAlignment = System.Drawing.StringAlignment.Center;
            this.LogListBox.ItemNormal = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.LogListBox.ItemSelected = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.LogListBox.Location = new System.Drawing.Point(0, 0);
            this.LogListBox.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(419, 235);
            this.LogListBox.TabIndex = 0;
            this.LogListBox.Text = "visualListBox1";
            this.LogListBox.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.LogListBox.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LogListBox.TextStyle.Hover = System.Drawing.Color.Empty;
            this.LogListBox.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // visualTabPage2
            // 
            this.visualTabPage2.BackColor = System.Drawing.Color.Transparent;
            this.visualTabPage2.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.visualTabPage2.Border.Rounding = 6;
            this.visualTabPage2.Border.Thickness = 1;
            this.visualTabPage2.Border.Type = VisualPlus.Enumerators.ShapeType.Rectangle;
            this.visualTabPage2.Border.Visible = false;
            this.visualTabPage2.Controls.Add(this.AutoSaveList);
            this.visualTabPage2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualTabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(181)))), ((int)(((byte)(187)))));
            this.visualTabPage2.HeaderImage = null;
            this.visualTabPage2.Image = null;
            this.visualTabPage2.ImageSize = new System.Drawing.Size(16, 16);
            this.visualTabPage2.Location = new System.Drawing.Point(4, 29);
            this.visualTabPage2.Name = "visualTabPage2";
            this.visualTabPage2.Size = new System.Drawing.Size(419, 235);
            this.visualTabPage2.TabHover = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.visualTabPage2.TabIndex = 1;
            this.visualTabPage2.TabNormal = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.visualTabPage2.TabSelected = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(76)))), ((int)(((byte)(88)))));
            this.visualTabPage2.Text = "自动保存历史";
            this.visualTabPage2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.visualTabPage2.TextImageRelation = VisualPlus.Toolkit.Child.VisualTabPage.TextImageRelations.Text;
            this.visualTabPage2.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualTabPage2.TextSelected = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            // 
            // AutoSaveList
            // 
            this.AutoSaveList.AllowColumnResize = true;
            this.AutoSaveList.AlternateBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(13)))));
            this.AutoSaveList.AlternatingColors = false;
            this.AutoSaveList.AutoHeight = true;
            this.AutoSaveList.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.AutoSaveList.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.AutoSaveList.BackgroundStretchToFit = true;
            this.AutoSaveList.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.AutoSaveList.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.AutoSaveList.Border.HoverVisible = true;
            this.AutoSaveList.Border.Rounding = 6;
            this.AutoSaveList.Border.Thickness = 1;
            this.AutoSaveList.Border.Type = VisualPlus.Enumerators.ShapeType.Rectangle;
            this.AutoSaveList.Border.Visible = true;
            visualListViewColumn6.CheckBox = false;
            visualListViewColumn6.CheckBoxes = false;
            visualListViewColumn6.Checked = false;
            visualListViewColumn6.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.TextBox;
            visualListViewColumn6.ImageIndex = 2;
            visualListViewColumn6.Name = "VisualListViewColumn1";
            visualListViewColumn6.NumericSort = false;
            visualListViewColumn6.Text = "保存时间";
            visualListViewColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            visualListViewColumn6.Width = 150;
            visualListViewColumn7.CheckBox = false;
            visualListViewColumn7.CheckBoxes = false;
            visualListViewColumn7.Checked = false;
            visualListViewColumn7.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.None;
            visualListViewColumn7.ImageIndex = 1;
            visualListViewColumn7.Name = "VisualListViewColumn2";
            visualListViewColumn7.NumericSort = false;
            visualListViewColumn7.Text = "记录数量";
            visualListViewColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            visualListViewColumn7.Width = 80;
            visualListViewColumn8.CheckBox = false;
            visualListViewColumn8.CheckBoxes = false;
            visualListViewColumn8.Checked = false;
            visualListViewColumn8.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.TextBox;
            visualListViewColumn8.ImageIndex = 0;
            visualListViewColumn8.Name = "VisualListViewColumn3";
            visualListViewColumn8.NumericSort = true;
            visualListViewColumn8.Text = "文档名";
            visualListViewColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            visualListViewColumn8.Width = 150;
            visualListViewColumn9.CheckBox = false;
            visualListViewColumn9.CheckBoxes = false;
            visualListViewColumn9.Checked = false;
            visualListViewColumn9.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.None;
            visualListViewColumn9.ImageIndex = 3;
            visualListViewColumn9.Name = "VisualListViewColumn4";
            visualListViewColumn9.NumericSort = false;
            visualListViewColumn9.Text = "剩余";
            visualListViewColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            visualListViewColumn9.Width = 100;
            visualListViewColumn10.CheckBox = false;
            visualListViewColumn10.CheckBoxes = false;
            visualListViewColumn10.Checked = false;
            visualListViewColumn10.EmbeddedType = VisualPlus.Enumerators.LVActivatedEmbeddedTypes.None;
            visualListViewColumn10.ImageIndex = -1;
            visualListViewColumn10.Name = "VisualListViewColumn1";
            visualListViewColumn10.NumericSort = false;
            visualListViewColumn10.Text = "最后一次保存";
            visualListViewColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            visualListViewColumn10.Width = 256;
            this.AutoSaveList.Columns.AddRange(new VisualPlus.Toolkit.Child.VisualListViewColumn[] {
            visualListViewColumn6,
            visualListViewColumn7,
            visualListViewColumn8,
            visualListViewColumn9,
            visualListViewColumn10});
            this.AutoSaveList.ControlStyle = VisualPlus.Enumerators.LVControlStyles.SuperFlat;
            this.AutoSaveList.CornerBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.AutoSaveList.DisplayText = "";
            this.AutoSaveList.DisplayTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.AutoSaveList.DisplayTextFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.AutoSaveList.DisplayTextOnEmpty = true;
            this.AutoSaveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutoSaveList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.AutoSaveList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AutoSaveList.FullRowSelect = true;
            this.AutoSaveList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.AutoSaveList.GridLines = VisualPlus.Enumerators.GridLines.Both;
            this.AutoSaveList.GridLineStyle = VisualPlus.Enumerators.GridLineStyle.Solid;
            this.AutoSaveList.GridTypes = VisualPlus.Enumerators.GridTypes.Normal;
            this.AutoSaveList.HeaderHeight = 22;
            this.AutoSaveList.HeaderVisible = true;
            this.AutoSaveList.HeaderWordWrap = false;
            this.AutoSaveList.HoverColumnTracking = true;
            this.AutoSaveList.HoverEvents = false;
            this.AutoSaveList.HoverItemTracking = true;
            this.AutoSaveList.HoverTime = 1;
            this.AutoSaveList.HoverTrackingColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.AutoSaveList.ImageListColumns = this.imageList1;
            this.AutoSaveList.ImageListItems = this.imageList2;
            this.AutoSaveList.ItemHeight = 20;
            this.AutoSaveList.ItemSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.AutoSaveList.ItemSelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AutoSaveList.ItemWordWrap = true;
            this.AutoSaveList.Location = new System.Drawing.Point(0, 0);
            this.AutoSaveList.MouseState = VisualPlus.Enumerators.MouseStates.Hover;
            this.AutoSaveList.MultiSelect = false;
            this.AutoSaveList.Name = "AutoSaveList";
            this.AutoSaveList.Selectable = true;
            this.AutoSaveList.Size = new System.Drawing.Size(419, 235);
            this.AutoSaveList.SortType = VisualPlus.Enumerators.SortTypes.QuickSort;
            this.AutoSaveList.SuperFlatHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.AutoSaveList.TabIndex = 0;
            this.AutoSaveList.Text = "visualListViewEx1";
            this.AutoSaveList.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.AutoSaveList.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AutoSaveList.TextStyle.Hover = System.Drawing.Color.Empty;
            this.AutoSaveList.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "layout_content.png");
            this.imageList1.Images.SetKeyName(1, "title_window.png");
            this.imageList1.Images.SetKeyName(2, "date.png");
            this.imageList1.Images.SetKeyName(3, "progressbar.png");
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // visualTabPage3
            // 
            this.visualTabPage3.BackColor = System.Drawing.Color.Transparent;
            this.visualTabPage3.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.visualTabPage3.Border.Rounding = 6;
            this.visualTabPage3.Border.Thickness = 1;
            this.visualTabPage3.Border.Type = VisualPlus.Enumerators.ShapeType.Rectangle;
            this.visualTabPage3.Border.Visible = false;
            this.visualTabPage3.Controls.Add(this.visualPanel1);
            this.visualTabPage3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualTabPage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(181)))), ((int)(((byte)(187)))));
            this.visualTabPage3.HeaderImage = null;
            this.visualTabPage3.Image = null;
            this.visualTabPage3.ImageSize = new System.Drawing.Size(16, 16);
            this.visualTabPage3.Location = new System.Drawing.Point(4, 29);
            this.visualTabPage3.Name = "visualTabPage3";
            this.visualTabPage3.Size = new System.Drawing.Size(419, 235);
            this.visualTabPage3.TabHover = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(38)))));
            this.visualTabPage3.TabIndex = 2;
            this.visualTabPage3.TabNormal = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.visualTabPage3.TabSelected = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(76)))), ((int)(((byte)(88)))));
            this.visualTabPage3.Text = "设置及其他功能";
            this.visualTabPage3.TextAlignment = System.Drawing.StringAlignment.Center;
            this.visualTabPage3.TextImageRelation = VisualPlus.Toolkit.Child.VisualTabPage.TextImageRelations.Text;
            this.visualTabPage3.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualTabPage3.TextSelected = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            // 
            // visualPanel1
            // 
            this.visualPanel1.BackColor = System.Drawing.Color.White;
            this.visualPanel1.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.visualPanel1.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.visualPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.visualPanel1.Border.Color = System.Drawing.Color.White;
            this.visualPanel1.Border.HoverColor = System.Drawing.Color.White;
            this.visualPanel1.Border.HoverVisible = true;
            this.visualPanel1.Border.Rounding = 6;
            this.visualPanel1.Border.Thickness = 1;
            this.visualPanel1.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.visualPanel1.Border.Visible = true;
            this.visualPanel1.Controls.Add(this.OneSaveCount);
            this.visualPanel1.Controls.Add(this.ALLSAVECOUNT);
            this.visualPanel1.Controls.Add(this.visualLabel3);
            this.visualPanel1.Controls.Add(this.visualLabel2);
            this.visualPanel1.Controls.Add(this.CleanAllFile);
            this.visualPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.visualPanel1.ForeColor = System.Drawing.Color.White;
            this.visualPanel1.Location = new System.Drawing.Point(0, 0);
            this.visualPanel1.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualPanel1.Name = "visualPanel1";
            this.visualPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.visualPanel1.Size = new System.Drawing.Size(419, 235);
            this.visualPanel1.TabIndex = 0;
            this.visualPanel1.Text = "visualPanel1";
            this.visualPanel1.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualPanel1.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualPanel1.TextStyle.Hover = System.Drawing.Color.Empty;
            this.visualPanel1.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // OpenSaveFolder
            // 
            this.OpenSaveFolder.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OpenSaveFolder.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.OpenSaveFolder.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OpenSaveFolder.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.OpenSaveFolder.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.OpenSaveFolder.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.OpenSaveFolder.Border.HoverVisible = true;
            this.OpenSaveFolder.Border.Rounding = 6;
            this.OpenSaveFolder.Border.Thickness = 1;
            this.OpenSaveFolder.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.OpenSaveFolder.Border.Visible = true;
            this.OpenSaveFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.OpenSaveFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OpenSaveFolder.Image = null;
            this.OpenSaveFolder.Location = new System.Drawing.Point(22, 228);
            this.OpenSaveFolder.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.OpenSaveFolder.Name = "OpenSaveFolder";
            this.OpenSaveFolder.Size = new System.Drawing.Size(136, 24);
            this.OpenSaveFolder.TabIndex = 14;
            this.OpenSaveFolder.Text = "打开保存目录";
            this.OpenSaveFolder.TextAlignment = System.Drawing.StringAlignment.Center;
            this.OpenSaveFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.OpenSaveFolder.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.OpenSaveFolder.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.OpenSaveFolder.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OpenSaveFolder.TextStyle.Hover = System.Drawing.Color.Empty;
            this.OpenSaveFolder.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.OpenSaveFolder.Click += new System.EventHandler(this.OpenSaveFolder_Click);
            // 
            // OpenLast
            // 
            this.OpenLast.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OpenLast.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.OpenLast.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OpenLast.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.OpenLast.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.OpenLast.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.OpenLast.Border.HoverVisible = true;
            this.OpenLast.Border.Rounding = 6;
            this.OpenLast.Border.Thickness = 1;
            this.OpenLast.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.OpenLast.Border.Visible = true;
            this.OpenLast.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.OpenLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OpenLast.Image = null;
            this.OpenLast.Location = new System.Drawing.Point(22, 258);
            this.OpenLast.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.OpenLast.Name = "OpenLast";
            this.OpenLast.Size = new System.Drawing.Size(136, 24);
            this.OpenLast.TabIndex = 15;
            this.OpenLast.Text = "打开最后一次保存";
            this.OpenLast.TextAlignment = System.Drawing.StringAlignment.Center;
            this.OpenLast.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.OpenLast.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.OpenLast.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.OpenLast.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OpenLast.TextStyle.Hover = System.Drawing.Color.Empty;
            this.OpenLast.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.OpenLast.Click += new System.EventHandler(this.OpenLast_Click);
            // 
            // CleanAllFile
            // 
            this.CleanAllFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CleanAllFile.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CleanAllFile.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CleanAllFile.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CleanAllFile.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CleanAllFile.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.CleanAllFile.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.CleanAllFile.Border.HoverVisible = true;
            this.CleanAllFile.Border.Rounding = 6;
            this.CleanAllFile.Border.Thickness = 1;
            this.CleanAllFile.Border.Type = VisualPlus.Enumerators.ShapeType.Rounded;
            this.CleanAllFile.Border.Visible = true;
            this.CleanAllFile.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.CleanAllFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CleanAllFile.Image = null;
            this.CleanAllFile.Location = new System.Drawing.Point(23, 8);
            this.CleanAllFile.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.CleanAllFile.Name = "CleanAllFile";
            this.CleanAllFile.Size = new System.Drawing.Size(136, 24);
            this.CleanAllFile.TabIndex = 15;
            this.CleanAllFile.Text = "清空所有保存文件";
            this.CleanAllFile.TextAlignment = System.Drawing.StringAlignment.Center;
            this.CleanAllFile.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.CleanAllFile.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.CleanAllFile.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.CleanAllFile.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CleanAllFile.TextStyle.Hover = System.Drawing.Color.Empty;
            this.CleanAllFile.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.CleanAllFile.Click += new System.EventHandler(this.CleanAllFile_Click);
            // 
            // visualLabel2
            // 
            this.visualLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.visualLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.visualLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel2.Location = new System.Drawing.Point(23, 40);
            this.visualLabel2.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualLabel2.Name = "visualLabel2";
            this.visualLabel2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.visualLabel2.Outline = false;
            this.visualLabel2.OutlineColor = System.Drawing.Color.Red;
            this.visualLabel2.OutlineLocation = new System.Drawing.Point(0, 0);
            this.visualLabel2.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel2.ReflectionSpacing = 0;
            this.visualLabel2.ShadowColor = System.Drawing.Color.Black;
            this.visualLabel2.ShadowDirection = 315;
            this.visualLabel2.ShadowLocation = new System.Drawing.Point(0, 0);
            this.visualLabel2.ShadowOpacity = 100;
            this.visualLabel2.Size = new System.Drawing.Size(107, 30);
            this.visualLabel2.TabIndex = 16;
            this.visualLabel2.Text = "总数最大保存数:";
            this.visualLabel2.TextAlignment = System.Drawing.StringAlignment.Near;
            this.visualLabel2.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel2.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualLabel2.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel2.TextStyle.Hover = System.Drawing.Color.Empty;
            this.visualLabel2.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // visualLabel3
            // 
            this.visualLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.visualLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.visualLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel3.Location = new System.Drawing.Point(23, 76);
            this.visualLabel3.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualLabel3.Name = "visualLabel3";
            this.visualLabel3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.visualLabel3.Outline = false;
            this.visualLabel3.OutlineColor = System.Drawing.Color.Red;
            this.visualLabel3.OutlineLocation = new System.Drawing.Point(0, 0);
            this.visualLabel3.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel3.ReflectionSpacing = 0;
            this.visualLabel3.ShadowColor = System.Drawing.Color.Black;
            this.visualLabel3.ShadowDirection = 315;
            this.visualLabel3.ShadowLocation = new System.Drawing.Point(0, 0);
            this.visualLabel3.ShadowOpacity = 100;
            this.visualLabel3.Size = new System.Drawing.Size(107, 30);
            this.visualLabel3.TabIndex = 22;
            this.visualLabel3.Text = "单文档最大保存数:";
            this.visualLabel3.TextAlignment = System.Drawing.StringAlignment.Near;
            this.visualLabel3.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualLabel3.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualLabel3.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualLabel3.TextStyle.Hover = System.Drawing.Color.Empty;
            this.visualLabel3.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // ALLSAVECOUNT
            // 
            this.ALLSAVECOUNT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ALLSAVECOUNT.Location = new System.Drawing.Point(136, 44);
            this.ALLSAVECOUNT.Name = "ALLSAVECOUNT";
            this.ALLSAVECOUNT.Size = new System.Drawing.Size(55, 22);
            this.ALLSAVECOUNT.TabIndex = 23;
            this.ALLSAVECOUNT.Text = "100";
            this.ALLSAVECOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ALLSAVECOUNT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MoreThanZeroNumCheck);
            // 
            // OneSaveCount
            // 
            this.OneSaveCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.OneSaveCount.Location = new System.Drawing.Point(136, 80);
            this.OneSaveCount.Name = "OneSaveCount";
            this.OneSaveCount.Size = new System.Drawing.Size(55, 22);
            this.OneSaveCount.TabIndex = 24;
            this.OneSaveCount.Text = "100";
            this.OneSaveCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OneSaveCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MoreThanZeroNumCheck);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.Border.HoverVisible = false;
            this.Border.Rounding = 6;
            this.Border.Thickness = 3;
            this.Border.Type = VisualPlus.Enumerators.ShapeType.Rectangle;
            this.Border.Visible = true;
            this.ClientSize = new System.Drawing.Size(640, 320);
            // 
            // 
            // 
            this.ControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBox.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ControlBox.HelpButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.HelpButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.HelpButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.HelpButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.HelpButton.BoxType = VisualPlus.Structure.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.HelpButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.HelpButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.HelpButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.HelpButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.HelpButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.ControlBox.HelpButton.Location = new System.Drawing.Point(0, 0);
            this.ControlBox.HelpButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.HelpButton.Name = "";
            this.ControlBox.HelpButton.OffsetLocation = new System.Drawing.Point(0, 1);
            this.ControlBox.HelpButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.HelpButton.TabIndex = 0;
            this.ControlBox.HelpButton.Text = "s";
            this.ControlBox.HelpButton.TextStyle.Disabled = System.Drawing.Color.Empty;
            this.ControlBox.HelpButton.TextStyle.Enabled = System.Drawing.Color.Empty;
            this.ControlBox.HelpButton.TextStyle.Hover = System.Drawing.Color.Empty;
            this.ControlBox.HelpButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.HelpButton.Visible = false;
            this.ControlBox.Location = new System.Drawing.Point(550, 4);
            // 
            // 
            // 
            this.ControlBox.MaximizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.MaximizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.MaximizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MaximizeButton.BoxType = VisualPlus.Structure.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.MaximizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MaximizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MaximizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.ControlBox.MaximizeButton.Location = new System.Drawing.Point(24, 0);
            this.ControlBox.MaximizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.MaximizeButton.Name = "";
            this.ControlBox.MaximizeButton.OffsetLocation = new System.Drawing.Point(1, 1);
            this.ControlBox.MaximizeButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.MaximizeButton.TabIndex = 2;
            this.ControlBox.MaximizeButton.Text = "1";
            this.ControlBox.MaximizeButton.TextStyle.Disabled = System.Drawing.Color.Empty;
            this.ControlBox.MaximizeButton.TextStyle.Enabled = System.Drawing.Color.Empty;
            this.ControlBox.MaximizeButton.TextStyle.Hover = System.Drawing.Color.Empty;
            this.ControlBox.MaximizeButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.ControlBox.MinimizeButton.BackColorState.Disabled = System.Drawing.Color.Transparent;
            this.ControlBox.MinimizeButton.BackColorState.Enabled = System.Drawing.Color.Transparent;
            this.ControlBox.MinimizeButton.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.ControlBox.MinimizeButton.BackColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MinimizeButton.BoxType = VisualPlus.Structure.ControlBoxButton.ControlBoxType.Default;
            this.ControlBox.MinimizeButton.ForeColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.ControlBox.MinimizeButton.ForeColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.ForeColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.ForeColorState.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ControlBox.MinimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.ControlBox.MinimizeButton.Location = new System.Drawing.Point(0, 0);
            this.ControlBox.MinimizeButton.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.MinimizeButton.Name = "";
            this.ControlBox.MinimizeButton.OffsetLocation = new System.Drawing.Point(2, 0);
            this.ControlBox.MinimizeButton.Size = new System.Drawing.Size(24, 25);
            this.ControlBox.MinimizeButton.TabIndex = 1;
            this.ControlBox.MinimizeButton.Text = "0";
            this.ControlBox.MinimizeButton.TextStyle.Disabled = System.Drawing.Color.Empty;
            this.ControlBox.MinimizeButton.TextStyle.Enabled = System.Drawing.Color.Empty;
            this.ControlBox.MinimizeButton.TextStyle.Hover = System.Drawing.Color.Empty;
            this.ControlBox.MinimizeButton.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ControlBox.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ControlBox.Name = "";
            this.ControlBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ControlBox.Size = new System.Drawing.Size(72, 25);
            this.ControlBox.TabIndex = 0;
            this.ControlBox.TextStyle.Disabled = System.Drawing.Color.Empty;
            this.ControlBox.TextStyle.Enabled = System.Drawing.Color.Empty;
            this.ControlBox.TextStyle.Hover = System.Drawing.Color.Empty;
            this.ControlBox.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.Controls.Add(this.OpenLast);
            this.Controls.Add(this.OpenSaveFolder);
            this.Controls.Add(this.visualTabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HookAddress);
            this.Controls.Add(this.PIDLabel);
            this.Controls.Add(this.visualLabel1);
            this.Controls.Add(this.RunOrStop);
            this.Controls.Add(this.TimeSpanBar);
            this.Controls.Add(this.Time_Span_Label);
            this.Controls.Add(this.TimeSpanNum);
            this.Controls.Add(this.visualButton1);
            this.Controls.Add(this.visualSeparator1);
            this.Controls.Add(this.SelectSavePath);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Image.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(183)))), ((int)(((byte)(230)))));
            this.Image.Border.HoverVisible = true;
            this.Image.Border.Rounding = 6;
            this.Image.Border.Thickness = 1;
            this.Image.Border.Type = VisualPlus.Enumerators.ShapeType.Rectangle;
            this.Image.Border.Visible = false;
            this.Image.Image = ((System.Drawing.Bitmap)(resources.GetObject("resource.Image3")));
            this.Image.Point = new System.Drawing.Point(5, 7);
            this.Image.Size = new System.Drawing.Size(48, 16);
            this.Image.Visible = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(640, 320);
            this.Name = "Form1";
            this.Text = "CAXA Auto Backup";
            this.TextRectangle = new System.Drawing.Rectangle(269, 7, 103, 14);
            this.visualTabControl1.ResumeLayout(false);
            this.visualTabPage1.ResumeLayout(false);
            this.visualTabPage1.PerformLayout();
            this.visualTabPage2.ResumeLayout(false);
            this.visualTabPage3.ResumeLayout(false);
            this.visualPanel1.ResumeLayout(false);
            this.visualPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private VisualPlus.Toolkit.Controls.Layout.VisualSeparator visualSeparator1;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton visualButton1;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualNumericUpDown TimeSpanNum;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel Time_Span_Label;
        private VisualPlus.Toolkit.Controls.DataVisualization.VisualProgressBar TimeSpanBar;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualToggle RunOrStop;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel visualLabel1;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel PIDLabel;
        public VisualPlus.Toolkit.Controls.Interactivity.VisualLabel HookAddress;
        private System.Windows.Forms.Button button1;
        public VisualPlus.Toolkit.Controls.Editors.VisualTextBox SelectSavePath;
        private VisualPlus.Toolkit.Controls.Navigation.VisualTabControl visualTabControl1;
        private VisualPlus.Toolkit.Child.VisualTabPage visualTabPage1;
        private VisualPlus.Toolkit.Child.VisualTabPage visualTabPage2;
        private VisualPlus.Toolkit.Controls.DataManagement.VisualListBox LogListBox;
        private VisualPlus.Toolkit.Controls.DataManagement.VisualListViewEx AutoSaveList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private VisualPlus.Toolkit.Child.VisualTabPage visualTabPage3;
        private VisualPlus.Toolkit.Controls.Layout.VisualPanel visualPanel1;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton OpenSaveFolder;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton OpenLast;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualButton CleanAllFile;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel visualLabel3;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualLabel visualLabel2;
        private System.Windows.Forms.TextBox OneSaveCount;
        private System.Windows.Forms.TextBox ALLSAVECOUNT;
    }
}