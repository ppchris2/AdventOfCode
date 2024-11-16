Console.WriteLine();
// //using System.Drawing;
// //using System.Numerics;
// //using System.Reflection;
// //using System.Security;
//
// //var example1 = @"-L|F7
// //7S-7|
// //L|7||
// //-L-J|
// //L|-JF";
//
// //var example2 = @"7-F7-
// //.FJ|7
// //SJLL7
// //|F--J
// //LJ.LJ";
//
//
// //var lines = File.ReadAllLines("C:\\Users\\ppchr\\source\\repos\\advent-of-code-2023\\Day10\\input.txt");
//
// //var line = Array.FindIndex(lines, x => x.Contains("S"));
// //var startingPoint = lines[line].ToArray();
// //var position = Array.FindIndex(startingPoint, x => x=='S');
//
// //var distance = 0;
// //char elementAtStep = lines[line][position];
// ////var start = new Point(line, position);
// //var currentPoint = new Point(line, position);
// //Point? previouStep = null;
// //do
// //{
// //    distance++;
//
// //    var step = GetPossibleNextSteps(elementAtStep, currentPoint)
// //        .Where(x =>
// //            (previouStep is null || x != previouStep) &&
// //            IsInsideBounds(x, lines.Length, lines[0].Length))
// //        .LastOrDefault();
//
// //    previouStep = currentPoint;
// //    currentPoint = step;
// //    elementAtStep = lines[step.X][step.Y];
// //} while (elementAtStep != 'S');
//
// //Console.WriteLine(distance / 2);
//
//
// //bool IsInsideBounds(Point point, int xAxis, int yAxis)
// //{
// //    return point.X < xAxis && point.Y < yAxis && point.X >= 0 && point.Y >= 0;
// //}
//
// //Point[] GetPossibleNextSteps(char currentTile, Point currentPosition)
// //{
// //    Point katw = new Point(currentPosition.X + 1, currentPosition.Y);
// //    Point panw = new Point(currentPosition.X - 1, currentPosition.Y);
// //    Point deksia = new Point(currentPosition.X, currentPosition.Y + 1);
// //    Point aristera = new Point(currentPosition.X, currentPosition.Y - 1);
// //    switch (currentTile)
// //    {
// //        case 'S':
//
// //            //den mporeis na krathseis ta non valid paths dhladh ena - panw
// //            return new[] { 
// //                panw, katw, deksia, aristera
// //            };
// //        case '-':
// //            return new[] {
// //                deksia, aristera
// //            };
// //        case '|':
// //            return new[] {
// //                panw, katw
// //            };
// //        case 'L':
// //            return new[] {
// //                panw, deksia
// //            };
// //        case 'J':
// //            return new[] {
// //                panw, aristera
// //            };
// //        case '7':
// //            return new[] {
// //                aristera, katw
// //            };
// //        case 'F':
// //            return new[] {
// //                deksia, katw
// //            };
// //        default:
// //            return Array.Empty<Point>();
// //    }
//
// //}
//
//
//
//
// //part 2 
// using System.Drawing;
//
// var example = 
// @"...........
// .S-------7.
// .|F-----7|.
// .||.....||.
// .||.....||.
// .|L-7.F-J|.
// .|..|.|..|.
// .L--J.L--J.
// ...........";
//
//
// var lines = example.Split('\n');// File.ReadAllLines("C:\\Users\\ppchr\\source\\repos\\advent-of-code-2023\\Day10\\input.txt");
//
// var line = Array.FindIndex(lines, x => x.Contains("S"));
// var startingPoint = lines[line].ToArray();
// var position = Array.FindIndex(startingPoint, x => x == 'S');
//
//
// char elementAtStep = lines[line][position];
// //var start = new Point(line, position);
// var currentPoint = new Point(line, position);
// Point? previouStep = null;
//
// List<Point> path = new List<Point>();
// do
// {
//     var step = GetPossibleNextSteps(elementAtStep, currentPoint)
//         .Where(x =>
//             (previouStep is null || x != previouStep) &&
//             IsInsideBounds(x, lines.Length, lines[0].Length) &&
//
//             lines[x.X][x.Y] != '.'
//             ) 
//         .LastOrDefault();
//
//     previouStep = currentPoint;
//     currentPoint = step;
//     elementAtStep = lines[step.X][step.Y];
//
//     path.Add(step);
//
// } while (elementAtStep != 'S');
//
//
//
//
// ;
// void Fill(ColourPoint colourPoint)
// {
//     if (!Inside(colourPoint))
//     {
//         return;
//     }
//     var point = colourPoint.Point;
//
//     var queue = new Queue<(int x1, int x2, int y1, int y2)>();
//     queue.Enqueue((point.X, point.X, point.Y, 1));
//     queue.Enqueue((point.X, point.X, point.Y - 1, -1));
//
//     while(queue.Count > 0)
//     {
//         var (x1, x2, y, dy) = queue.Dequeue();
//         var x = x1;
//         if(Inside2(x, y))
//         {
//             while(Inside2(x - 1, y))
//             {
//                 Set2(x - 1, y);
//                 x = x - 1;
//                 if(x < x1)
//                 {
//                     queue.Enqueue((x, x1 - 1, y - dy, -dy));
//                 }
//             }
//         }
//         while (x1 <= x2)
//         {
//             while(Inside2(x1, y))
//             {
//                 Set2(x1, y);
//                 x1 = x1 + 1;
//             }
//             if (x1 > x) 
//             {
//                 queue.Enqueue((x, x1 - 1, y + dy, dy));
//             }
//             if (x1 - 1 > x2)
//             {
//                 queue.Enqueue((x2 + 1, x1 - 1, y - dy, -dy));
//
//             }
//             x1 = x1 + 1;
//             while (x1 < x2 && !Inside2(x1, y))
//             {
//                 x1 = x1 + 1;
//             }
//             x = x1;
//         }
//     }
//
// }
//
//
// //One called Inside which returns true for unfilled points that, by their color, would be inside the filled area,
// //Set which fills a pixel/node. Any node that has Set called on it must then no longer be Inside. 
//
// bool Inside(ColourPoint point)
// {
//     if (point.IsColoured) 
//     { 
//         return false; 
//     }
//     
//     //need to implement "inside the filled area"
//     if(path.)
//
//     return true;
// }
//
// bool Inside2(int x, int y)
// {
//     return Inside(new ColourPoint(x, y));
// }
//
// void Set (ColourPoint point)
// {
//     point.IsColoured = true;
// }
// void Set2(int x, int y)
// {
//     Set(new ColourPoint(x, y));
// }
//
//
//
// bool IsInsideBounds(Point point, int xAxis, int yAxis)
// {
//     return point.X < xAxis && point.Y < yAxis && point.X >= 0 && point.Y >= 0;
// }
//
// Point[] GetPossibleNextSteps(char currentTile, Point currentPosition)
// {
//     Point katw = new Point(currentPosition.X + 1, currentPosition.Y);
//     Point panw = new Point(currentPosition.X - 1, currentPosition.Y);
//     Point deksia = new Point(currentPosition.X, currentPosition.Y + 1);
//     Point aristera = new Point(currentPosition.X, currentPosition.Y - 1);
//     switch (currentTile)
//     {
//         case 'S':
//
//             //den mporeis na krathseis ta non valid paths dhladh ena - panw
//             return new[] {
//                 panw, katw, deksia, aristera
//             };
//         case '-':
//             return new[] {
//                 deksia, aristera
//             };
//         case '|':
//             return new[] {
//                 panw, katw
//             };
//         case 'L':
//             return new[] {
//                 panw, deksia
//             };
//         case 'J':
//             return new[] {
//                 panw, aristera
//             };
//         case '7':
//             return new[] {
//                 aristera, katw
//             };
//         case 'F':
//             return new[] {
//                 deksia, katw
//             };
//         default:
//             return Array.Empty<Point>();
//     }
//
// }
//
//
// struct ColourPoint
// {
//     public ColourPoint(int x, int y)
//     {
//         Point = new Point(x, y);
//     }
//     public Point Point { get; set; }
//     public bool IsColoured { get; set; }
// }
//
//
//
//
//
