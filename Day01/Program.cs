string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllText(path);

int floor = 0;

for (int i = 0; i < data.Length; i++)
{
    if (data[i] == '(')
    {
        floor++;
    }
    else
    {
        floor--;
    }

    if (floor == -1)
    {
        Console.WriteLine(i + 1);
        break;
    }
}