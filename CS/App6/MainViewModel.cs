using System;
using System.Collections.ObjectModel;

namespace App6
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            CreateList();
        }

        public ObservableCollection<Product> ProductList { get; set; }
        void CreateList()
        {
            ProductList = new ObservableCollection<Product>();
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                Product p = new Product(i);
                p.UnitPrice = r.Next(1, 50);
                ProductList.Add(p);
            }
        }
    }
    public class Product
    {
        public Product(int i)
        {
            ProductName = "Product" + i;
            Discontinued = i % 5 == 0;
        }

        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}
