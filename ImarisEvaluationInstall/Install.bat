@echo off
@set IMARIS_PATH=%APPDATA%\ImarisEvaluation
@set ADDIN_PATH=%APPDATA%\Microsoft\AddIns

@mkdir %IMARIS_PATH% > nul

@copy /y ImarisEvaluation.xlam %ADDIN_PATH% > nul
@copy /y ImarisEvaluation.exe %IMARIS_PATH% > nul
@copy /y Microsoft.CSharp.dll %IMARIS_PATH% > nul
@copy /y System.dll %IMARIS_PATH% > nul
@copy /y System.Xml.Linq.dll %IMARIS_PATH% > nul