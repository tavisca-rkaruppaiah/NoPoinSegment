using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPointSegment
{
    public class Points
    {
        public int X;
        public int Y;
    }

    public class NoPointSegment
    {
        private Points pointOne = new Points();
        private Points pointTwo = new Points();
        private Points pointThree = new Points();
        private Points pointFour = new Points();
        
        
        public string Intersection(int[] seg1, int[] seg2)
        {
            pointOne.X = seg1[0];
            pointOne.Y = seg1[1];
            pointTwo.X = seg1[2];
            pointTwo.Y = seg1[3];
            pointThree.X = seg2[0];
            pointThree.Y = seg2[1];
            pointFour.X = seg2[2];
            pointFour.Y = seg2[3];

            if (pointOne.X == pointTwo.X && pointTwo.X == pointThree.X && pointThree.X == pointFour.X)
            {
                return FunctionOne(pointOne, pointTwo, pointThree, pointFour);
            }
            else if (pointOne.Y == pointTwo.Y && pointTwo.Y == pointThree.Y && pointThree.Y == pointFour.Y)
            {
                return FuntionTwo(pointOne, pointTwo, pointThree, pointFour);
            }
            else if (pointOne.X == pointTwo.X && pointFour.Y == pointThree.Y)
            {
                return FunctionThree(pointOne, pointTwo, pointThree, pointFour);

            }
            else if (pointOne.Y == pointTwo.Y && pointThree.X == pointFour.X)
            {
                return FuntionFour(pointOne, pointTwo, pointThree, pointFour);
            }
            else
                return "NO";
        }

        private string FuntionFour(Points pointOne, Points pointTwo, Points pointThree, Points pointFour)
        {
            if (pointOne.X > pointTwo.X)
            {
                Points temp = pointOne;
                pointOne = pointTwo;
                pointTwo = temp;
            }
            if (pointThree.Y > pointFour.Y)
            {
                Points temp = pointThree;
                pointThree = pointFour;
                pointFour = temp;
            }

            int y = pointOne.Y;
            int x = pointThree.X;
            if ((pointThree.Y <= y && y <= pointFour.Y) && (pointOne.X <= x && x <= pointTwo.X))
                return "POINT";
            else
                return "NO";
        }

        private string FunctionThree(Points pointOne, Points pointTwo, Points pointThree, Points pointFour)
        {
            if (pointOne.Y > pointTwo.Y)
            {
                Points temp = pointOne;
                pointOne = pointTwo;
                pointTwo = temp;
            }
            if (pointThree.X > pointFour.X)
            {
                Points temp = pointThree;
                pointThree = pointFour;
                pointFour = temp;
            }

            int tempPointOne = pointOne.X;
            int tempPointTwo = pointThree.Y;
            if ((pointThree.X <= tempPointOne && tempPointOne <= pointFour.X) && (pointOne.Y <= tempPointTwo && tempPointTwo <= pointTwo.Y))
                return "POINT";
            else
                return "NO";
        }

        private string FuntionTwo(Points pointOne, Points pointTwo, Points pointThree, Points pointFour)
        {
            if (pointOne.X > pointTwo.X)
            {
                Points temp = pointOne;
                pointOne = pointTwo;
                pointTwo = temp;
            }
            if (pointThree.X > pointFour.X)
            {
                Points temp = pointThree;
                pointThree = pointFour;
                pointFour = temp;
            }
            if (pointOne.X > pointThree.X)
            {
                Points tempPointOne = pointOne;
                Points tempPointTwo = pointTwo;
                pointOne = pointThree;
                pointTwo = pointFour;
                pointThree = tempPointOne;
                pointFour = tempPointTwo;
            }
            if (pointTwo.X == pointThree.X)
                return "POINT";
            else if (pointThree.X < pointTwo.X)
            {
                if (CheckPoint(pointOne, pointTwo) || CheckPoint(pointThree, pointFour))

                    return "POINT";
                else
                    return "SEGMENT";

            }
            else
                return "NO";
        }

        private string FunctionOne(Points pointOne, Points pointTwo, Points pointThree, Points pointFour)
        {
            if (pointOne.Y > pointTwo.Y)
            {
                Points point = pointOne;
                pointOne = pointTwo;
                pointTwo = point;
            }
            if (pointThree.Y > pointFour.Y)
            {
                Points point = pointThree;
                pointThree = pointFour;
                pointFour = point;
            }
            if (pointOne.Y > pointThree.Y)
            {
                Points x = pointOne;
                Points y = pointTwo;
                pointOne = pointThree;
                pointTwo = pointFour;
                pointThree = x;
                pointFour = y;
            }
            if (pointTwo.Y == pointThree.Y)
                return "POINT";
            else if (pointThree.Y < pointTwo.Y)
            {
                if (CheckPoint(pointOne, pointTwo) || CheckPoint(pointThree, pointFour))

                    return "POINT";
                else
                    return "SEGMENT";
            }

            else
                return "NO";
        }

        public static bool CheckPoint(Points point1, Points point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }
        
        #region Testing code Do not change
        public static void Main(String[] args)
        {
            string input = Console.ReadLine();
            NoPointSegment solver = new NoPointSegment();
            do
            {
                var segments = input.Split('|');
                var segParts = segments[0].Split(',');
                var seg1 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                segParts = segments[1].Split(',');
                var seg2 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                Console.WriteLine(solver.Intersection(seg1, seg2));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}
