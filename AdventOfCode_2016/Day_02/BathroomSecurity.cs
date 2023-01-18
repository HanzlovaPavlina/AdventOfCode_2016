using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2016.Day_02 {
    class BathroomSecurity {

        char[,] bathroom;
        Point actual;

        public BathroomSecurity(string path) {
            // part 1
            bathroom = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            actual = new Point(1, 1);
            LoadAndProcessMoves(path);

            // part 2
            bathroom = new char[,] { 
                { '0', '0', '1', '0', '0' },
                { '0', '2', '3', '4', '0' },
                { '5', '6', '7', '8', '9' },
                { '0', 'A', 'B', 'C', '0' },
                { '0', '0', 'D', '0', '0' },
                };
            actual = new Point(0, 2);
            LoadAndProcessMoves(path);
            }

        void LoadAndProcessMoves(string path) {

            foreach (string line in File.ReadLines(path)) {

                foreach (char move in line) {

                    Point next = actual;
                    switch (move) {
                        case 'L':
                            next = new Point(actual.X-1, actual.Y);
                            break;
                        case 'R':
                            next = new Point(actual.X+1, actual.Y);
                            break;
                        case 'D':
                            next = new Point(actual.X, actual.Y+1);
                            break;
                        case 'U':
                            next = new Point(actual.X, actual.Y-1);
                            break;
                        default:
                            break;
                        }
                    if (next.X < 0 || next.X >= bathroom.GetLength(1) || 
                        next.Y < 0 || next.Y >= bathroom.GetLength(0)) continue;
                    if (bathroom[next.Y, next.X] == '0') continue;
                    actual = next;
                    }
                Console.Write(bathroom[actual.Y, actual.X]);
                }
            Console.WriteLine();
            }
        }
    }
    
