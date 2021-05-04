using MyTourist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTourist.Dtos
{
    public class TouristTouteDto
    {
        public Guid Id { get; set; }    
        public string Title { get; set; }      
        public String Description { get; set; }
        //public decimal OriginalPrice { get; set; }

        //public double? DiscountPresent { get; set; }

        // 用价格代替   OriginalPrice  DiscountPresent
        public decimal Price { get; set; }
        public DateTime CraeteTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepatrureTime { get; set; }
     
        public string Features { get; set; }
     
        public string Fees { get; set; }
      
        public string Notes { get; set; }
        public double? Rating { get; set; }

        public ICollection<TouristRoutePictureDto> TouristRoutePictures { get; set; } 
    }
}
