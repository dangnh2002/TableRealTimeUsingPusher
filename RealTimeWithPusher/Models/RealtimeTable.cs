namespace RealTimeWithPusher.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RealtimeTable")]
    public partial class RealtimeTable
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public int? year { get; set; }
    }
}
