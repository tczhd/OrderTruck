using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class AccountUser : IEntityBase
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public bool IsCoordinator { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? JoinDate { get; set; }
    }
}
