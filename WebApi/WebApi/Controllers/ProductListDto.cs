using System;

namespace WebApi.Controllers
{
    public class ProductListDto
    {
        public ProductListDto()
        {
        }
        public int SkuID { get; set; }
        public Guid SkuGuid { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
    }
}