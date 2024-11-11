workspace "LocalizationFilesManager"
    architecture "x64"
    configurations { "Debug", "Release" }

    flags
    {
        "MultiProcessorCompile"
    }

    include "LocalizationFilesManager/Build-App.lua"