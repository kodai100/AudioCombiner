using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio;
using NAudio.Lame;
using NAudio.Wave;

namespace AudioCombiner
{

    public class AudioProcess
    {

        
        public static void CreateMashup(string[] filePathes, string outputDirectoryPath, string outputFileName)
        {
            if (filePathes.Count() < 2)
            {
                throw new Exception("Not enough files selected!");
            }

            

            // Set the path to store the mashed up output file
            var outputFile = Path.Combine(outputDirectoryPath, outputFileName + ".mp3");

            using (var fs = File.OpenWrite(outputFile))
            {

                foreach (var filePath in filePathes)
                {
                    var buffer = File.ReadAllBytes(filePath);
                    fs.Write(buffer, 0, buffer.Length);
                }

                fs.Flush();

            }
                
        }
    }
}
