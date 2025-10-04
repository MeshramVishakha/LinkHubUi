using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class User : IdentityUser
    {
       
           
        //public string FullName { get; set; }
        //public string Contact { get; set; }
       

        public IEnumerable<LHUrl> LHUrls { get; set; }
    }
}
