using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageOrganizerService
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageOrganizer imageOrganizer = new ImageOrganizer(@"C:\Temp\Demos\Images");
        }
    }
}
