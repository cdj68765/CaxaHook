namespace ETCTool
{
    partial class MessageBoxForm
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
            this.Countdown = new MaterialSkin.Controls.MaterialProgressBar();
            this.ChangeAutoSavePath = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // Countdown
            // 
            this.Countdown.Depth = 0;
            this.Countdown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Countdown.Location = new System.Drawing.Point(0, 105);
            this.Countdown.MouseState = MaterialSkin.MouseState.HOVER;
            this.Countdown.Name = "Countdown";
            this.Countdown.Size = new System.Drawing.Size(320, 5);
            this.Countdown.TabIndex = 0;
            // 
            // ChangeAutoSavePath
            // 
            this.ChangeAutoSavePath.AutoSize = true;
            this.ChangeAutoSavePath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChangeAutoSavePath.Depth = 0;
            this.ChangeAutoSavePath.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChangeAutoSavePath.Icon = null;
            this.ChangeAutoSavePath.Location = new System.Drawing.Point(264, 66);
            this.ChangeAutoSavePath.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChangeAutoSavePath.Name = "ChangeAutoSavePath";
            this.ChangeAutoSavePath.Primary = true;
            this.ChangeAutoSavePath.Size = new System.Drawing.Size(51, 36);
            this.ChangeAutoSavePath.TabIndex = 11;
            this.ChangeAutoSavePath.Text = "确认";
            this.ChangeAutoSavePath.UseVisualStyleBackColor = true;
            this.ChangeAutoSavePath.Click += new System.EventHandler(this.ChangeAutoSavePath_Click);
            // 
            // MessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 110);
            this.Controls.Add(this.ChangeAutoSavePath);
            this.Controls.Add(this.Countdown);
            this.Name = "MessageBoxForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialProgressBar Countdown;
        private MaterialSkin.Controls.MaterialRaisedButton ChangeAutoSavePath;
    }
}