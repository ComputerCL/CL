using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BookServiceRef.BookServiceClient client = new BookServiceRef.BookServiceClient();
            client.GetBook(5);
        }
    }
}
