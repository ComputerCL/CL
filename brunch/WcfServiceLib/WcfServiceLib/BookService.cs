using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLib
{
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
            catch (Exception ex)
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
