param($installPath, $toolsPath, $package, $project)

Write-Host "Overwriting Foundation Log4Net configs with WebApi Log4Net configs"

$configs = $project.ProjectItems | Where-Object { $_.Name -eq "config" }

if ($configs) {

    #$configs.ProjectItems | ForEach-Object { $_.Delete() }
	
	$projectFullName = $project.FullName 
	$fileInfo = new-object -typename System.IO.FileInfo -ArgumentList $projectFullName
	$projectDirectory = $fileInfo.DirectoryName

	$tempDirectory = "configTemp"
	$configDirectory = "config"
	$sourceDirectory = "$projectDirectory\$tempDirectory"
	Write-Host $sourceDirectory
	$destinationDirectory = (get-item $sourceDirectory).parent.FullName
	$destinationDirectory = "$destinationDirectory\$configDirectory"
	
	Write-Host $destinationDirectory

	if(test-path $sourceDirectory -pathtype container)
	{
	 robocopy $sourceDirectory $destinationDirectory
		
	 $tempDirectoryProjectItem = $project.ProjectItems.Item($tempDirectory)
	 $tempDirectoryProjectItem.Remove()

	 remove-item $sourceDirectory -recurse
	 
	 #set to Copy Always
		$project.ProjectItems.Item("config").ProjectItems.Item("log4net.config").Properties.Item("CopyToOutputDirectory").Value = 1
		$project.ProjectItems.Item("config").ProjectItems.Item("Logging.config").Properties.Item("CopyToOutputDirectory").Value = 1
	}
}
