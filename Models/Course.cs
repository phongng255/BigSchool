namespace BigSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string LecturerID { get; set; }
        [Required(ErrorMessage = "Place không được để trống")]
        [StringLength(255)]
        public string Place { get; set; }
        [Required(ErrorMessage = "DateTime không được để trống")]
        public DateTime DateTime { get; set; }

        public int CategoryID { get; set; }
        public List<Category> listcategory = new List<Category>();
        public virtual Category Category { get; set; }
        public string Name;
    }
}
