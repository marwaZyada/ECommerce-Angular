namespace EComerce.API.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class UpdatedCategoryDto : CategoryDto
    {
        public int Id { get; set; }
    }
}
