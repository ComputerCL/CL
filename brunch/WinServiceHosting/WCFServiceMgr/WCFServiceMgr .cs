using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceMgr
{
    public class WCFServiceMgr : ServiceBase
    {
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
            if (svrHost != null)
            {
                svrHost.Close();
                svrHost = null;
            }
        }

        private void InitializeComponent()
        {
            // 
            // WCFServiceMgr
            // 
            this.ServiceName = "WCFService";

        }
    }
}
