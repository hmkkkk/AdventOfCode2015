using System.Security.Cryptography;

string input = "yzbqklnj";

for (int i = 0; i < 10000000; i++)
{
    using (MD5 md5 = MD5.Create())
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input + i.ToString());
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        var hex = Convert.ToHexString(hashBytes);
        if (hex.Substring(0, 6) == "000000")
        {
            Console.WriteLine(hex);
            break;
        }
    }

}
