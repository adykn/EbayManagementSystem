using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class PolicyModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        [Required]
        public string Refund { get; set; }
        [Required]
        public string ReturnsWithinOption { get; set; }
        [Required]
        public string ReturnsAcceptedOption { get; set; }
        [Required]
        public string ShippingCostPaidByOption { get; set; }
    }
}