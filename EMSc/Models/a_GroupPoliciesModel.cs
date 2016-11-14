using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class a_GroupPoliciesModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Gid { get; set; }
               
        [Required]
        public string Title { get; set; }
        [Required]
        public string Attribs { get; set; }
        [Required]
        public virtual ICollection<a_PageDefinitionModel> PageInfoPolicies { get; set; }
    }
}