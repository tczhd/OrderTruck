using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Payment : IEntityBase
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime PayDate { get; set; }
        public int UserId { get; set; }
        public string PayFor { get; set; }
        public int? PlanId { get; set; }
        public int PayMethod { get; set; }
        public decimal Amount { get; set; }
        public decimal? Discount { get; set; }
        public decimal Total { get; set; }
        public int Status { get; set; }
        public string TransactionNumber { get; set; }
    }
}
