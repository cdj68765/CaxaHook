using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ETCTool
{
    partial class ETCToolService : ServiceBase
    {
        private string RunPath;
        public ETCToolService(string executablePath)
        {
            InitializeComponent();
           
            RunPath = executablePath;
        }
        protected override void OnStart(string[] args)
        {
            createProcessAsUser.StartProcessAndBypassUAC(RunPath," Service",out createProcessAsUser.PROCESS_INFORMATION info);
      
            //  Process.Start(RunPath);
        }

    }
}
