using System.Runtime.Serialization;

namespace ASP_NET_Core_CasaDoCodigo.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}
