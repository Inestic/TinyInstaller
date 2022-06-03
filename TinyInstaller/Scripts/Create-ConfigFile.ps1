<#
	.SYNOPSIS
	Create config file in "Publish" folder

	.INPUTS
	None

	.OUTPUTS
	"PackagesConfig.json" in "Publish" folder

	.NOTES
	Designed for GitHub Actions
	
	.LINK
	https://github.com/Inestic

	.VERSION
	v1.0.0

	.DATE
	03.06.2022

	Copyright (c) 2021 Inestic
#>
$ConfigTemplate = @"
{
          "Packages": [
          {
              "AutoInstall": false,
              "Title": "7-Zip",
              "Description": "7-Zip is a free and open-source file archiver",
              "ExecutableFile": "7 Zip\\7z2107-x64.msi",
              "ExecutableArgs": "/qb",
              "ExitCode": 0,
              "Version": "21.07"
          },
          {
              "AutoInstall": false,
              "Title": "Brave Browser Dev",
              "Description": "Secure, fast, private web browser with Adblocker",
              "ExecutableFile": "Brave Browser\\BraveBrowserStandaloneSilentDevSetup.exe",
              "ExecutableArgs": "",
              "ExitCode": 0,
              "Version": "1.40.81"
          },
          {
              "AutoInstall": false,
              "Title": "VLC Media Player",
              "Description": "VLC is a free and open source cross-platform multimedia player",
              "ExecutableFile": "VLC\\vlc-3.0.17.4-win64.exe",
              "ExecutableArgs": "/S",
              "ExitCode": 0,
              "Version": "3.0"
          }
        ]
}
"@
$RepoRootDir = "{0}\TinyInstaller" -f (Split-Path -Path $PSScriptRoot -Parent)
$PublishDir = "{0}\bin\Release\net6.0-windows7.0\publish" -f $RepoRootDir
$PackagesConfig = "{0}\{1}" -f $PublishDir, "PackagesConfig.json"

if (Test-Path -Path $PackagesConfig)
{
	Write-Host "File PackagesConfig.json exist"
}
else
{
	Write-Host "File PackagesConfig.json not exist"
}

try
{
	$ConfigTemplate | Out-File -FilePath $PackagesConfig -Encoding UTF8 -Force -Confirm:$false -ErrorAction Stop
	Write-Host "PackagesConfig.json created in Packages directory"
}
catch
{
	Write-Warning -Message $Error[0]
}