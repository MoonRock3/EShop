using TimirzinEShop.Areas.Identity.Data;

namespace TimirzinEShop.Models
{
    public class OrderModel
    {
        public OrderModel(Cart cart, EShopUser user)
        {
            Cart = cart;
            User = user;
        }

        public Cart Cart { get; }
        public EShopUser User { get; }
    }
}