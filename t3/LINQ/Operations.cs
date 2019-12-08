using LINQ;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProgram
{
    public class Operations
    {

        public static List<Product> GetProductsByName(string name)
        {
            ProductionDataContext productionDataContext = new ProductionDataContext();
            return (
                from product in productionDataContext.Product
                where SqlMethods.Like(product.Name, "%" + name + "%")
                select product
                ).ToList();
        }

    }
}
