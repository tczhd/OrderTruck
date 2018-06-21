using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Form : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifed { get; set; }
        public int Status { get; set; }
    }
}
