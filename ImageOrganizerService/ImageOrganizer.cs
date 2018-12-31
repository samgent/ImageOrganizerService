using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ImageOrganizerService
{
    class ImageOrganizer
    {
        //private readonly Timer _timer;
        private string path;


        public ImageOrganizer(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    this.path = path;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            ProcessDirectory(path);
            //_timer = new Timer(10000) { AutoReset = true };
            //_timer.Elapsed += _TimerElapsed;
        }

        private void _TimerElapsed(object sender, ElapsedEventArgs e)
        {
            //Look for files in directory and if one exists, move the file to a folder corresponding to the same year as the file was created 
            //
        }

        public void ProcessDirectory(string targetDir)
        {
            string[] fileEntries = Directory.GetFiles(targetDir);

            foreach (var file in fileEntries)
            {
                //Console.WriteLine(GetDateModified(file));
                string year = GetDateModified(file).Year.ToString();
                string month = GetDateModified(file).ToString("MMM");
                string newPath = targetDir + @"\" + year + @"\" + month;
                try
                {
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
                MoveFile(file, newPath + @"\" + Path.GetFileName(file));
                //ProcessImage(file);
            }
        }

        //Argument example @"c:\test.txt");
        public DateTime GetDateModified(string file)
        {
            DateTime dateModified = File.GetLastWriteTime(file);
            return dateModified;
        }

        public void MoveFile (string from, string to)
        {
            File.Move(from, to);
        }

        public void ProcessImage(string file)
        {

        }

        public void Start()
        {

        }

        public void Stop()
        {

        }
    }
}
