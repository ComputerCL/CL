using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLib;

namespace ConsoleHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/BookService");
            using (ServiceHost host = new ServiceHost(typeof(BookService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(IBookService), new WSHttpBinding(), baseAddress);
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = baseAddress;
                    host.Description.Behaviors.Add(behavior);
                    host.Opened += delegate
                    {
                        Console.WriteLine("BookService控制台程序寄宿已经启动，HTTP监听已启动....，按任意键终止服务！");

                       
                    };
                    host.Open();
                    Console.Read();
                }
            }
        }
    }
}
