using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Account : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int PlanId { get; set; }
        public int OwnerId { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
