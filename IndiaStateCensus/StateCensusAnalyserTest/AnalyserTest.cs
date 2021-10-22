using IndiaStateCensus;
using NUnit.Framework;
namespace StateCensusAnalyserTest
{
    public class AnalyserTest
    {

        string stateCensusCodeFilePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\StateCensusData.csv";
        string fileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string wrongFilePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\InvalidStateCensus.csv";
        string wrongCodeType = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\InvalidStateCode.csv";
        string invalidDelimiterFilePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\InvalidStateCensus.csv";
        string invalidFileHeaders = "State,Population,AreaInSqK,DensityPerSqKm,";
        string statesCodePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\StateCode.csv";
        string statesCodeFileHeader = "SrNo,State,Name,TIN,StateCode,";
        string wrongStatesCodePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\InvalidStateCode.csv";
        string WrongStatesCodeFileType = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\StateCode.txt";
        string invalidDelimiterWrongStatesCodePath = @"D:\IndiaStateCensusAnalyser\IndiaStateCensus\IndiaStateCensus\DataCenusFiles\InvalidStateCode.csv";
        string invalidStatesCodeFIleHeaders = "SrNo,State,Name,PIN,StateCode";


       

        //Test-1.1 ->Given the States Census CSV file, Check to ensure the Number of Record matches
        [Test]
        public void Given_NumberOfRecords_Match_StateCensusAnalyser()
        {
            StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
            var actual = cSVStateCenusData.LoadData(stateCensusCodeFilePath, fileHeaders);
            Assert.AreEqual(30, actual);
        }
        //Test-1.2 ->Given the State Census CSV File if incorrect Returns a custom Exception
        [Test]
        public void Given_IncorrectStateCensusCSVFile_Throw_Exception()
        {
            try
            {
                StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
                var actual = cSVStateCenusData.LoadData(wrongFilePath, fileHeaders);
                Assert.AreEqual(0, actual);
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        //Test-1.3 ->Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        [Test]
        public void Given_IncorrectStateCensusCSVFileType_Throw_Exception()
        {
            try
            {
                StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
                var actual = cSVStateCenusData.LoadData(wrongCodeType, fileHeaders);
                Assert.AreEqual(0, actual);
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Incorrect File Type", e.Message);
            }
        }
        //Test-1.4 ->Given the State Census CSV File when correct but delimiter incorrect Returns a customException
        [Test]
        public void Given_StateCensusCSVFile_WhenCorrectButDelimiterIsIncorrect_Throw_Exception()
        {
            try
            {
                StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
                var actual = cSVStateCenusData.LoadData(invalidDelimiterFilePath, fileHeaders);
                Assert.AreEqual(0, actual);
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Invalid Delimiters In File", e.Message);
            }
        }





        //Test-1.5 ->Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        [Test]
        public void Given_StateCensusCSVFile_WhenCorrectButHeaderIsIncorrect_Throw_Exception()
        {
            try
            {
                StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
                var actual = cSVStateCenusData.LoadData(stateCensusCodeFilePath, invalidFileHeaders);
                Assert.AreEqual(0, actual);
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Invalid Headers", e.Message);
            }
        }

        //Test-2.1 ->Given the States Code CSV file, Check to ensure the Number of Record matches
        [Test]
        public void Given_NumberOfRecords_Match_CSVStatesCodeData()
        {
            StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
            var actual = cSVStateCenusData.LoadStatesCodeData(statesCodePath, statesCodeFileHeader);
            Assert.AreEqual(38, actual);
        }
        //Test-2.2 ->Given the State Code CSV File if incorrect Returns a custom Exception
        [Test]
        public void Given_IncorrectStatesCodeCSVFile_Throw_Exception()
        {
            try
            {
                StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
                var actual = cSVStateCenusData.LoadStatesCodeData(wrongStatesCodePath, statesCodeFileHeader);
                Assert.AreEqual(0, actual);
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        //Test-2.3 ->Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        [Test]
        public void Given_IncorrectStatesCodeCSVFileType_Throw_Exception()
        {
            try
            {
                StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
                var actual = cSVStateCenusData.LoadStatesCodeData(WrongStatesCodeFileType, statesCodeFileHeader);
                Assert.AreEqual(0, actual);
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Incorrect File Type", e.Message);
            }
        }
        //Test-2.4 ->Given the State Code CSV File when correct but delimiter incorrect Returns a customException
        [Test]
        public void Given_StatesCodeCSVFile_WhenCorrectButDelimiterIsIncorrect_Throw_Exception()
        {
            try
            {
                StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
                var actual = cSVStateCenusData.LoadStatesCodeData(invalidDelimiterWrongStatesCodePath, statesCodeFileHeader);
                Assert.AreEqual(0, actual);
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Invalid Delimiters In File", e.Message);
            }
        }
        //Test-2.5 ->Given the State Code CSV File when correct but csv header incorrect Returns a custom Exception
        [Test]
        public void Given_StatesCodeCSVFile_WhenCorrectButHeaderIsIncorrect_Throw_Exception()
        {
            try
            {
                StateCensusAnalyser cSVStateCenusData = new StateCensusAnalyser();
                var actual = cSVStateCenusData.LoadStatesCodeData(statesCodePath, invalidStatesCodeFIleHeaders);
                Assert.AreEqual(0, actual);
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual("Invalid Headers", e.Message);
            }
        }
    }
} 