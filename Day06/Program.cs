using System.Drawing;

string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

var grid = new int[1000, 1000];

int totalBrightness = 0;

foreach (var line in data)
{
    var lineSplit = line.Split(' ');

    if (line.StartsWith("toggle"))
    {
        var startCoords = lineSplit[1].Split(",");
        var finishCoords = lineSplit[3].Split(",");

        var startPoint = new Point(Int32.Parse(startCoords[0]), Int32.Parse(startCoords[1]));
        var finishPoint = new Point(Int32.Parse(finishCoords[0]), Int32.Parse(finishCoords[1]));

        for (int i = startPoint.Y; i <= finishPoint.Y; i++)
        {
            for (int j = startPoint.X; j <= finishPoint.X; j++)
            {
                grid[j, i] += 2;
            }
        }
    }
    else if (line.StartsWith("turn"))
    {
        int brightnessLevelSwitch = lineSplit[1] == "on" ? 1 : -1;

        var startCoords = lineSplit[2].Split(",");
        var finishCoords = lineSplit[4].Split(",");

        var startPoint = new Point(Int32.Parse(startCoords[0]), Int32.Parse(startCoords[1]));
        var finishPoint = new Point(Int32.Parse(finishCoords[0]), Int32.Parse(finishCoords[1]));

        for (int i = startPoint.Y; i <= finishPoint.Y; i++)
        {
            for (int j = startPoint.X; j <= finishPoint.X; j++)
            {
                grid[j, i] += brightnessLevelSwitch;

                if (grid[j, i] < 0)
                {
                    grid[j, i] = 0;
                }
            }
        }
    }
}

for (int i = 0; i < 1000; i++)
{
    for (int j = 0; j < 1000; j++)
    {
        totalBrightness += grid[i, j];
    }
}

Console.WriteLine(totalBrightness);