using FIleManagement.Model;

namespace FIleManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DLList<char> FileList = new();
            //StreamReader reader;
            int TotalCharCount = 0;
            char ch;
            string file = @"C:\tmp\file.txt";
            GenericNode<char> node;
            try
            {
                using StreamReader? reader = new StreamReader(file);
                while (reader.Peek() >= 0)
                {
                    ch = (char)reader.Read();
                    if ((Convert.ToInt32(ch) == 13) || (Convert.ToInt32(ch) == 10))
                    {
                        reader.Read();
                        continue;
                    }
                    node = FileList.GetPosition(ch)!;
                    if (node != null)
                    {
                        FileList.IncreaseCount(node);
                    }
                    else
                    {
                        FileList.InsertLast(ch);
                    }
                    TotalCharCount++;
                }
                //reader.Close();
                Console.WriteLine("Traverse...");
                Console.WriteLine($"TotalChars: {TotalCharCount}");
                FileList.Traverse(TotalCharCount);

                Console.WriteLine("Traverse... By char Asc");
                FileList.SortByValueAsc();
                FileList.Traverse(TotalCharCount);

                Console.WriteLine("Traverse... By Char Frequency");
                FileList.SortByFrequencyDesc();
                FileList.Traverse(TotalCharCount);
            }
            catch (FileNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (IOException e2)
            {
                Console.WriteLine(e2.Message);
            }
        }
    }
}
