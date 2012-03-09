#$folder = "D:\Projects\Coolite\svn.ext.net\trunk\Ext.Net\Build\Ext.Net\extjs\locale\"
#$dest = "D:\Projects\Coolite\svn.ext.net\trunk\Ext.Net\Build\Ext.Net\extjs\locale\"
#$patchFolder = "D:\Projects\Coolite\svn.ext.net\trunk\Ext.Net\Build\BuildScripts\Locales\"

$folder = "..\Ext.Net\extjs\locale"
$dest = "..\Ext.Net\extnet\locale\"
$patchFolder = ".\Locales\"
[System.Io.Directory]::CreateDirectory($dest)
Remove-Item $dest"*.js"
$files = [System.Io.Directory]::GetFiles($folder)
$patches = [System.Io.Directory]::GetFiles($patchFolder)
$OutputEncoding = [Console]::OutputEncoding
foreach($f in $files)
{
	$file = get-childitem $f
	$newname = $file.Name.Replace('_','-').Replace("-vn.js", "-vi.js").Replace("-ukr.js", "-uk.js").Replace("-sr-RS.js", "-sr-Cyrl-CS.js").Replace("-no-NN.js", "-nn-NO.js").Replace("-no-NB.js", "-no.js")
	Copy-Item $f $dest$newname
	
	foreach($p in $patches)
	{
		$patch = get-childitem $p
		if($patch.Name -eq $newname)
		{			
			Add-Content -path $dest$newname -Encoding UTF8 -value (Get-Content $p -Encoding UTF8)
			break			
		}
	}
}