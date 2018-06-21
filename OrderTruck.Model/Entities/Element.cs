using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Element : IEntityBase
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string Label { get; set; }
        public int? Type { get; set; }
        public string DefaultValue { get; set; }
    }
}
