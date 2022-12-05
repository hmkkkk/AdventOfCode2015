string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

int totalArea = 0;

foreach (var line in data)
{
    string[] dimensions = line.Split("x");
    List<int> dimensionsInt = Array.ConvertAll(dimensions, Int32.Parse).ToList();

    int ribbonBow = dimensionsInt[0] * dimensionsInt[1] * dimensionsInt[2];

    int longestDimensionIndex = dimensionsInt.IndexOf(dimensionsInt.Max());

    dimensionsInt.RemoveAt(longestDimensionIndex);

    int ribbonWrap = dimensionsInt[0] * 2 + dimensionsInt[1] * 2;

    totalArea += ribbonWrap + ribbonBow;
}

Console.WriteLine(totalArea);