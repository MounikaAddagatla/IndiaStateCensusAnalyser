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
       
        string invalidFileHeaders = "State,Population,AreaInSqK,DensityPerSqKm,";
      
      
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
    }
}