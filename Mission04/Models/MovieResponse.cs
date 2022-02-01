using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission04.Models
{
    public class MovieResponse
    {
        // Here is the model that outlines the attributes of the movie objects we submit 
        [Key]
        [Required]
        public int MovieId { get; set; }
        
        [Required]
        public string title { get; set; }
        [Required]
        public int Categoryid { get; set; }
        public Category Category { get; set; }
        //public object Category { get; internal set; }
        [Required]
        public int year { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }
        public bool edited { get; set; }
        public string lentto { get; set; }
        [StringLength(25)]
        public string notes { get; set; }
    }    
}
