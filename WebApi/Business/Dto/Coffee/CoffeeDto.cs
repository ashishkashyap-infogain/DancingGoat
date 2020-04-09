using Business.Dto.Product;

namespace Business.Dto.Coffee
{
    public class CoffeeDto
    {
        public int CoffeeID { get; set; }
        public string CoffeeFarm { get; set; }
        public string CoffeeCountry { get; set; }
        public string CoffeeVariety { get; set; }
        public string CoffeeProcessing { get; set; }
        public int CoffeeAltitude { get; set; }
        public bool CoffeeIsDecaf { get; set; }
    }

    public class CoffeeProductDto
    {
        public CoffeeDto Coffee { get; set; }
        public ProductDto Sku { get; set; }
    }
    //public class ProductInfo<T>
    //{
    //    public T CustomProperties { get; set; }
    //    public ProductDto Sku { get; set; }
    //}

}
