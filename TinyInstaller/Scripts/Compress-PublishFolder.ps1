<#
	.SYNOPSIS
	Rename "Publish" folder and compress to zip

	.INPUTS
	None

	.OUTPUTS
	"TinyInstaller.zip" "Publish" folder

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
$AppName = "TinyInstaller"
$RepoRootDir = "{0}\{1}" -f (Split-Path -Path $PSScriptRoot -Parent), $AppName
$ReleaseDir = "{0}\bin\Release\net6.0-windows7.0\" -f $RepoRootDir
$PublishDir = "{0}{1}" -f $ReleaseDir, "publish"
$AppReleaseDir = "{0}\{1}" -f $ReleaseDir, $AppName
$Zip = "{0}{1}" -f $ReleaseDir, $AppName

try
{
	Rename-Item -Path $PublishDir -NewName $AppName -Force -Confirm:$false -ErrorAction Stop
	Write-Host "Folder """$PublishDir""" is renamed"
	Compress-Archive -Path $AppReleaseDir -DestinationPath $Zip -CompressionLevel Optimal -Confirm:$false -Force -ErrorAction Stop
	Write-Host "Archive created"
}
catch
{
	Write-Warning -Message $Error[0]
}