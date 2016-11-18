﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
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
        public virtual ICollection<a_GroupPoliciesModel> GroupPolicy { get; set; }


    }
}