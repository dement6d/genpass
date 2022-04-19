@echo off
cd src

echo Compiling...
@echo.
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true --self-contained true
@echo.
echo Making folder "%AppData%\.genpass\"
mkdir %AppData%\.genpass\
@echo.
echo Moving genpass.exe to "%AppData%\.genpass\"
move /Y bin\Release\net6.0\win-x64\publish\genpass.exe %AppData%\.genpass\
@echo.
echo Creating desktop shortcut for genpass.exe
set SCRIPT="%TEMP%\%RANDOM%-%RANDOM%-%RANDOM%-%RANDOM%.vbs"

echo Set oWS = WScript.CreateObject("WScript.Shell") >> %SCRIPT%
echo sLinkFile = "%USERPROFILE%\Desktop\genpass.lnk" >> %SCRIPT%
echo Set oLink = oWS.CreateShortcut(sLinkFile) >> %SCRIPT%
echo oLink.TargetPath = "%AppData%\.genpass\genpass.exe" >> %SCRIPT%
echo oLink.WorkingDirectory = "%AppData%\.genpass\" >> %SCRIPT%
echo oLink.Save >> %SCRIPT%

cscript /nologo %SCRIPT%
del %SCRIPT%
@echo.
pause