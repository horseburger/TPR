using System.Collections.Generic;
using System.Threading.Tasks;
using LINQ;
using LINQProgram;

namespace Service
{
    public class API : IAPI
    {
        public event VoidHandler CollectionChanged;

        public API()
        {
        }

       

        public void AddProduct(Product p)
        {
            Task.Run(() =>
            {
                Operations.AddProduct(p);
                CollectionChanged?.Invoke();
            });
        }

        public void RemoveProduct(Product p)
        {
            Task.Run( () =>
            {
                Operations.RemoveProduct(p);
                CollectionChanged?.Invoke();
            });
        }

        public void UpdateProduct(int id, Product product)
        {
            Task.Run(() =>
           {
               Operations.UpdateProduct(id, product);
               CollectionChanged?.Invoke();
           });
        }

        public List<string> GetColours()
        {
            return Operations.GetColours();
        }

        public List<string> GetSizes()
        {
            return Operations.GetSizes();
        }

        public List<string> GetWeightUnits()
        {
            return Operations.GetWeightUnits();
        }

        public List<string> GetLines()
        {
            return Operations.GetLines();
        }

        public List<string> GetClasses()
        {
            return Operations.GetClasses();
        }

        public List<string> GetStyles()
        {
            return Operations.GetStyles();
        }

        public List<string> GetSubcategories()
        {
            return Operations.GetSubcategories();
        }

        public List<string> GetModels()
        {
            return Operations.GetModels();
        }

        public List<string> GetSizeUnits()
        {
            return Operations.GetSizeUnits();
        }

        public int GetSubcategoryIDByName(string name)
        {
            return Operations.GetSubcategoryIDByName(name);
        }

        public int GetModelIDByName(string name)
        {
            return Operations.GetModelIDByName(name);
        }

        public string GetSubcategoryNameByID(int id)
        {
            return Operations.GetSubcategoryNameByID(id);
        }

        public string GetModelNameByID(int id)
        {
            return Operations.GetModelNameByID(id);
        }

        public long GetCount()
        {
            return Operations.GetCount();
        }

        public Product GetProductById(int id)
        {
            return Operations.GetProductById(id);
        }

        public List<Product> GetAllProducts()
        {
            return GetAllProducts();
        }

        Product IAPI.GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }

        List<Product> IAPI.GetAllProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
