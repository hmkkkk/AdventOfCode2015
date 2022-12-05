using System.Drawing;

namespace Day03;
class Program
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

        var data = File.ReadAllText(path);

        var housesVisited = new List<Point> { new Point(0, 0) };

        bool realSantasTurn = true;

        Point realSantasCoordinates = new Point(0, 0);
        Point roboSantasCoordinates = new Point(0, 0);

        foreach (var direction in data)
        {
            if (realSantasTurn)
            {
                MoveSanta(ref realSantasCoordinates, direction);

                if (!housesVisited.Any(x => x == realSantasCoordinates)) housesVisited.Add(realSantasCoordinates);
            }
            else
            {
                MoveSanta(ref roboSantasCoordinates, direction);

                if (!housesVisited.Any(x => x == roboSantasCoordinates)) housesVisited.Add(roboSantasCoordinates);
            }

            realSantasTurn = !realSantasTurn;
        }

        Console.WriteLine(housesVisited.Count);
    }

    private static void MoveSanta(ref Point santa, char direction)
    {
        switch (direction)
        {
            case '^':
                santa.Y++;
                break;
            case 'v':
                santa.Y--;
                break;
            case '>':
                santa.X++;
                break;
            case '<':
                santa.X--;
                break;
            default:
                break;
        }
    }
}