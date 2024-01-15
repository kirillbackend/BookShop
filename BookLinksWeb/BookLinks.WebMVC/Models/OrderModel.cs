namespace BookLinks.WebMVC.Models
{
    public class OrderModel : BaseModel
    {
        public decimal Price { get; set; }
        public int NumberGoods { get; set; }
        public int UserId { get; set; }
        public UserModel? User { get; set; }
        public bool IsActive { get; set; }
        public List<BookOrderModel> BookOrdersModel { get; set; }
    }
}
