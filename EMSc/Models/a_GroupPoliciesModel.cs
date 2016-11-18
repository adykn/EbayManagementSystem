﻿using System;
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
        public int id { get; set; }
        public virtual a_GroupHeadModel GroupHead { get; set; }
        public virtual a_PageDefinitionModel PageDefinition { get; set; }
        [Required]
        public string Attribs { get; set; }
        

    }
   

    }
