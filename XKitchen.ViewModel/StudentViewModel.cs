using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.ViewModel
{
    public class StudentViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Display(Name = "Full Name")]
        public string fullname { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [StringLength(10)]
        [Display(Name = "Gender")]
        public string gendername { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dob { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Place of Birth")]
        public string pob { get; set; }

        public bool Active { get; set; }

    }
}
