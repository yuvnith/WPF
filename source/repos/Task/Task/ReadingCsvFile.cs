using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Task
{
    public class ReadingCsvFile
    {
        private string[] data = File.ReadAllLines("D:/Mat.csv");

        public void Search(string id)
        {
            for (int i = 1; i < data.Length; i++)
            {
                string[] temp = data[i].Split(',');

                if (temp[0].ToString() == id)
                    Console.WriteLine(temp[0] + " " + temp[1] + " " + temp[2] + " " + temp[3] + " " + temp[4] + " " +
                                      temp[5] + " " + temp[6] + " " + temp[7] + " ");
            }


        }

        public void write()
        {
            using (StreamWriter sr = new StreamWriter("D:/mat2.csv"))
            {
                foreach (var s in data)
                {
                    sr.WriteLine(s);
                }
            }

            

        }
    }
}