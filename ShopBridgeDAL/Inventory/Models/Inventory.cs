using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeDAL.Inventory.Models
{
    public class Inventory
    {
        [Column("inId")]
        public int? inId { get; set; }
        [Column("stName")]
        public string Name { get; set; }

        [Column("stDescription")]
        public string Description { get; set; }
        [Column("dcPrice")]
        public decimal? Price { get; set; }

        [Column("stImageName")]
        public string stImage { get; set; }

        [NotMapped]
        public IFormFile ProdImage { get; set; }

    }

    public class getInventoryList
    {
        public List<Inventory> loInventry { get; set; }

        [Column("inId")]
        public int? inId { get; set; }

        [Column("stName")]
        [Required(ErrorMessage = "Please enter product name")]
        public string Name { get; set; }

        [Column("stDescription")]
        [Required(ErrorMessage = "Please enter product description")]
        public string Description { get; set; }

        [Column("dcPrice")]
        [Required(ErrorMessage = "Please enter product price")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public string Price { get; set; }

        [NotMapped]
        [Column("stImageName")]
        [Required(ErrorMessage = "Please upload product image")]
        public IFormFile ProdImage { get; set; }
    }
}
