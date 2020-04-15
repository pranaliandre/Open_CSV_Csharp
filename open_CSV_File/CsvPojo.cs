using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using LumenWorks.Framework.IO.Csv;
using System.IO;
namespace open_CSV_File
{
    /// <summary>
    /// Pojo class
    /// </summary>
    public class CsvPojo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        /// <summary>
        /// default constructor
        /// </summary>
        public CsvPojo(){ }
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="PhoneNo"></param>
        /// <param name="Address"></param>
        /// <param name="Country"></param>
        public CsvPojo(int ID, string Name,string Email, long PhoneNo,string Address,string Country )
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.PhoneNo = PhoneNo;
            this.Address = Address;
            this.Country = Country;
        }
    }

    public class CsvPojoToBean
    {/// <summary>
    /// Method to pojo structure
    /// </summary>
        public static void CsvPojoMethod()
        {
            try
            {
                using (CsvReader csv = new CsvReader(new StreamReader("C:/Users/intel/source/repos/openCSV/openCSV/users.csv"), true))
                {
                    // the number of fields 
                    int fields_count = csv.FieldCount;
                    // reading the header into th string array
                    string[] headers = csv.GetFieldHeaders();

                    List<CsvPojo> records = new List<CsvPojo>();

                    // add all records into List
                    while (csv.ReadNextRecord())
                    {
                        CsvPojo obj_csvPojo = new CsvPojo(Int32.Parse(csv[0]), csv[1], csv[2], long.Parse(csv[3]), csv[4],csv[5]);
                        records.Add(obj_csvPojo);
                    }

                    //Print the record
                    foreach (CsvPojo print_record in records)
                    {
                        Console.WriteLine($"ID : {print_record.ID}");
                        Console.WriteLine($"Name : {print_record.Name}");
                        Console.WriteLine($"Email :{print_record.Email}");
                        Console.WriteLine($"PhoneNo : {print_record.PhoneNo}");
                        Console.WriteLine($"Address : {print_record.Address}");
                        Console.WriteLine($"Email:{print_record.Country}"); 
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
