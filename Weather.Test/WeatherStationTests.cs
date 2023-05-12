namespace Weather.Test;

[TestFixture]
public class WeatherStationTests
{
    private WeatherStation _weatherStation;

    [SetUp]
    public void SetUp()
    {
        _weatherStation = new WeatherStation();
    }

    [Test]
    public void TestHeatwave()
    {
        _weatherStation.RecordData(75, 50);
        _weatherStation.RecordData(80, 55);
        _weatherStation.RecordData(85, 60);

        string analysis = _weatherStation.AnalyzeData();

        Assert.IsTrue(analysis.Contains("It's a heatwave!"));
    }

    [Test]
    public void TestImpossibleHumidity()
    {
        _weatherStation.RecordData(75, 105);
        _weatherStation.RecordData(80, 110);
        _weatherStation.RecordData(85, 115);

        string analysis = _weatherStation.AnalyzeData();

        Assert.IsTrue(analysis.Contains("Warning: Impossible humidity reading!"));
    }
    
    [Test]
    public void TestColdSnap()
    {
        _weatherStation.RecordData(25, 50);
        _weatherStation.RecordData(20, 55);
        _weatherStation.RecordData(15, 60);

        string analysis = _weatherStation.AnalyzeData();

        Assert.IsTrue(analysis.Contains("It's a cold snap!"));
    }

    [Test]
    public void TestVeryDry()
    {
        _weatherStation.RecordData(75, 25);
        _weatherStation.RecordData(80, 20);
        _weatherStation.RecordData(85, 15);

        string analysis = _weatherStation.AnalyzeData();

        Assert.IsTrue(analysis.Contains("It's very dry!"));
    }

    [Test]
    public void TestVeryHumid()
    {
        _weatherStation.RecordData(75, 75);
        _weatherStation.RecordData(80, 80);
        _weatherStation.RecordData(85, 85);

        string analysis = _weatherStation.AnalyzeData();

        Assert.IsTrue(analysis.Contains("It's very humid!"));
    }

    [Test]
    public void TestNotEnoughData()
    {
        _weatherStation.RecordData(75, 75);

        string analysis = _weatherStation.AnalyzeData();
        
        Assert.That(analysis, Is.EqualTo("Analysis: \n"));
    }

}
