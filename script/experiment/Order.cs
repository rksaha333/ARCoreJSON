using System;

namespace DefaultNamespace
{
    [Serializable]
    public class Order
    {
        public string createdAt;
        public State state;
        public string order_url;
        
        public string updatedAt;
        public string customer_url;
        public Actions actions;
        public string items_url;
        public string total;
    }
}