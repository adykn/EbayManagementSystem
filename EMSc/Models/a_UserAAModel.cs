using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class a_UserAAModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Uid { get; set; }
        public int Picfid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string ApiToken { get; set; }
        public virtual Boolean RememberMe { get; set; }
        public virtual ICollection<a_UserRolesModel> UserRolePolicy { get; set; }
    }
}