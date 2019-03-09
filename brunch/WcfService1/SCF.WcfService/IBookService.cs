using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCF.WcfService
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        string GetBook(int id);
    }
}
