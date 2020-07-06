using System.Runtime.Serialization;

namespace FXCM.Helpers
{
    [DataContract]
    public class LoginCredentials
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Passsword { get; set; }

        [DataMember]
        public Connection ConnectionAccount { get; set; }
    }
}
