using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class LHUrl
    {
        
        [Key]
        public int UrlId { get; set; }
        public string UrlTitle { get; set; }
        public string LHUrlLink { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("User")]
        public string Id { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
    }
}
