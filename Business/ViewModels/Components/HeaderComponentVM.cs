namespace Business.ViewModels.Components
{
    public class HeaderComponentVM
    {
        public int Count { get; set; }

        public string SearchInput { get; set; }
        public List<Core.Entities.Product> Products { get; set; }
        public List<Core.Entities.BasketProduct> BasketProducts { get; set; }
    }
}
