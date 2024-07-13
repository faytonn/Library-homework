namespace Library_homework
{
    public abstract class Product
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalIncome { get; protected set; }
        public Product(string name, decimal price, int count)
        {
            Id = ++_id;
            Name = name;
            Price = price;
            Count = count;
        }

        public abstract void Sell();

        public abstract void ShowInfo();
    }
}