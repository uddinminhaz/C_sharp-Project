using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement2
{
    class Product
    {
        private string pId;
        private string productName;
        private string ProductType;
        private int quantity;
        private float buyingPrice;
        private float sellingPrice;
        private int totalSold;
        private float profit;
        private string Division;
        private string Districts;

        UpdateDBlink ul = new UpdateDBlink();




        public Product(String productName, string ProductType, string Division, string Districts, int quantity, float buyingPrice, int totalSold,
            float sellingPrice, float profit)
        {
            
            this.productName = productName;
            this.quantity = quantity;
            this.buyingPrice = buyingPrice;
            this.sellingPrice = sellingPrice;
            this.totalSold = totalSold;
            this.profit = profit;
            this.ProductType = ProductType;
            this.Division = Division;
            this.Districts = Districts;
          

        }

        public Product()
        {
            
        }

        public String ProductName
        {
            set { this.productName = value; }
            get { return this.productName; }
        }

       public String DivisionP
        {
            set { this.Division = value; }
            get { return this.Division; }
        }

        public String DistrictsP
        {
            set { this.Districts = value; }
            get { return this.Districts; }
        } 

        public String Product_Type
        {
            set { this.ProductType = value; }
            get { return this.ProductType; }
        }

        public int Quantity
        {
            set { this.quantity = value; }
            get { return this.quantity; }
        }

        public float BuyingPrice
        {
            set { this.buyingPrice = value; }
            get { return this.buyingPrice; }
        }

        public float SellingPrice
        {
            set { this.sellingPrice = value; }
            get { return this.sellingPrice; }
        }
        public int TotalSold
        {
            set { this.totalSold = value; }
            get { return this.totalSold; }
        }

        public float Profit
        {
            set { this.profit = value; }
            get { return this.profit; }
        }

        public String PID
        {
            set { this.pId = value; }
            get { return this.pId; }
        }

        public List<object> GetProducts()
        {
            List<object> p = ul.GetList();

            return p.ToList();
        }
  
    }
}
