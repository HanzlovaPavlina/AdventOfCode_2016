using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2016 {

    class Point {
        int x;
        int y;

        public Point(int x, int y) {
            this.x = x;
            this.y = y;
            }

        public int X { get { return x; } }
        public int Y { get { return y; } }


        public static bool operator ==(Point first, Point second) {
            if (first.X == second.X && first.Y == second.Y)
                return true;
            return false;
            }
        public static bool operator !=(Point first, Point second) {
            if (first.X == second.X && first.Y == second.Y)
                return false;
            return true;
            }

        public override int GetHashCode() { return x + y; }

        public override bool Equals(object obj) => this.Equals(obj as Point);
        public bool Equals(Point second) {
            if (X == second.X && Y == second.Y)
                return true;
            return false;
            }
        }
    }
