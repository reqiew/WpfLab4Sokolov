using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLab4Sokolov 
{
    public class Comp : IComparer<Train<int>>
    {
        public int Compare(Train<int>? train1, Train<int>? train2)
        {
            if (train1 is null || train2 is null)
            {      
             throw new ArgumentException("Некорректное значение параметра");
            }
            return train1.Num - train2.Num; 
        }


    }
}
