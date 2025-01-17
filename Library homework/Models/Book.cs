﻿namespace Library_homework.Models
{
    public class Book : Product
    {
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public Book(string name, decimal price, int count, string authorName, int pageCount) : base(name, price, count)
        {
            PageCount = pageCount;
            AuthorName = authorName;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} \tName : {Name} \tPrice: {Price} \tCount: {Count} \tAuthor Name: {AuthorName} \tPage count: {PageCount}");
        }

        public override void Sell()
        {
            if (Count <= 0)
            {
                throw new ProductCountIsZeroException("There are no books left.");
            }
            Count--;
            TotalIncome += Price;
        }
    }
}