@ECHO OFF

SET targetFolder=%1

ECHO Trying to delete folder %targetFolder%
RD %targetFolder% /S /Q
ECHO REMOVE_FOLDER_RESULT_CODE=%ERRORLEVEL%

ECHO Trying to create folder %targetFolder%
MD %targetFolder%
ECHO CREATE_FOLDER_RESULT_CODE=%ERRORLEVEL%