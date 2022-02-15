using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Store
{
    public class GoodsCategory
    {
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ManufactoringDate { get; set; }

        public string WriteName()
        {
            return CategoryName;
        }
    }
}
