using System.ComponentModel;
using System.Configuration.Install;

namespace ETCTool
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}