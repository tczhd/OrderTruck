using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Signup : IEntityBase
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Status { get; set; }
        public int FormId { get; set; }
    }
}
