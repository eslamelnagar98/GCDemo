using System;

namespace GCCoreAppTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Dispose

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
            #endregion

            TempFile tempfile = new TempFile();
            tempfile.DoSomeFileWork();
            //tempfile = null;
            //GC.Collect();
            //int x = int.Parse(Console.ReadLine());
            //x++;
            //Console.WriteLine(x);
            //Console.ReadLine();
        }
    }
}
