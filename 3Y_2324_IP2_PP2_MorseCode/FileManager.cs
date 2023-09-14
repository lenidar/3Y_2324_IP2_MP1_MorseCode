﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace _3Y_2324_IP2_PP2_MorseCode
{
    internal class FileManager
    {
        public bool fileCheck(string path)
        {
            if (File.Exists(path))
                return true;
            else
                return false;
        }

        public List<string> readFile(string path)
        {
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        public void writeFile(string path, List<string> lines) 
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string line in lines) 
                {
                    sw.WriteLine(line);
                }
            }
        }


    }
}
