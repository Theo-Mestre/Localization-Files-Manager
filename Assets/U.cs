using System.Collections.Generic;

class Data
{
    public static void Init(string Language)
    {
        switch (Language)
        {

            case "En":
                data.Add("Id", "en");
                data.Add("Start", "Start");
                data.Add("Leaderboards", "Leaderboards");
                data.Add("Options", "Options");
                data.Add("Quit", "Quit");
                break;

            case "Fr":
                data.Add("Id", "fr");
                data.Add("Start", "Démarrer");
                data.Add("Leaderboards", "Classements");
                data.Add("Options", "Options");
                data.Add("Quit", "Quitter");
                break;

            case "Ja":
                data.Add("Id", "ja");
                data.Add("Start", "開始");
                data.Add("Leaderboards", "リーダーボード”");
                data.Add("Options", "オプション");
                data.Add("Quit", "よす");
                break;

            default:
                break;
        }
    }

    public static string GetText(string key)
    {
        if (data.ContainsKey(key))
        {
            return data[key];
        }
        return key;
    }

    private static Dictionary<string, string> data = new Dictionary<string, string>();
}
