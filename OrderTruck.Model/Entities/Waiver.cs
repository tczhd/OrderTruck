using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Waiver : IEntityBase
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
