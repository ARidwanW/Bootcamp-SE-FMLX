using System.Text;

class Program
{
    public static void Main()
    {
        using (FileStream fs = File.OpenRead("TrialUsing.txt"))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }
        }

        using (FileStream fs = new FileStream("myFile.txt", FileMode.OpenOrCreate))
        {
            string data = "menambahkan file baru";

            byte[] bytesToWrite = Encoding.UTF8.GetBytes(data);
            fs.Write(bytesToWrite, 0, bytesToWrite.Length);
        }

        using (FileStream fs = new FileStream("myFile.txt", FileMode.Open))
        {
            byte[] bytesToRead = new byte[1024];
            int bytesRead = fs.Read(bytesToRead, 0, bytesToRead.Length);

            string dataRead = Encoding.UTF8.GetString(bytesToRead, 0, bytesRead);
            Console.WriteLine(dataRead);
        }
    }
}