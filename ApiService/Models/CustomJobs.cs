using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models
{
    public class CustomJobs
    {
        public CustomJobs()
        {

        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string location { get; set; }

        public string Department { get; set; }

        public DateTime? ClosingDate { get; set; }
    }
}
