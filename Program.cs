using System;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName1;
            string fileName2;
            string fileName3;
            string contin = "y";
            string line;
            bool good = false;
            int count = 0;
            Console.WriteLine("Welcome To The Document Merger!");

            while (contin == "y" | contin == "Y")
            {

                Console.WriteLine("What Is The Name Of The First File Document?");
                fileName1 = Console.ReadLine();
                if (!fileName1.Contains(".txt"))

                {

                    fileName1 = fileName1 + ".txt";

                }

                while (good == false)

                {

                    if (File.Exists(fileName1))

                    {

                        good = true;

                    }

                    else

                    {

                        Console.WriteLine("Invalid File Name. Please Use A Valid File Name.");
                        fileName1 = Console.ReadLine();

                    }

                }

                good = false;
                fileName1 = fileName1.Replace(".txt", "");
                Console.WriteLine("What Is The Name Of The Second File Document?");
                fileName2 = Console.ReadLine();
                if (!fileName2.Contains(".txt"))

                {

                    fileName2 = fileName2 + ".txt";

                }

                while (good == false)

                {

                    if (File.Exists(fileName2))

                    {

                        good = true;

                    }

                    else

                    {

                        Console.WriteLine("Invalid File Name. Please Use A Valid File Name.");
                        fileName2 = Console.ReadLine();

                    }

                }

                good = false;
                Console.WriteLine("What Is The New File Document Name? (Default: {0}{1})", fileName1, fileName2);
                fileName3 = Console.ReadLine();
                if (fileName3 == "")

                {

                    fileName3 = fileName1 + fileName2;

                }

                fileName1 = fileName1 + ".txt";
                try

                {

                    StreamReader file1 = new StreamReader(fileName1);
                    StreamReader file2 = new StreamReader(fileName2);
                    StreamWriter file3 = File.AppendText(fileName3);
                    while ((line = file1.ReadLine()) != null)

                    {

                        file3.WriteLine(line);
                        count = count + line.Length;

                    }

                    while ((line = file2.ReadLine()) != null)

                    {

                        file3.WriteLine(line);
                        count = count + line.Length;

                    }
                    file1.Close();
                    file2.Close();
                    file3.Close();
                    Console.WriteLine("{0} Was Successfully Saved. The Document Contains {1} Characters.", fileName3, count);

                }

                catch (Exception e)

                {

                    Console.WriteLine("Error!");
                    Console.WriteLine("{0}", e);

                }

                Console.WriteLine("Would You Like To Merge Two More Files? (Enter 'y' or 'Y' if yes)");
                contin = Console.ReadLine();

            }
        }
    }
}