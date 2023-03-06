namespace Store
{
    public interface IOrderRepository
    {
        public Order Create();
        public Order GetById(int id);
        public void Update(Order order);
    }
}
