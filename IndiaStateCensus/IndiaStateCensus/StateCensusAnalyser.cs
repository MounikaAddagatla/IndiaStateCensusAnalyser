using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndiaStateCensus
{
  public  class StateCensusAnalyser
    {
        // read data from statecensusData.csv //
        public string stateCensusCodeFilePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\StateCensusData.csv";
        public string fileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public string statesCodePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\StateCode.csv";
        public string statesCodeFileHeader = "SrNo,State,Name,TIN,StateCode,";
        public object LoadData(string stateCensusCodeFilePath, string fileHeaders)
        {
            int count = 0;
            try
            {
                if (Path.GetExtension(statesCodePath) != ".csv")
                {
                    throw new StateCensusException(StateCensusException.InvalidCenusdetails.INCORRECT_FILE_TYPE, "Incorrect File Type");
                }
                if (!File.Exists(stateCensusCodeFilePath))
                {
                    throw new StateCensusException(StateCensusException.InvalidCenusdetails.FILE_NOT_FOUND, "File Not Found");
                }
                StreamReader sr = new StreamReader(stateCensusCodeFilePath);
                string line;
                string[] rowData = new string[100];
                rowData = File.ReadAllLines(stateCensusCodeFilePath);
                if (rowData[0] != fileHeaders)
                {
                    throw new StateCensusException(StateCensusException.InvalidCenusdetails.INVALID_HEADERS, "Invalid Headers");
                }
                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                    //iterate the csv data
                    foreach (string csvData in rowData)
                    {
                        if (!csvData.Contains(","))
                        {
                            throw new StateCensusException(StateCensusException.InvalidCenusdetails.INVALID_DELIMITER, "Invalid Delimiters In File");
                        }
                        else
                        {
                            Console.WriteLine("{0}" + "\t", csvData.Replace(",", " "));
                            Console.WriteLine("\t");
                        }
                    }
                }
                Console.WriteLine("total number of records:" + count);
            }
           
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return count;
        }
        public object LoadStatesCodeData(string statesCodePath, string statesCodeFileHeader)
        {
            int countRecords = 0;
            try
            {
                if (Path.GetExtension(statesCodePath) != ".csv")
                {
                    throw new StateCensusException(StateCensusException.InvalidCenusdetails.INCORRECT_FILE_TYPE, "Incorrect File Type");
                }

                if (!File.Exists(statesCodePath))
                {
                    throw new StateCensusException(StateCensusException.InvalidCenusdetails.FILE_NOT_FOUND, "File Not Found");
                }
                StreamReader sr = new StreamReader(statesCodePath);
                string line;
                string[] rowData = new string[100];
                rowData = File.ReadAllLines(statesCodePath);
                if (rowData[0] != statesCodeFileHeader)
                {
                    throw new StateCensusException(StateCensusException.InvalidCenusdetails.INVALID_HEADERS, "Invalid Headers");
                }
                while ((line = sr.ReadLine()) != null)
                {
                    countRecords++;
                    //iterate the states code csv data
                    foreach (string csvStatesCodeData in rowData)
                    {
                        if (!csvStatesCodeData.Contains(","))
                        {
                            throw new StateCensusException(StateCensusException.InvalidCenusdetails.INVALID_DELIMITER, "Invalid Delimiters In File");
                        }
                        else
                        {
                            Console.WriteLine("{0}" + "\t", csvStatesCodeData.Replace(",", " "));
                            Console.WriteLine("\t");
                        }
                    }
                }
                Console.WriteLine("total number of records:" + countRecords);
            }
            catch (StateCensusException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return countRecords;
        }
    }
}
