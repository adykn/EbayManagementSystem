using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class ProductsVariationsModel
    {
        //"id", "ref", "attribute", "value"
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long refid { get; set; }
        public string Attrib { get; set; }
        public string Value { get; set; }
        public virtual Products products { get; set; }
        
    }
}