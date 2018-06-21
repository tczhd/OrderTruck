using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Slot : IEntityBase
    {
        public int Id { get; set; }
        public int SignupId { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int FormId { get; set; }
        public int? PeopleNeed { get; set; }
    }
}
