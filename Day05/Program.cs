string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

int niceStrings = 0;

foreach (var line in data)
{
    bool lineSplitRepeats = false;

    for (int i = 0; i < line.Length - 2; i++)
    {
        string twoLetters = line.Substring(i, 2);

        // the idea is if we use replace at least twice
        // the length will be shorter than line.Length - 2
        // otherwise we replace it only once, therefore it would be equal

        if (line.Replace(twoLetters, "").Length < line.Length - 2)  
        {
            lineSplitRepeats = true;
            break;
        }
    }

    for (int i = 0; i < line.Length - 2; i++)
    {
        if (line[i] == line[i + 2] && lineSplitRepeats)
        {
            niceStrings++;
            break;
        }
    }
}

Console.WriteLine(niceStrings);