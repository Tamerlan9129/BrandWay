namespace Business.ViewModels.Product
{
    public class ProductLoadMoreVM
    {
        public List<Core.Entities.Product> Products { get; set; }
        public bool IsLast { get; set; }
    }
}
