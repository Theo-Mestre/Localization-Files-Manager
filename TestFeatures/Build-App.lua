project "LocalizationFilesManager"
    kind "ConsoleApp"
    language "C#"
    csversion "latest"
    debugdir "../Assets"
    targetdir "../Binaries"
    objdir "../Binaries/intermediate"
    framework "4.8"

    files { "**.cs" }
    
    links 
    {
        "Microsoft.Csharp",
		"System.Xml",
    }
    
    filter "configurations:Debug"
        symbols "On"

    filter "configurations:Release"
        optimize "On"