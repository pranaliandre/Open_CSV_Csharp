using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Reflection;
using CsvHelper;
namespace open_CSV_File
{
    class CsvToDataFile
    {
        /// <summary>
        /// Method to Write data in csv file
        /// </summary>
        public static void WriteToDataInFile()
        {
            var data = new[]
            { 
               new CsvPojo {ID=5,Name ="kimaya",Email="kimaya23@gmail.com", PhoneNo = +91-9845678937,Address="Pune",Country="india"},
               new CsvPojo {ID =6,Name = "Aryan",Email="aryan15@gmail.com",  PhoneNo = +91-9705263245,Address ="Rajgurunagare",Country="india"}
            };
            try
            {
                // create csv writer object 
                using (var csvWriter = new CsvWriter(new StreamWriter("C:/Users/intel/source/repos/open_CSV_File/open_CSV_File/users.csv", true), System.Globalization.CultureInfo.CurrentCulture))
                {
                    //delimeter seprating the input
                    csvWriter.Configuration.Delimiter = ",";
                    csvWriter.Configuration.HasHeaderRecord = true;
                    //automap tansforming the input one type to another
                    csvWriter.Configuration.AutoMap<CsvPojo>();

                    csvWriter.WriteHeader<CsvPojo>();
                    csvWriter.WriteRecords(" \n ");
                    csvWriter.WriteRecords(data);
                    csvWriter.Flush();

                }
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
