properties {
	$base_dir  = resolve-path .
	$sln_file = "$base_dir\src\RouteMapDecorators.sln"
	$build_dir = "$base_dir\build"
	$release_dir = "$build_dir"
	$release_temp_dir = "$release_dir\temp"
	
	$dlls = @( "RouteMapDecorators.???" );
}

task default -depends Release

task Clean {
	write-host "Cleaning up..."
	
	remove-item -force -recurse $build_dir -ErrorAction SilentlyContinue
}

task Init -depends Clean {
	write-host "Initializing..."
	
	new-item $build_dir -itemType directory -ErrorAction SilentlyContinue
}

task Release -depends Init {
	write-host "Building release version..."
	
	$net_version = (ls "$env:windir\Microsoft.NET\Framework\v3.5*").Name
	new-item $release_dir -itemType directory -ErrorAction SilentlyContinue
	new-item $release_temp_dir -itemType directory -ErrorAction SilentlyContinue
	exec { &"C:\Windows\Microsoft.NET\Framework\$net_version\MSBuild.exe" "$sln_file" /p:OutDir="$release_temp_dir\" /p:Configuration="Release" }
	
	foreach($dll in $dlls) {
		copy-item "$release_temp_dir\$dll" $release_dir
	}
	
	remove-item -force -recurse $release_temp_dir -ErrorAction SilentlyContinue
}
