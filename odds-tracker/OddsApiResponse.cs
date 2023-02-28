using Newtonsoft.Json;

namespace odds_tracker
{
    public class OddsApiResponse
    {
        public string Sport_Key { get; set; }
        public string Sport_Nice { get; set; }
        public List<Game> Data { get; set; }
    }

    public class Game
    {
        public string Home_Team { get; set; }
        public string Away_Team { get; set; }
        public string Commence_Time { get; set; }
        public List<Site> Sites { get; set; }
    }

    public class Site
    {
        public string Site_Key { get; set; }
        public string Site_Nice { get; set; }
        public Odds Odds { get; set; }
    }

    public class Odds
    {
        [JsonProperty("h2h")]
        public List<double> HeadToHead { get; set; }
    }

}
