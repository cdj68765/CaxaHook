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
            this.FROM = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
            this.TO = new VisualPlus.Toolkit.Controls.Interactivity.VisualLabel();
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
            this.TimeSpanBar.Hatch.Style = System.Drawing.Drawing2D.HatchStyle.DarkDownwardDiagonal;
            this.TimeSpanBar.Hatch.Visible = true;
            this.TimeSpanBar.LargeChange = 5;
            this.TimeSpanBar.Location = new System.Drawing.Point(22, 287);
            this.TimeSpanBar.MarqueeWidth = 20;
            this.TimeSpanBar.Maximum = 100;
            this.TimeSpanBar.Minimum = 0;
            this.TimeSpanBar.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.TimeSpanBar.Name = "TimeSpanBar";
            this.TimeSpanBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TimeSpanBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(136)))), ((int)(((byte)(45)))));
            this.TimeSpanBar.ProgressImage = null;
            this.TimeSpanBar.Size = new System.Drawing.Size(165, 20);
            this.TimeSpanBar.SmallChange = 1;
            this.TimeSpanBar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.TimeSpanBar.TabIndex = 7;
            this.TimeSpanBar.Text = "visualProgressBar1";
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
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FROM
            // 
            this.FROM.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FROM.ForeColor = System.Drawing.Color.Red;
            this.FROM.Location = new System.Drawing.Point(223, 46);
            this.FROM.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.FROM.Name = "FROM";
            this.FROM.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.FROM.Outline = false;
            this.FROM.OutlineColor = System.Drawing.Color.Red;
            this.FROM.OutlineLocation = new System.Drawing.Point(0, 0);
            this.FROM.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FROM.ReflectionSpacing = 0;
            this.FROM.ShadowColor = System.Drawing.Color.Black;
            this.FROM.ShadowDirection = 315;
            this.FROM.ShadowLocation = new System.Drawing.Point(0, 0);
            this.FROM.ShadowOpacity = 100;
            this.FROM.Size = new System.Drawing.Size(401, 23);
            this.FROM.TabIndex = 13;
            this.FROM.TextAlignment = System.Drawing.StringAlignment.Near;
            this.FROM.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.FROM.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.FROM.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FROM.TextStyle.Hover = System.Drawing.Color.Empty;
            this.FROM.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // TO
            // 
            this.TO.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TO.ForeColor = System.Drawing.Color.Red;
            this.TO.Location = new System.Drawing.Point(223, 75);
            this.TO.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.TO.Name = "TO";
            this.TO.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TO.Outline = false;
            this.TO.OutlineColor = System.Drawing.Color.Red;
            this.TO.OutlineLocation = new System.Drawing.Point(0, 0);
            this.TO.ReflectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TO.ReflectionSpacing = 0;
            this.TO.ShadowColor = System.Drawing.Color.Black;
            this.TO.ShadowDirection = 315;
            this.TO.ShadowLocation = new System.Drawing.Point(0, 0);
            this.TO.ShadowOpacity = 100;
            this.TO.Size = new System.Drawing.Size(401, 23);
            this.TO.TabIndex = 14;
            this.TO.TextAlignment = System.Drawing.StringAlignment.Near;
            this.TO.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.TO.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.TO.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TO.TextStyle.Hover = System.Drawing.Color.Empty;
            this.TO.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
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
            this.Controls.Add(this.TO);
            this.Controls.Add(this.FROM);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisualPlus.Toolkit.Controls.Editors.VisualTextBox SelectSavePath;
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
        public VisualPlus.Toolkit.Controls.Interactivity.VisualLabel FROM;
        public VisualPlus.Toolkit.Controls.Interactivity.VisualLabel TO;
    }
}