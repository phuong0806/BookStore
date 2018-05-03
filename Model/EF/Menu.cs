namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(10)]
        public string Target { get; set; }

        public bool? Status { get; set; }

        public int? GroupId { get; set; }

        public virtual MenuGroup MenuGroup { get; set; }
    }
}
