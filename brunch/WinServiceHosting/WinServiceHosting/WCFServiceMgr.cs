using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WinServiceHosting
{
    partial class WCFServiceMgr : ServiceBase
    {
        public WCFServiceMgr()
        {
            InitializeComponent();
        }
        ServiceHost svrHost = null;
        protected override void OnStart(string[] args)
        {
            try
            {
                if (svrHost == null)
                {
                    svrHost = new ServiceHost(typeof(WCFServiceMgr));
                    if (svrHost.State != CommunicationState.Opened)
                    {
                        svrHost.Open();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            if (svrHost != null)
            {
                svrHost.Close();
                svrHost = null;
            }
        }
    }
}
