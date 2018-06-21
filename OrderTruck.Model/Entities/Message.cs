using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class Message : IEntityBase
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MsgBody { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? ReadDate { get; set; }
    }
}
