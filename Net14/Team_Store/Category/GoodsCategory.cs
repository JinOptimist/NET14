using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Store
{
    public abstract class GoodsCategory
    {
        public abstract string CategoryName { get; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ManufactoringDate { get; set; }
    }
}
