using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLab4Sokolov
{
    public class Train <T>: ICloneable, IComparable
    {
        public T? Num { get; set; }
        public string? Punkt { get; set; }
        public TimeOnly Time { get; set; }
        
        public static int Count = 0;
        public object Clone()
        {
            return new Train<T>()
            {
                Num = this.Num,
                Punkt = this.Punkt,
                Time = this.Time,
             
            };
        }
        public int CompareTo(object? obj)
        {
            if (obj is Train<T>)
            {
                Train<T>? train = obj as Train<T>;
                return this.Time.CompareTo(train!.Time);
            }
            else throw new Exception("Невозможно сравнить два объекта");
        }
        
        

    }
}
