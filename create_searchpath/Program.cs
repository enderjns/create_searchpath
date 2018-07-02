using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace create_searchpath
{
    class Program
    {
        static void Main(string[] args)
        {
            // Befehlszeilenargumente auslesen
            string[] CommandLineArgs = Environment.GetCommandLineArgs();
            string[] folderPath;
            string[] searchPaths = new string[CommandLineArgs.Length];
            string filePath = "";
            char delimiter='\\';
            int count = 0;
            int txtPart1Length = 0;
            // CommandLineArgs[0] ist immer der Dateipfad
            if (CommandLineArgs.Length > 1)
            {
                foreach (string p in CommandLineArgs)
                {
                    if (count >= 1)
                    {
                        folderPath = p.Split(delimiter);
                        // Console.WriteLine(count.ToString);
                        Console.WriteLine(CommandLineArgs[count].ToString());
                        Console.WriteLine(folderPath[folderPath.Length-1].ToString());
                        // die Ordner als Zeile in das string-Array schreiben
                        searchPaths[count] = "searchpath .\\" + folderPath[folderPath.Length - 1].ToString();
                        // vom aktuellen Argument den Pfad rausziehen
                        filePath = CommandLineArgs[count];
                        Console.WriteLine(folderPath[folderPath.Length - 1].ToString());
                        txtPart1Length = folderPath[folderPath.Length - 1].Length;
                        filePath = filePath.Substring(0, filePath.Length - txtPart1Length);
                    }
                    count++;
                }
                Console.WriteLine(txtPart1Length.ToString());
                Console.WriteLine(filePath);
                // jetzt in die datei schreiben
                System.IO.File.WriteAllLines(@filePath+"\\suchpfade_nachladen.pro", searchPaths);
            }


            // Warte auf Eingabe
            Console.ReadLine();

            {

            }
        }
    }
}



