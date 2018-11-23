namespace XKitchen.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int reservid { get; set; }

        public int productid { get; set; }

        public decimal price { get; set; }

        public int status { get; set; }

        public int quantity { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public virtual Product Product { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
