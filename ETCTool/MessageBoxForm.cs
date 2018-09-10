using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

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
            Text = Message;
            Countdown.Maximum = Time * 20;
            Countdown.Value = Time * 20;
            var CountdownClose = true;
            Task.Factory.StartNew(() =>
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
            }, TaskCreationOptions.AttachedToParent);
        }

        private void ChangeAutoSavePath_Click(object sender, EventArgs e)
        {
            Countdown.Value = 0;
        }
    }
}