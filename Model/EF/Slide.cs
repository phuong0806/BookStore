namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slide
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(500)]
        public string URL { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool? Status { get; set; }
    }
}
