using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
    }
}
