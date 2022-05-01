using NewPhoneShop2.Data;
using NewPhoneShop2.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace NewPhoneShop2.Models
{
    public class Product: IEntityBase
    {
        public int Id { get; set; }
        
        
        [Display(Name = "ProfilePictureURL")]
        [Required(ErrorMessage = "Profile Picture is Required")]
        public string ProfilePictureURL { get; set; }
        
        [Display(Name = "Category")]
        public Category Category { get; set; }
        
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }
        
        [Display(Name = "BrandName")]
        [Required(ErrorMessage = "Brand Name is Required")]
        public BrandName BrandName { get; set; }

        [Display(Name = "Properties")]
        public string Properties { get; set; }
        
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }

    }
}
