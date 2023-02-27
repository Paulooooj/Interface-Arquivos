using HerancaeInterface.Entities;
using HerancaeInterface.Entities.Enums;

namespace HerancaeInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
            IShape s1 = new Circle() { Radius = 2.0, Color = Color.Black };
            IShape s2 = new Rectangle() { Width = 3.5, Height = 4.2, Color = Color.White };
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}