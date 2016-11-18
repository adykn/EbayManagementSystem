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
        public int id { get; set; }
        public int Picfid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string ApiToken { get; set; }
        public string PassTokenReset { get; set; }
        public Boolean RememberMe { get; set; }



    }
    public class a_Roles
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public virtual a_GroupPoliciesModel GroupPolicy { get; set; }
        [Required]
        public virtual a_UserAAModel SiteAccessUser { get; set; }

    }
    public class a_PageDefinitionModel
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Attribs { get; set; }
        //[NotMapped]
        //public virtual a_GroupPoliciesModel GroupPolicy { get; set; }


    }
    public class a_GroupPoliciesModel
    {


        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual a_GroupHeadModel GroupHead { get; set; }
        public virtual IList<a_PageDefinitionModel> PageDefinition { get; set; }
        [Required]
        public string Attribs { get; set; }


    }
    public class a_GroupHeadModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}