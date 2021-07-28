using System;
using System.IO;

namespace LineInSpaceBlackBoxTesting
{

    class Program
    {
        static void manual()
        {
            bool stop_flag = true;
            char choise;
            double x, y, z;

            do
            {
                Console.WriteLine("Point l11 :");
                x = Convert.ToDouble(Console.ReadLine());
                y = Convert.ToDouble(Console.ReadLine());
                z = Convert.ToDouble(Console.ReadLine());
                Point l11 = new Point(x, y, z);

                Console.WriteLine("Point l12 :");
                x = Convert.ToDouble(Console.ReadLine());
                y = Convert.ToDouble(Console.ReadLine());
                z = Convert.ToDouble(Console.ReadLine());
                Point l12 = new Point(x, y, z);

                Console.WriteLine("Point l21 :");
                x = Convert.ToDouble(Console.ReadLine());
                y = Convert.ToDouble(Console.ReadLine());
                z = Convert.ToDouble(Console.ReadLine());
                Point l21 = new Point(x, y, z);

                Console.WriteLine("Point l22 :");
                x = Convert.ToDouble(Console.ReadLine());
                y = Convert.ToDouble(Console.ReadLine());
                z = Convert.ToDouble(Console.ReadLine());
                Point l22 = new Point(x, y, z);

                Line l1 = new Line(l11, l12);
                Line l2 = new Line(l21, l22);

                Console.WriteLine($"Is Skew          : {l1.isSkewWithLine(l2)}");
                Console.WriteLine($"Is Parallel      : {l1.isParallelWithLine(l2)}");
                Console.WriteLine($"Is Intersect     : {l1.isIntersectWithLine(l2)}");
                Console.WriteLine($"Is Perpendicular : {l1.isPerpendicular(l2)}");

                Console.Write("\nDo you want to continue? [y/n]  ");
                choise = Convert.ToChar(Console.ReadLine());
                switch (choise)
                {
                    case 'y':
                        stop_flag = false;
                        break;
                    case 'n':
                        stop_flag = true;
                        break;
                    default:
                        break;
                }
            } while (!stop_flag);
        }

        static void parseString(string istr, ref Point[] arr, ref string label)
        {
            string[] splitted = istr.Split(' ');
            label = splitted[splitted.Length - 1];
            for (int i = 2, elem = 0; i < 12; i++)
            {
                arr[elem] = new Point(Convert.ToDouble(splitted[i - 2]),
                             Convert.ToDouble(splitted[i - 1]),
                             Convert.ToDouble(splitted[i]));
                if ((i + 1) % 3 == 0) elem++;
            }
        }

        static void Main(string[] args)
        {
            string perpFile = @"perpendicular.txt";
            string skewFile = @"skew.txt";
            string parllFile = @"parallel.txt";
            string intcFile = @"intersect.txt";

            Point[] points = new Point[4];
            Line[] lines_array = new Line[2];
            string lbl = "";

            string[] lines = File.ReadAllLines(perpFile);
            bool result;

            Console.WriteLine("----------- [ Perpendicular Test ] -----------");
            for (int i = 0; i < lines.Length; i++)
            {
                parseString(lines[i], ref points, ref lbl);
                lines_array[0] = new Line(points[0], points[1]);
                lines_array[1] = new Line(points[2], points[3]);
                result = lines_array[0].isPerpendicular(lines_array[1]);
                if (result == true && lbl == "true") result = true;
                else if (result == true && lbl == "false") result = false;
                if (result == false && lbl == "false") result = true;
                else if (result == false && lbl != "false") result = false;
                //Console.WriteLine($"PVec L1:  {lines_array[0].getPVec().ToString()}");
                //Console.WriteLine($"PVec L2:  {lines_array[1].getPVec().ToString()}");
                Console.WriteLine($"[ Test {i + 1} ] {result}");
            }

            lines = File.ReadAllLines(skewFile);
            result = false;
            Console.WriteLine("\n----------- [ Skew Test ] -----------");
            for (int i = 0; i < lines.Length; i++)
            {
                parseString(lines[i], ref points, ref lbl);
                lines_array[0] = new Line(points[0], points[1]);
                lines_array[1] = new Line(points[2], points[3]);
                result = lines_array[0].isSkewWithLine(lines_array[1]);
                if (result == true && lbl == "true") result = true;
                else if (result == true && lbl != "false") result = false;
                if (result == false && lbl == "false") result = true;
                else if (result == false && lbl != "false") result = false;
                //Console.WriteLine($"PVec L1:  {lines_array[0].getPVec().ToString()}");
                //Console.WriteLine($"PVec L2:  {lines_array[1].getPVec().ToString()}");
                Console.WriteLine($"[ Test {i + 1} ] {result}");
            }

            lines = File.ReadAllLines(parllFile);
            result = false;
            Console.WriteLine("\n----------- [ Parallel Test ] -----------");
            for (int i = 0; i < lines.Length; i++)
            {
                parseString(lines[i], ref points, ref lbl);
                lines_array[0] = new Line(points[0], points[1]);
                lines_array[1] = new Line(points[2], points[3]);
                result = lines_array[0].isParallelWithLine(lines_array[1]);
                if (result == true && lbl == "true") result = true;
                else if (result == true && lbl == "false") result = false;
                if (result == false && lbl != "false") result = true;
                else if (result == false && lbl != "false") result = false;
                //Console.WriteLine($"PVec L1:  {lines_array[0].getPVec().ToString()}");
                //Console.WriteLine($"PVec L2:  {lines_array[1].getPVec().ToString()}");
                Console.WriteLine($"[ Test {i + 1} ] {result}");
            }
            lines = File.ReadAllLines(intcFile);
            result = false;
            Console.WriteLine("\n----------- [ Intersect Test ] -----------");
            for (int i = 0; i < lines.Length; i++)
            {
                parseString(lines[i], ref points, ref lbl);
                lines_array[0] = new Line(points[0], points[1]);
                lines_array[1] = new Line(points[2], points[3]);
                result = lines_array[0].isIntersectWithLine(lines_array[1]);
                /*if(result == true && lbl =="true") result =true;
                else if(result == true && lbl != "false") result = false;
                if(result == false && lbl == "false") result = true;
                else if(result == false && lbl != "false") result = false;*/
                //Console.WriteLine($"PVec L1:  {lines_array[0].getPVec().ToString()}");
                //Console.WriteLine($"PVec L2:  {lines_array[1].getPVec().ToString()}");
                Console.WriteLine($"[ Test {i + 1} ] {result}");
            }

            //manual();
        }
    }
}


