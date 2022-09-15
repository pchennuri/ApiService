using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models
{
    [Table("Jobs")]
    public class Jobs
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public DateTime? ClosingDate { get; set; }
    }
}
