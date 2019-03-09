using SCF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Model;

namespace WCF.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“BookService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 BookService.svc 或 BookService.svc.cs，然后开始调试。
    public class BookService : IBookService
    {
        BookEntities db = new BookEntities();
        public string AddBook(string book)
        {
            try
            {
                Book bk = XMLHelper.DeSerializer<Book>(book);
                db.Book.Add(bk);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "true";
        }

        public void DisplayName(string name)
        {
            string result = string.Format("书籍名称：{0}，时间：{1}", name, DateTime.Now.ToString());
            Console.WriteLine(result + "\r\n");
            ICallBack callback = OperationContext.Current.GetCallbackChannel<ICallBack>();
            callback.DisplayResult(name);
        }

        public string EditBook(string book)
        {
            try
            {
                Book bk = XMLHelper.DeSerializer<Book>(book);
                db.Entry(bk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "true";
            
        }

        public string GetBook(int id)
        {
            try
            {
                Book bk = db.Book.Where(p => p.ID == (id)).FirstOrDefault();
                return XMLHelper.ToXML<Book>(bk);
            }
            catch(Exception ex)
            {
                return "";
            }
            
        }

        public string SearchBook(string category, string searchString)
        {
            try
            {
                List<Book> bkList = db.Book.Where(p => p.Category.Contains(category) && p.Name.Contains(searchString)).ToList();
                return XMLHelper.ToXML<List<Book>>(bkList);
            }
            catch
            {
                return "";
            }
        }
    }
}
