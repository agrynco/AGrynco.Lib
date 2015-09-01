@ECHO OFF

SET netVersion=net45
SET workFolder=%1
SET targetBinraiesFolder=%workFolder%lib\%netVersion%\
SET specFileName="AGrynco.Lib.dll.nuspec"
SET fullSpecFileName=%workFolder%%specFileName%

SET build=%2
SET apiKey=%3

ECHO specFileName - %specFileName%

CALL prepare_folder.bat %workFolder%
MD %targetBinraiesFolder%

TYPE AGrynco.Lib.dll.nuspec.1> %fullSpecFileName%
ECHO %build%>> %fullSpecFileName%
TYPE AGrynco.Lib.dll.nuspec.2>> %fullSpecFileName%

SET pathToBinaries=..Sources\\AGrynco.Lib\bin\Debug\

COPY %pathToBinaries%*.* %targetBinraiesFolder%

SET toolsDir=%CD%

CD %workFolder%

%toolsDir%\nuget pack %specFileName%

%toolsDir%\nuget setApiKey %apiKey%

%toolsDir%\nuget push AGrynco.Lib.dll.%build%.nupkg