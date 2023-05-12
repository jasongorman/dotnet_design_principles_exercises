namespace Weather;

public class WeatherStation
{
    private List<int> _temperatures;
    private List<int> _humidities;

    public WeatherStation()
    {
        _temperatures = new List<int>();
        _humidities = new List<int>();
    }

    public void RecordData(int temperature, int humidity)
    {
        _temperatures.Add(temperature);
        _humidities.Add(humidity);
    }

    public string AnalyzeData()
    {
        string analysis = "Analysis: \n";

        // Duplication and magic numbers (3 repetitions, 70, 30, 100)
        if (_temperatures.Count >= 3)
        {
            if (_temperatures.All(t => t > 70))
            {
                analysis += "It's a heatwave! \n";
            }
            else if (_temperatures.All(t => t < 30))
            {
                analysis += "It's a cold snap! \n";
            }
        }

        if (_humidities.Count >= 3)
        {
            if (_humidities.Any(h => h > 100))
            {
                analysis += "Warning: Impossible humidity reading! \n";
            }
            else if (_humidities.All(h => h > 70))
            {
                analysis += "It's very humid! \n";
            }
            else if (_humidities.All(h => h < 30))
            {
                analysis += "It's very dry! \n";
            }
        }


        return analysis;
    }
}
