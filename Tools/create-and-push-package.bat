REM ECHO OFF

SET netVersion=net45
SET workFolder=%1
SET targetBinariesFolder=%workFolder%lib\%netVersion%\
SET specFileName="AGrynco.Lib.dll.nuspec"
SET fullSpecFileName=%workFolder%%specFileName%

SET build=%2
SET apiKey=%3

ECHO specFileName - %specFileName%

CALL prepare_folder.bat %workFolder%
MD %targetBinariesFolder%

TYPE AGrynco.Lib.dll.nuspec.1> %fullSpecFileName%
ECHO %build%>> %fullSpecFileName%
TYPE AGrynco.Lib.dll.nuspec.2>> %fullSpecFileName%

SET pathToBinaries=..\Sources\AGrynco.Lib\bin\Debug\

ECHO COPY %pathToBinaries%*.* %targetBinariesFolder%
COPY %pathToBinaries%*.* %targetBinariesFolder%

SET toolsDir=%CD%

CD %workFolder%

%toolsDir%\nuget pack %specFileName%

%toolsDir%\nuget setApiKey %apiKey%

REM %toolsDir%\nuget push AGrynco.Lib.dll.%build%.nupkg