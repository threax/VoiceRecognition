# This script will publish the project. 
# You can optionally supply an artifactName to zip the project to a different final location.
# The output file will be overwritten.
# Usage: Publish.ps1 -artifactName artifactOutputFile.zip

param (
    [string]$artifactName = "Publish.zip"
)
$currentDir = "$pwd"

$installPath = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community"
Import-Module (Join-Path $installPath "Common7\Tools\vsdevshell\Microsoft.VisualStudio.DevShell.dll")
Enter-VsDevShell -VsInstallPath $installPath

Set-Location $currentDir

$appFolder = "VoiceRecognition"
$csproj = "VoiceRecognition.csproj"

function Test-Error([string] $msg, [int] $code = 0){
    if($LastExitCode -ne $code){
        throw $msg;
    }
}

$scriptPath = Split-Path $script:MyInvocation.MyCommand.Path
$publishDir = "$scriptPath\VoiceRecognition\bin\Release"
try{
    Push-Location $scriptPath

    if(Test-Path $publishDir){
        Remove-Item $publishDir -Recurse -ErrorAction Stop
    }

    try{
        nuget restore "Threax.VoiceRecognition.sln"
        MSBuild.exe /p:Configuration=Release "Threax.VoiceRecognition.sln"
    }
    finally{
    }
    
    if(Test-Path $artifactName){
        Remove-Item $artifactName -Recurse -ErrorAction Stop
    }

    Compress-Archive -Path $publishDir\* -DestinationPath $artifactName -ErrorAction Stop
}
finally{
    if(Test-Path $publishDir){
        Remove-Item $publishDir -Recurse -ErrorAction Stop
    }

    Pop-Location
}