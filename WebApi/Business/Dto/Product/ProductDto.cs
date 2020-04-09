using System;

namespace Business.Dto.Product
{
    public class ProductDto
    {
        public int SKUID { get; set; }
        public Guid SKUGuid { get; set; }
        public string SKUName { get; set; }
        public string SKUNumber { get; set; }
        public decimal SKUPrice { get; set; }
        public bool SKUEnabled { get; set; }
        public string ProductType { get; set; }
        public string SKUImagePath { get; set; }
        public DateTime SKUCreated { get; set; }
        public string SKUDescription { get; set; }
    }
    public class ProductInfo<T>
    {
        public ProductDto Sku { get; set; }
        public T CustomProperties { get; set; }
        
    }
}
