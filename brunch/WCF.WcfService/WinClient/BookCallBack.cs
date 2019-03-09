using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinClient.BookServiceRef;

namespace WinClient
{
    public class BookCallBack : IBookServiceCallback
    {
        public delegate void delegateDisplayResult(string name);
        public delegateDisplayResult mainThread;
        public void DisplayResult(string result)
        {
            mainThread(result);
            Console.WriteLine(result);
        }
    }
}
