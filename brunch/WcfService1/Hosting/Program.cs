using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using SCF.WcfService;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(BookService)))
            {                
                host.Opened += delegate

                {
                    Console.WriteLine("按下任意键终止服务");
                };
                host.Open();
                Console.Read();
            }
        }

      
    }
}
