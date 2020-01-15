using LINQ;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLogicTest
{
    class API : IAPI
    {
        public event VoidHandler CollectionChanged;
        public Product NewProduct { get; set; }

        public void AddProduct(Product p)
        {
            NewProduct = p;
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>();
        }

        public List<string> GetClasses()
        {
            return new List<string>();
        }

        public List<string> GetColours()
        {
            return new List<string>();
        }

        public long GetCount()
        {
            return GetAllProducts().Count;
        }

        public List<string> GetLines()
        {
            return new List<string>();
        }

        public int GetModelIDByName(string name)
        {
            return 0;
        }

        public string GetModelNameByID(int id)
        {
            return "";
        }

        public List<string> GetModels()
        {
            return new List<string>();
        }

        public Product GetProductById(int id)
        {
            return new Product();
        }

        public List<string> GetSizes()
        {
            return new List<string>();
        }

        public List<string> GetSizeUnits()
        {
            return new List<string>();
        }

        public List<string> GetStyles()
        {
            return new List<string>();
        }

        public List<string> GetSubcategories()
        {
            return new List<string>();
        }

        public int GetSubcategoryIDByName(string name)
        {
            return 0;
        }

        public string GetSubcategoryNameByID(int id)
        {
            return "";
        }

        public List<string> GetWeightUnits()
        {
            return new List<string>();
        }

        public void RemoveProduct(Product p)
        {
            NewProduct = null;
        }

        public void UpdateProduct(int id, Product product)
        {
            NewProduct = product;
        }
    }
}
