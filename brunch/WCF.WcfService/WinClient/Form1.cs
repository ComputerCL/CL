using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient
{
    public partial class Form1 : Form
    {
        InstanceContext instanceContext;
        BookCallBack call;
        public Form1()
        {
            InitializeComponent();
            BookCallBack call = new BookCallBack();
            call.mainThread += new BookCallBack.delegateDisplayResult(DisplayResult);
            instanceContext = new InstanceContext(call);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BookServiceRef.BookServiceClient bookClient = new BookServiceRef.BookServiceClient();
            //string bookmsg = bookClient.GetBook(1);
            //txt_BookMsg.Text = bookmsg;

            BookServiceRef.BookServiceClient bookClient = new BookServiceRef.BookServiceClient(instanceContext);
            bookClient.DisplayName("这本书可以看");
        }
        private void DisplayResult(string name)
        {
            if (this.txt_BookMsg.InvokeRequired)
            {
                call = new BookCallBack();
                call.mainThread += new BookCallBack.delegateDisplayResult(DisplayResult);
                this.Invoke(call.mainThread, name);
            }
            else
            {
                txt_BookMsg.Text = name;
            }
        }
    }
}
