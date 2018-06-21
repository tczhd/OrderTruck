using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Reg : IEntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SlotId { get; set; }
        public int? ScheduleId { get; set; }
        public DateTime RegDate { get; set; }
        public int? PayStatus { get; set; }
        public string Notes { get; set; }
        public string Comment { get; set; }
        public int? VerifyStatus { get; set; }
        public DateTime? VerifyDate { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
