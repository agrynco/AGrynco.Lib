@ECHO OFF

SET netVersion=net45
SET workFolder=C:\Temp\AGrynco.Lib\
SET targetBinraiesFolder=%workFolder%lib\%netVersion%\
SET specFileName="AGrynco.Lib.dll.nuspec"
SET fullSpecFileName=%workFolder%%specFileName%
SET build=%1
SET apiKey=%2

ECHO specFileName - %specFileName%

CALL prepare_folder.bat %workFolder%
MD %targetBinraiesFolder%

TYPE AGrynco.Lib.dll.nuspec.1> %fullSpecFileName%
ECHO %build%>> %fullSpecFileName%
TYPE AGrynco.Lib.dll.nuspec.2>> %fullSpecFileName%

SET pathToBinaries=..\AGrynco.Lib\bin\Debug\

COPY %pathToBinaries%*.* %targetBinraiesFolder%

CD %workFolder%

nuget pack %specFileName%

nuget setApiKey %apiKey%

nuget push AGrynco.Lib.dll.%build%.nupkg