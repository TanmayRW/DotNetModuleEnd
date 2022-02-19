using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProductsMVC.Models
{
    public class Product
    {
        
        public int ProductId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Please Enter Rate of Product")]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter Description for this Product")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter Name of Category for this Product")]
        public string CategoryName { get; set; }

    }
}