using MaterialSkin.Controls;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETCTool
{
    public partial class MessageBoxForm : MaterialForm
    {
        public MessageBoxForm()
        {
            InitializeComponent();
        }

        public MessageBoxForm(string Message, MessageBoxButtons buttons, int Time)
        {
            InitializeComponent();
            if (Variables.MainForm.TopMost) TopMost = true;
            Text = Message;
            Countdown.Maximum = Time * 20;
            Countdown.Value = Time * 20;
            var CountdownClose = true;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    do
                    {
                        Thread.Sleep(50);
                        BeginInvoke(new Action(() =>
                        {
                            if (Countdown.Value != 0)
                                Countdown.Value--;
                        }));
                        if (Countdown.Value != 0) continue;
                        CountdownClose = false;
                        BeginInvoke(new Action(Close));
                    } while (CountdownClose);
                }
                catch (Exception e)
                {
                }
            }, TaskCreationOptions.AttachedToParent);
        }

        private void ChangeAutoSavePath_Click(object sender, EventArgs e)
        {
            Countdown.Value = 0;
        }
    }
}