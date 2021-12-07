using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.Models
{
    [Table("Students")]
    public class Students
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(30), Required]
        public string Name { get; set; }
        [StringLength(30), Required]
        public string SurName { get; set; }
        [Required]
        public int Number { get; set; }
        public virtual Classes Classes { get; set; }

    }
}