using System;
namespace GCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var tempFile = new TempFile())
            {
                tempFile.DoSomeFileWork();
            }


            //var tempFile = new TempFile();
            //try
            //{
            //    tempFile.DoSomeFileWork();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    tempFile.Dispose();
            //}
            //tempFile.Dispose();
            //tempFile = null;
            //GC.Collect();

            //int x = int.Parse(Console.ReadLine());
            //x++;
            //Console.WriteLine(x);
            //Console.ReadLine();
        }
    }
}
