using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class ShippingModel
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public double SalesTaxPercent { get; set; }
		public string	SalesTaxState { get; set; }
        public Boolean ApplyShippingDiscount { get; set; }
        public AmountModel InsuranceFee { get; set; }
        public int InsuranceOption { get; set; }
		public string PaymentInstructions { get; set; }
		public int ShippingType { get; set; }
		public ShippingServices shippingServices { get; set; }
        public Products products { get; set; }


    }
}