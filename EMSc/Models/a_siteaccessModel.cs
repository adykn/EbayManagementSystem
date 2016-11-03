using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class a_siteaccessModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int picfid { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string contact { get; set; }
        public string apiToken { get; set; }
        public virtual Boolean RememberMe { get; set; }
        public virtual ICollection<a_siteaccesslistModel> siteaccesslist { get; set; }
    }
}