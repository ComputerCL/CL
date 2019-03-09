using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IBookService”。
    [ServiceContract(CallbackContract = typeof(ICallBack))]
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
        [OperationContract(IsOneWay = true)]
        void DisplayName(string name);
    }
}
