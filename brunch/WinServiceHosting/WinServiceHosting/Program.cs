using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WinServiceHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceController service = new ServiceController("WCFServiceMgr");

            if (args.Length == 0)
            {
                ServiceBase[] serviceRun;
                serviceRun = new ServiceBase[] { new WCFServiceMgr() };
                ServiceBase.Run(serviceRun);
            }
            else if (args[0].ToLower() == "/i" || args[0].ToLower() == "-i")
            {
                if (!IsServiceExisted("WCFServiceMgr"))
                {
                    try
                    {
                        string[] cmdLine = { };
                        string exeLocalhost = System.Reflection.Assembly.GetExecutingAssembly().Location;
                        TransactedInstaller install = new TransactedInstaller();
                        AssemblyInstaller assmeInstall = new AssemblyInstaller(exeLocalhost, cmdLine);
                        install.Installers.Add(assmeInstall);

                        install.Install(new System.Collections.Hashtable());
                        TimeSpan timeout = TimeSpan.FromMilliseconds(1000 * 10);
                        service.Start(args);
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else if (args[0].ToLower() == "/u" || args[0].ToLower() == "-u")
            {
                string[] cmdLine = { };
                string exeFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                TransactedInstaller install = new TransactedInstaller();
                AssemblyInstaller assmInstall = new AssemblyInstaller(exeFileName, cmdLine);
                install.Installers.Add(assmInstall);
                install.Uninstall(null);
                service.Start(args);
                service.WaitForStatus(ServiceControllerStatus.Stopped);
            }
        }
        /// <summary>
        /// 是否存在服务
        /// </summary>
        /// <param name="ServiceName"></param>
        /// <returns></returns>
        public static bool IsServiceExisted(string ServiceName)
        {
            ServiceController[] control = ServiceController.GetServices();
            foreach (ServiceController con in control)
            {
                if (con.ServiceName.ToLower() == ServiceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
