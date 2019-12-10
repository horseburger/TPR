using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ;

namespace LINQProgram
{
    public class NewProduct : Product
    {
        public string diff { get; set; }

        public NewProduct(Product p, string diff)
        {
            foreach(var prop in p.GetType().GetProperties())
            {
                if (prop.CanWrite)
                {
                    prop.SetValue(this, prop.GetValue(p));
                }
            }

            this.diff = diff;
        }
    }
}
