@echo off

set directory="../Binaries"
if exist %directory% (
    rmdir /s /q %directory%
    echo Intermediate directory deleted successfully.
) 

set directory="../.vs"
if exist %directory% (
    rmdir /s /q %directory%
    echo .vs directory deleted successfully.
)

cd ../
del /S *.sln
del /S *.csproj
del /S *.csproj.filters
del /S *.csproj.user
echo Solution and project files deleted successfully.
pause