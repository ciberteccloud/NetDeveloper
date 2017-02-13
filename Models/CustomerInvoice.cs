using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class CustomerInvoice
    {
        [DataMember]
        public string BillingCountry { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }        
    }
}
