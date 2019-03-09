using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCF.WcfService
{
    public class BookService : IBookService
    {
        string IBookService.GetBook(int id)
        {
            return id.ToString();
        }
    }
}
