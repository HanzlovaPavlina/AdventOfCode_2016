using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2016 {
    class Program {
        static void Main(string[] args) {

            //Day_01.EasterBunnyHeadquarters HQ = new Day_01.EasterBunnyHeadquarters("../../Day_01/my_input.txt");
            //Console.WriteLine(HQ.GetDistance());

            //Day_02.BathroomSecurity sec = new Day_02.BathroomSecurity("../../Day_02/my_input.txt");
            
            Day_03.Triangles triangles = new Day_03.Triangles("../../Day_03_Squares With Three Sides/my_input.txt");
            Console.WriteLine(triangles.Count());

            Console.ReadKey();
            
            }
        }
    }
