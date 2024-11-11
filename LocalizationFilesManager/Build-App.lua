project "LocalizationFilesManager"
    kind "WindowedApp"
    language "C#"
    csversion "latest"
    targetdir "../Binaries"
    objdir "../Binaries/intermediate"
    framework "4.8"
    flags { "WPF" }

    files { "**.cs", "**.xaml", "**.config", "**.png", "**.otf" }
    
    links 
    {
        "Microsoft.Csharp",
		"PresentationCore",
		"PresentationFramework",
		"WindowsBase",
		"System",
		"System.Core",
		"System.Data",
		"System.Data.DataSetExtensions",
		"System.Xaml",
		"System.Xml",
		"System.Xml.Linq"
    }
    
    filter "configurations:Debug"
        symbols "On"

    filter "configurations:Release"
        optimize "On"