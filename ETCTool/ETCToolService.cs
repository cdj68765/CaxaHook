using System.ServiceProcess;

namespace ETCTool
{
    internal partial class ETCToolService : ServiceBase
    {
        private readonly string RunPath;

        public ETCToolService(string executablePath)
        {
            InitializeComponent();

            RunPath = executablePath;
        }

        protected override void OnStart(string[] args)
        {
            createProcessAsUser.StartProcessAndBypassUAC(RunPath, " Service", out var info);
        }
    }
}