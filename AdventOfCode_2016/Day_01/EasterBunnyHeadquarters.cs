using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2016.Day_01 {
    class Move {
        public char rotation;
        public int stepsCount;

        public Move(char r, int s) {
            rotation = r;
            stepsCount = s;
            }
        }

    class Bunny {

        char direction;
        HashSet<Point> visited;
        Point actual;

        public Bunny() {
            direction = 'N';
            actual = new Point(0, 0);
            visited = new HashSet<Point>();
            visited.Add(actual);
            }

        public Point Actual { get { return actual; } }

        public void Rotate(char rotation) {
            switch (direction) {
                case 'N': direction = rotation == 'R' ? 'E' : 'W'; break;
                case 'S': direction = rotation == 'R' ? 'W' : 'E'; break;
                case 'W': direction = rotation == 'R' ? 'N' : 'S'; break;
                case 'E': direction = rotation == 'R' ? 'S' : 'N'; break;
                }
            }

        public bool DoOneStep() {

            // check, if new step was added to HashSet
            // true = we wasn't there yet
            // false = we was on this Point already
            bool added = false;
            try {
                switch (direction) {
                case 'N':
                    actual = new Point(actual.X, actual.Y - 1);
                    added = visited.Add(actual);
                    break;
                case 'S':
                    actual = new Point(actual.X, actual.Y + 1);
                    added = visited.Add(actual);
                    break;
                case 'W':
                    actual = new Point(actual.X - 1, actual.Y);
                    added = visited.Add(actual);
                    break;
                case 'E':
                    actual = new Point(actual.X + 1, actual.Y);
                    added = visited.Add(actual);
                    break;
                    }
                }
            catch {
                Console.WriteLine("Wrong direction:" + direction);
                }
            return added;
            }
        
        public void PrintVisitedPoints() {
            foreach(Point p in visited) {
                Console.WriteLine($"[{p.X}, {p.Y}]");
                }
            }
        }


    class EasterBunnyHeadquarters {

        List<Move> moves;

        public EasterBunnyHeadquarters(string path) {
            moves = new List<Move>();
            LoadMoves(path);
            }

        public int GetDistance() {

            bool firsStepToPoint;
            Bunny bunny = new Bunny();
            foreach(Move move in moves) {
                bunny.Rotate(move.rotation);
                while(move.stepsCount > 0) {
                    firsStepToPoint = bunny.DoOneStep();
                    if(!firsStepToPoint)
                        return Math.Abs(bunny.Actual.X) + Math.Abs(bunny.Actual.Y);
                    move.stepsCount--;
                    }
                }
            
            bunny.PrintVisitedPoints();
            return Math.Abs(bunny.Actual.X) + Math.Abs(bunny.Actual.Y);
            }

        void LoadMoves(string path) {

            try {
                foreach (string line in File.ReadLines(path)) {
                    string[] stringMoves = line.Split(new Char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string move in stringMoves) {
                        char rotate = move.First();
                        int stepCount = Convert.ToInt32(move.TrimStart(new Char[] { 'R', 'L' }));
                        moves.Add(new Move(rotate, stepCount));
                        }
                    }
                }
            catch (IOException e){
                Console.WriteLine(e.Message);
                }
            }
        }
    }
