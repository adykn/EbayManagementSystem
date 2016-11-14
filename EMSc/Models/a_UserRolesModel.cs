﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class a_UserRolesModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Rid { get; set; }
        [Required]
        public virtual a_UserAAModel SiteAccessUser { get; set; }
        [Required]
        public virtual a_GroupPoliciesModel GroupPolicy { get; set; }

    }
}