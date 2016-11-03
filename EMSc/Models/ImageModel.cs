using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMSc.Models
{
    public class ImageModel
    {
        public enum TypeImg { ftp,url,blob,base64 }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long Fid { get; set; }
        [Required]
        public string Type { get; set; }
        public string Alt { get; set; }
        public string Description { get; set; }
        [Required]
        public Byte Src { get; set; }
    }
}