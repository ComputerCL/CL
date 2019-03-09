using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService2
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“BookService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 BookService.svc 或 BookService.svc.cs，然后开始调试。
    public class BookService : IBookService
    {
        MyDataBaseEntities db = new MyDataBaseEntities();
        public void DoWork()
        {
        }

        public string GetBook(int id)
        {
            try
            {
                Book bk = db.Book.Where(p => p.ID == (id)).FirstOrDefault();
                return XMLHelper.ToXML<Book>(bk);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
