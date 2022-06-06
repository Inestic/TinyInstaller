<#
	.SYNOPSIS
	Copy items from "Packages" to "Publish" folder

	.INPUTS
	None

	.OUTPUTS
	Files in "Publish" folder

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
$RepoRootDir = "{0}\TinyInstaller" -f (Split-Path -Path $PSScriptRoot -Parent)
$PackagesDir = "{0}\Packages" -f $RepoRootDir
$PublishDir = "{0}\bin\Release\net6.0-windows7.0\publish" -f $RepoRootDir

if (Test-Path -Path $PackagesDir)
{
	Write-Host "Directory ""$PackagesDir"" exist"
	
	if (Test-Path -Path $PublishDir)
	{
		Write-Host "Directory ""$PublishDir"" exist"
		try
		{
			Copy-Item -Path $PackagesDir -Destination $PublishDir -Recurse -Confirm:$false -Force -Verbose -ErrorAction Stop
			Write-Host "All files are copied to Packages directory"
		}
		catch
		{
			Write-Warning -Message $Error[0]
			Exit
		}
	}
	else
	{
		Write-Warning -Message "Directory ""$PublishDir"" NOT EXIST"
		Exit
	}
}
else
{
	Write-Warning -Message "Directory ""$PackagesDir"" NOT EXIST"
}



