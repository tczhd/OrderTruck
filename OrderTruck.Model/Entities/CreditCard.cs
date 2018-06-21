using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class CreditCard : IEntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Ccnumber { get; set; }
        public string Ccname { get; set; }
        public int? Ccmonth { get; set; }
        public int? Ccyear { get; set; }
        public string Cccode { get; set; }
        public bool? DefaultPayment { get; set; }
    }
}
