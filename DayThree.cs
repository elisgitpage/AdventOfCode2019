using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode
{
    internal struct Point
    {
        public int x, y;

        public int ManhattanDistance()
        {
            return Math.Abs(x) + Math.Abs(y);
        }

        public Point(int c1, int c2)
        {
            x = c1;
            y = c2;
        }

        public Point AddPoint(Point p)
        {
            return new Point(this.x + p.x, this.y + p.y);
        }
    }

    internal class DayThree
    {
        public static void StartProblem()
        {
            string text = File.ReadAllText(@"..\..\input3.txt");
            string[] wireLines = text.Split('\n');
            //string[] wireLines = { "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7" };

            string[] wire1 = wireLines[0].Split(',');
            string[] wire2 = wireLines[1].Split(',');
            Point currentStart1 = new Point(0, 0);
            Point currentStart2 = new Point(0, 0);
            List<Point> wire1points = new List<Point>();
            List<Point> wire2points = new List<Point>();
            Point currentEnd1, currentEnd2;

            Console.WriteLine("WIRE 1 POINTS :\n\n");
            for (int i = 0; i < wire1.Count(); i++)
            {
                currentEnd1 = FindEnd(currentStart1, wire1[i], wire1points);
                Console.WriteLine("Command: {0}, New Point: X{1} Y{2}", wire1[i], currentEnd1.x, currentEnd1.y);
                currentStart1 = new Point(currentEnd1.x, currentEnd1.y);
            }

            wire1points = wire1points.OrderBy(p => p.ManhattanDistance()).ToList<Point>();

            Console.WriteLine("\n\nwire1points.Count() : {0}\n\n", wire1points.Count());

            Console.WriteLine("WIRE 2 POINTS :\n\n");
            for (int i = 0; i < wire2.Count(); i++)
            {
                currentEnd2 = FindEnd(currentStart2, wire2[i], wire2points);
                Console.WriteLine("Command: {0}, New Point: X{1} Y{2}", wire2[i], currentEnd2.x, currentEnd2.y);
                currentStart2 = new Point(currentEnd2.x, currentEnd2.y);
            }

            wire2points = wire2points.OrderBy(p => p.ManhattanDistance()).ToList<Point>();

            Console.WriteLine("\n\nwire2points.Count() : {0}", wire2points.Count());

            Point closestPoint = FindClosestIntersection(wire1points, wire2points);

            Console.WriteLine("Closest Intersection: X{0} Y{1}, Manhattan Distance: {2}", closestPoint.x, closestPoint.y, closestPoint.ManhattanDistance());
        }


        public static Point FindEnd(Point start, string line, List<Point> points)
        {
            string dir = line.Substring(0, 1);
            int.TryParse(line.Substring(1), out int mag);
            Point delta;
            switch (dir)
            {
                default:
                    delta = new Point(0, 0);
                    break;
                case "U":
                    delta = new Point(0, 1);
                    break;
                case "D":
                    delta = new Point(0, -1);
                    break;
                case "L":
                    delta = new Point(-1, 0);
                    break;
                case "R":
                    delta = new Point(1, 0);
                    break;
            }

            for (int i = 0; i < mag; i++)
            {
                Point thisPoint = points.Last().AddPoint(delta);
                points.Add(thisPoint);
            }
            
            return points.Last();
        }

        public static Point FindClosestIntersection(List<Point> w1p, List<Point> w2p)
        {

            for (int i = 0; i < w1p.Count(); i++)
            {
                for (int j = 0; j < w2p.Count(); j++)
                {
                    if (w1p[i].x == w2p[j].x && w1p[i].y == w2p[j].y)
                    {
                        return w1p[i];
                    }
                }
            }

            throw new Exception("No intersections found");
        }
        
    }
}