using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2016.Day_03 {

    class Shape {

        int a;
        int b;
        int c;

        public Shape(int a, int b, int c) {
            this.a = a;
            this.b = b;
            this.c = c;
            }

        public bool IsTriangle() {
            if (a + b > c && a + c > b && c + b > a) return true; ;
            return false;
            }
        }
    class Triangles {

        List<Shape> triangles;
        List<Shape> shapes;

        public Triangles(string path) {
            shapes = new List<Shape>();
            triangles = new List<Shape>();
            //LoadTriangles(path);
            LoadShapes(path);
            }

        public int Count() {
            return triangles.Count();
            }

        // part 1
        void LoadTriangles(string path) {

            try {
                foreach (string line in File.ReadLines(path)) {
                    string[] stringSides = line.Split(new Char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);

                    Shape shape = new Shape(Convert.ToInt32(stringSides[0]), Convert.ToInt32(stringSides[1]), Convert.ToInt32(stringSides[2]));
                    if (shape.IsTriangle()) triangles.Add(shape);
                        
                    }
                }
            catch (IOException e) {
                Console.WriteLine(e.Message);
                }
            }

        // part 2
        void LoadShapes(string path) {

            try {
                List<string> lines = File.ReadLines(path).ToList();
                
                while (lines.Count() > 0) {

                    string[] stringSides_1 = lines.ElementAt(0).Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] stringSides_2 = lines.ElementAt(1).Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] stringSides_3 = lines.ElementAt(2).Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    Shape shape_1 = new Shape(Convert.ToInt32(stringSides_1[0]), Convert.ToInt32(stringSides_2[0]), Convert.ToInt32(stringSides_3[0]));
                    Shape shape_2 = new Shape(Convert.ToInt32(stringSides_1[1]), Convert.ToInt32(stringSides_2[1]), Convert.ToInt32(stringSides_3[1]));
                    Shape shape_3 = new Shape(Convert.ToInt32(stringSides_1[2]), Convert.ToInt32(stringSides_2[2]), Convert.ToInt32(stringSides_3[2]));
                    
                    shapes.Add(shape_1);
                    shapes.Add(shape_2);
                    shapes.Add(shape_3);

                    lines.RemoveAt(0);
                    lines.RemoveAt(0);
                    lines.RemoveAt(0);
                    }

                foreach (Shape s in shapes) if (s.IsTriangle()) triangles.Add(s);
                }
            catch (IOException e) {
                Console.WriteLine(e.Message);
                }
            }
        }
    }
