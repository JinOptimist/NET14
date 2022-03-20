using System;
using System.Collections.Generic;
using System.Linq;

namespace Net14.Web.Models.Shulte
{
    public class RandomNumberViewModel
    {
        public List<int> Random()
        {
            var array = Enumerable.Range(1, 24).ToList();
            var random = new Random();
            for (int i = array.Count - 1; i >= 0; i--)
            {
                int j = random.Next(i);
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;

        }
    }
}
