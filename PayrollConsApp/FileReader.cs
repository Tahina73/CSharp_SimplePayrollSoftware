using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PayrollConsApp
{
    public class FileReader
    {
        private string filePath;

        public FileReader()
        {
            filePath = "staff.txt";
        }

        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = null;
            string[] result = new string[2];
            string[] separator = { ", " };

            try
            {
                if (File.Exists(filePath))
                {
                    myStaff = new List<Staff>();
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string currentStaff = sr.ReadLine();
                            result = currentStaff.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                            if (result[1].Trim().ToLower() == "manager")
                            {
                                myStaff.Add(new Manager(result[0].Trim().ToUpper()));
                            }
                            else if (result[1].Trim().ToLower() == "admin")
                            {
                                myStaff.Add(new Admin(result[0].Trim().ToUpper()));
                            }
                        }
                        sr.Close();
                    }
                }
                else
                    Console.WriteLine($"The file {filePath} doesn't exist");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in FileReader.ReadFile : " + e.Message);
                throw;
            }
            return myStaff;
        }
    }
}
