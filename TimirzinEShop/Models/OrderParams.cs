namespace TimirzinEShop.Models
{
    public class OrderParams
    {
        public OrderParams(Cart cart, ClientInfo clientInfo)
        {
            Cart = cart;
            ClientInfo = clientInfo;
        }

        public Cart Cart { get; set; }
        public ClientInfo ClientInfo { get; set; }
    }
}