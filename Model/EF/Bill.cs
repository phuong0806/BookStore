namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill
    {
        [StringLength(20)]
        public string ID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(10)]
        public string CreatedBy { get; set; }

        [StringLength(20)]
        public string PublisherID { get; set; }

        [StringLength(20)]
        public string BookID { get; set; }
    }
}
