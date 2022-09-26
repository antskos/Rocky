using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Display order")]
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Order must be positive integer")]
        public int DisplayOrder { get; set; }
    }
}
