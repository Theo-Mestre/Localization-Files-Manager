workspace "LocalizationFilesManager"
    architecture "x64"
    configurations { "Debug", "Release" }

    flags
    {
        "MultiProcessorCompile"
    }

    include "LocalizationFilesManager/Build-App.lua"

workspace "TestFeatures"
    architecture "x64"
    configurations { "Debug", "Release" }
    flags
    {
        "MultiProcessorCompile"
    }

    include "TestFeatures/Build-App.lua"