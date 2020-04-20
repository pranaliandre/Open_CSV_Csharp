using System;
using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;
using System.IO;
namespace open_CSV_File
{
    public class OpenCSVReader
    {
        static void Main(string[] args)
        {
            // call ReadCsvData Method to read 
            ReadDataFromCsv();
            // call  Write DataIntoInFile method to write
            CsvToDataFile.WriteToDataInFile();
            CsvPojoToBean.CsvPojoMethod();
        }

        /// <summary>
        /// Read the data from csv file
        /// </summary>
        public static void ReadDataFromCsv()
        {
            try
            {
                //read csv file
                using (CsvReader csv = new CsvReader(new StreamReader("C:/Users/intel/source/repos/open_CSV_File/open_CSV_File/users.csv"), true))
                {

                    //The number of fields 
                    int field_Count = csv.FieldCount;
                    //reading the header into the string array
                    string[] headers = csv.GetFieldHeaders();
                    List<string[]> records = new List<string[]>();
                    //all record into the list
                    while (csv.ReadNextRecord())
                    {
                        //create new object to store the data
                        string[] temp_record = new string[field_Count];
                        // copy data into string
                        csv.CopyCurrentRecordTo(temp_record);
                        // add the data string into List: records
                        records.Add(temp_record);
                    }
                    //print the record
                    foreach (string[] print_record in records)
                    {
                        for (int j = 0; j < field_Count; j++)
                            Console.Write($"  {headers[j]} = {print_record[j]}  ");
                    }
                }
            }
            catch (FileNotFoundException file_not_found)
            {
                throw new Exception(file_not_found.FileName);
            }
        }
    }
}