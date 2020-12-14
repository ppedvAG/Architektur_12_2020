using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface IService
{

    [OperationContract]
    string GetData(int value);

    [OperationContract]
    int Verdoppeln(int zahl);

    [OperationContract]
    [WebGet(UriTemplate ="Hallo?Name=Fred")]
    string SagHallo(string name);
}

