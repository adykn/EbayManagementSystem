using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class ShippingServices
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long Fid { get; set; }
        public Boolean ExpeditedService { get; set; }
        public string ShippingService { get; set; }
        public AmountModel ShippingServiceAdditionalCost { get; set; }
        public AmountModel ShippingServiceCost { get; set; }
        public int ShippingServicePriority { get; set; }
        public AmountModel ShippingInsuranceCost { get; set; }
    }
}