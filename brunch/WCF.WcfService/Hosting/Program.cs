using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF.WcfService;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(BookService)))
            {
                host.AddServiceEndpoint(typeof(IBookService), new WSDualHttpBinding(), "http://127.0.0.1:8888/BookService");
                if(host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = new Uri("http://127.0.0.1:8888/BookService");
                    host.Description.Behaviors.Add(behavior);
                }
                host.Opened += delegate
                {
                     Console.Write("BookService，按任意键终止服务！");
                };
                host.Open();
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (ServiceEndpoint se in host.Description.Endpoints)
                {
                    Console.WriteLine("[终结点]: {0}\r\n\t[A-地址]: {1} \r\n\t [B-绑定]: {2} \r\n\t [C-协定]: {3}",
                     se.Name, se.Address, se.Binding.Name, se.Contract.Name);
                }
                Console.Read();
            }
        }
    }
}
