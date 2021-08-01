using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCCoreAppTemp
{
    public class TempFile:IDisposable
    {
        string FileName { get; }
        string FolderName { get; }
        FileStream fileStream;
        Byte[] Data;
        public TempFile()
        {
            FolderName= $@"D:\File Trials";
            Directory.CreateDirectory(FolderName);
            FileName = $@"D:\File Trials\TempFile {DateTime.Now.ToLongTimeString()
                                                               .Replace(":", string.Empty)}.dat";
            fileStream = new FileStream(FileName, FileMode.OpenOrCreate);
            Data = new byte[] { 1, 2, 3, 4, 5, 6, 7 };
            fileStream.Write(Data??new byte[] { }, 0, Data?.Length??0);
            fileStream.Close();
            Console.WriteLine($"Ctor -File {FileName} Created");

            //With No Finalizer @ Clr shutdown
            //Subs To End of Process Event
            AppDomain.CurrentDomain.ProcessExit+=(sender, e) =>
             {
                 Console.WriteLine("Process Exit Handler ");
                 Dispose();
             };
        }

        public void DoSomeFileWork()
        {
            Console.WriteLine("Processing......");
        }

        //Destructor , Has no Access Modifier , No Specific return DT , no Input Paramaters 
        ~ TempFile()
        {
            File.Delete(FileName);
            Console.WriteLine("Dest-FileDeleted");
        }

        void Dispose(bool isDisposing)
        {
            // Call From Dsrtructor {Dispose(false)}  {Clean Unmanaged}
            //call From Dispose{ Dispose(True)} {Clean Unmanaged and Manged Resourses}
        }
        public void Dispose()
        {
            File.Delete(FileName);
            Console.WriteLine("Dispose-FileDeleted");
            GC.SuppressFinalize(this);
        }

      


    }
}
