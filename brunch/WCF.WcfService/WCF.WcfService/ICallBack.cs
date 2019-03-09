using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.WcfService
{
    public interface ICallBack
    {
        [OperationContract(IsOneWay = true)]
        void DisplayResult(string result);
    }
}
