using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class a_siteaccesslistModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string access { get; set; }
        [Required]
        public Boolean mainpage { get; set; }
        public virtual a_pageinfoModel pageinfo { get; set; }
        public virtual a_siteaccessModel siteaccess { get; set; }
    }
}