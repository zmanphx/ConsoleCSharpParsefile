using System;
using System.IO;
namespace firstConsole
{
    internal class Program
    {
        private class ParseFile
        {
            protected int NumOfFields;
            protected string Format;
            protected string FileLocation;

            public ParseFile(string FileLocation, string Format, int NumOfFields)
            {
                this.FileLocation = FileLocation;
                this.Format = Format;
                this.NumOfFields = NumOfFields;
            }

            public void ProcessDirectory()
            {
                // Go to directory and find the first file
                // process file
                //Go to next file

                foreach (string file in Directory.GetFiles(FileLocation))
                {
                    ProcessFile(file);
                }
            }

            private void ProcessFile(string f)
            {
                int FieldCount = 0;
                string line;

                try
                {
                    //Passing the file path and file name  and type
                    StreamReader sr = new StreamReader(f);
                    sr.ReadLine(); //Reading first record i.e.header don't do anything with it

                    while (sr.Peek() != -1)
                    {
                        line = sr.ReadLine();

                        FieldCount = line.Split(Format).Length - 1;

                        if (FieldCount == NumOfFields - 1)
                        {
                            // Write or append to new file in processed folder
                            using (StreamWriter sw = File.AppendText(FileLocation + "\\processed\\" + "correct.txt"))
                            {
                                sw.WriteLine(line);
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(FileLocation + "\\processed\\" + "Incorrect.txt"))
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            }
        }

        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Runbeck Text file parser--Enter File Format : 1. Tab-delimited 2. CSV");
                int FormatType = int.Parse(Console.ReadLine());
                if (FormatType == 1 || FormatType == 2)
                {
                    Console.WriteLine("Enter number of fields");
                    int ManyFields = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Path to file");
                    var DirPath = @"" + Console.ReadLine();
                    //Validate the string path
                    if (Directory.Exists(DirPath))
                    {
                        var FormatString = (FormatType == 1) ? "\t" : ","; // pass formattype based on int value
                        ParseFile PF = new ParseFile(DirPath, FormatString, ManyFields); // create object of ParseFile
                        PF.ProcessDirectory();
                    }
                    else
                    {
                        Console.WriteLine("{0}  is not a valid directory", DirPath);
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("{0} Is an invalid input", FormatType);
                    Console.ReadLine();
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}