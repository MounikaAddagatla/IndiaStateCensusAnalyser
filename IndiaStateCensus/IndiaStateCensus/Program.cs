using System;

namespace IndiaStateCensus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is India State Census Analysis");
            string stateCensusCodeFilePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\StateCensusData.csv";
            string fileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
            string statesCodePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\StateCode.csv";
            string statesCodeFileHeader = "SrNo,State,Name,TIN,StateCode,";
            int options;
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("Enter Options \n1.  AnalyseIndianStateCSVData  \n2.  AnalyseIndianStatesCodeCSVData");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        StateCensusAnalyser csvCensusData = new StateCensusAnalyser();
                        csvCensusData.LoadData(stateCensusCodeFilePath, fileHeaders);
                        break;
                    case 2:
                        StateCensusAnalyser cSVStatesCodeCenusData = new StateCensusAnalyser();
                        cSVStatesCodeCenusData.LoadStatesCodeData(statesCodePath, statesCodeFileHeader);
                        break;
                    default:
                        Console.WriteLine("Choose valid options");
                        break;
                }
            }
        }
    }
}
