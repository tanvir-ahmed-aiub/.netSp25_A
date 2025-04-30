using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int CId { get; set; }
    }
}