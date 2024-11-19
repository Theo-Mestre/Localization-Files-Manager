#pragma once
#include <unordered_map>
#include <string>
class Data
{
	public:
	static void Init(const std::string& _language)
	{
if (_language == "En")
{
				data["Id"] = "en";
				data["Start"] = "Start";
				data["Leaderboards"] = "Leaderboards";
				data["Options"] = "Options";
				data["Quit"] = "Quit";
}
if (_language == "Fr")
{
				data["Id"] = "fr";
				data["Start"] = "Démarrer";
				data["Leaderboards"] = "Classements";
				data["Options"] = "Options";
				data["Quit"] = "Quitter";
}
if (_language == "Ja")
{
				data["Id"] = "ja";
				data["Start"] = "開始";
				data["Leaderboards"] = "リーダーボード”";
				data["Options"] = "オプション";
				data["Quit"] = "よす";
}

	}

	static const std::string& GetText(const std::string& _key)
	{
        		if (data.find(_key) != data.end())
		{
			return data[_key];
		}
			return _key;
		}

	private:
	inline static std::unordered_map<std::string, std::string> data;
};
