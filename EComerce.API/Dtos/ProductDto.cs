using EComerce.Core.Entities.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComerce.API.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public virtual List<PhotoDto> photos { get; set; }
        public string CategoryName { get; set; }
       
 
    }
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public IFormFileCollection photos { get; set; }
      
        public int CategoryId { get; set; }


    }

    public class UpdatedProductDto:AddProductDto
    {
        public int Id { get; set; }
    }


    public class PhotoDto
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
    }
    
}
