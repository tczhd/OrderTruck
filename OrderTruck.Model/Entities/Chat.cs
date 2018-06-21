using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Chat : IEntityBase
    {
        public int Id { get; set; }
        public int SignupId { get; set; }
        public int SenderId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
