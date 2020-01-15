using System;
using System.Collections.Generic;
using System.ComponentModel;
using LINQ;
using Service;
using WPF_ViewModel.Commands;
using WPF_ViewModel.Interfaces;

namespace WPF_ViewModel
{
    public class AddProductViewModel : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Action Close { get; set; }

        private int _productID { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; } = null;
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; } = null;
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ProductSubcategoryID { get; set; }
        public string ModelId { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime SellStartDate { get; set; }

        // Display
        public List<string> Colors { get; set; }
        public List<bool> Flags { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> SizesUnits { get; set; }
        public List<string> WeightUnits { get; set; }
        public List<string> ProductLines { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Styles { get; set; }
        public List<string> ProductSubCategories { get; set; }
        public List<string> ModelIds { get; set; }

        public CustomCommand Confirm { get; set; }

        // API
        private IAPI api;


        public AddProductViewModel(IAPI api)
        {
            this.api = api;
            Confirm = new CustomCommand(AddProductImplementation);
            fillLists();
        }

        public AddProductViewModel(Product p, IAPI api)
        {
            this.api = api;
            this._productID = p.ProductID;
            this.ProductName = p.Name;
            this.ProductNumber = p.ProductNumber;
            this.MakeFlag = p.MakeFlag;
            this.FinishedGoodsFlag = p.FinishedGoodsFlag;
            this.Color = p.Color;
            this.SafetyStockLevel = p.SafetyStockLevel;
            this.ReorderPoint = p.ReorderPoint;
            this.StandardCost = p.StandardCost;
            ListPrice = p.ListPrice;
            Size = p.Size;
            SizeUnitMeasureCode = p.SizeUnitMeasureCode;
            WeightUnitMeasureCode = p.WeightUnitMeasureCode;
            Weight = p.Weight;
            DaysToManufacture = p.DaysToManufacture;
            ProductLine = p.ProductLine;
            Class = p.Class;
            Style = p.Style;
            ProductSubcategoryID = p.ProductSubcategoryID.HasValue ? api.GetSubcategoryNameByID(p.ProductSubcategoryID ?? 0) : null;
            ModelId = p.ProductModelID.HasValue ? api.GetModelNameByID(p.ProductModelID ?? 0) : null;
            this.SellStartDate = p.SellStartDate;
            this.SellEndDate = p.SellEndDate;

            fillLists();
            Confirm = new CustomCommand(UpdateProductImplementation);
        }

        private void fillLists()
        {
            this.Colors = this.api.GetColours();
            this.Flags = new List<bool>();
            Flags.Add(false);
            Flags.Add(true);
            this.Sizes = this.api.GetSizes();
            this.SizesUnits = this.api.GetSizeUnits();
            this.WeightUnits = this.api.GetWeightUnits();
            this.ProductLines = this.api.GetLines();
            this.Classes = this.api.GetClasses();
            this.Styles = this.api.GetStyles();
            this.ProductSubCategories = this.api.GetSubcategories();
            this.ModelIds = this.api.GetModels();
        }

        public void AddProductImplementation()
        {
            Product p = MakeProduct();
            if(p != null && p.Name.Length > 0)
            {
                this.api.AddProduct(p);
            }
            Close();
        }

        public void AddProductImplementationWithoutClose()
        {
            Product p = MakeProduct();
            if (p != null && p.Name.Length > 0)
            {
                this.api.AddProduct(p);
            }
        }

        public void UpdateProductImplementation()
        {
            Product p = MakeProduct();
            if (p != null && p.Name.Length > 0)
            {
                this.api.UpdateProduct(p.ProductID, p);
            }
            Close();
        }
        public void UpdateProductImplementationWithoutClose()
        {
            Product p = MakeProduct();
            if (p != null && p.Name.Length > 0)
            {
                this.api.UpdateProduct(p.ProductID, p);
            }
        }

        public void DeleteProductImplementation()
        {
            Product p = MakeProduct();
            this.api.RemoveProduct(p);
            Close();
        }
        public void DeleteProductImplementationWithoutClose()
        {
            Product p = MakeProduct();
            this.api.RemoveProduct(p);
        }

        private Product MakeProduct()
        {
            Product product = new Product();
            product.rowguid = new Guid();
            product.Name = this.ProductName;
            product.ProductNumber = this.ProductNumber;
            product.MakeFlag = this.MakeFlag;
            product.FinishedGoodsFlag = this.FinishedGoodsFlag;
            product.Color = this.Color;
            product.SafetyStockLevel = this.SafetyStockLevel;
            product.ReorderPoint = this.ReorderPoint;
            product.StandardCost = this.StandardCost;
            product.ListPrice = this.ListPrice;
            product.Size = this.Size;
            product.SizeUnitMeasureCode = this.SizeUnitMeasureCode;
            product.WeightUnitMeasureCode = this.WeightUnitMeasureCode;
            product.Weight = this.Weight;
            product.DaysToManufacture = this.DaysToManufacture;
            product.ProductLine = this.ProductLine;
            product.Class = this.Class;
            product.Style = this.Style;
            product.ProductSubcategoryID = (this.ProductSubcategoryID != null && this.ProductSubcategoryID.Length > 0) ?
                api.GetSubcategoryIDByName(this.ProductSubcategoryID) : (int?)null;
            product.ProductModelID = (this.ModelId != null && this.ModelId.Length > 0) ?
                api.GetModelIDByName(this.ModelId) : (int?)null;
            product.SellStartDate = this.SellStartDate;
            product.SellEndDate = this.SellEndDate;
            product.ModifiedDate = DateTime.Today;
            product.ProductID = _productID;
            return product;
        }
    }
}
