using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLib
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        string GetBook(int id);
        [OperationContract]
        string AddBook(string book);
        [OperationContract]
        string EditBook(string book);
        [OperationContract]
        string SearchBook(string category, string searchString);
    }
}
