using LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAPI
    {
        event VoidHandler CollectionChanged;
        long GetCount();
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        void AddProduct(Product p);
        void RemoveProduct(Product p);
        void UpdateProduct(int id, Product product);

        List<string> GetColours();
        List<string> GetSizes();
        List<string> GetWeightUnits();
        List<string> GetLines();
        List<string> GetClasses();
        List<string> GetStyles();
        List<string> GetSubcategories();
        List<string> GetModels();
        List<string> GetSizeUnits();

        int GetSubcategoryIDByName(string name);
        int GetModelIDByName(string name);
        string GetSubcategoryNameByID(int id);
        string GetModelNameByID(int id);
    }
    public delegate void VoidHandler();
}
