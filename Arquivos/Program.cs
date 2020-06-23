using System;
using System.Globalization;
using System.IO;

namespace Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o caminho do arquivo: ");
            string sourcePath = Console.ReadLine();
            
            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                string targetPath = Path.GetDirectoryName(sourcePath) + @"\out\Summary.csv";

                Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach(string line in lines)
                    {
                        string[] fields = line.Split(',');
                        double total = double.Parse(fields[1], CultureInfo.InvariantCulture) * int.Parse(fields[2]);
                        sw.WriteLine(fields[0] + ", " + total.ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Ocorreu um erro: " + e.Message);
            }
        }
    }
}
