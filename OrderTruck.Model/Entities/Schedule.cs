using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Schedule : IEntityBase
    {
        public int Id { get; set; }
        public int SlotId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public int PeopleNeed { get; set; }
    }
}
