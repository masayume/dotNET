## compile classes for 01-files
csc -t:exe -define:DEBUG -out:files.exe FileProgram.cs FileProcessor.cs

## run program
copy file(s) of data1.txt etc. in in directory before start

// mono files.exe --file in/data1.txt
// mono files.exe --dir in TEXT

FileSystemWatcher class & events: file created, changed, renamed, deleted, error

InternalBufferSize property: (Int) 4Kb to 64Kb, defaults to 8K (multiple of 4Kb)

NotifyFilter property: (enum) for:
	Attributes: 	changes in file/directory attributes
	CreationTime: 	file/dir creation time
	DirectoryName: 	directory name
	FileName:	filename
	LastAccess: 	last access
	LastWrite: 	last write
	Security:
	Size:

Path property
Filter property (type of files)
EnableRaisingEvents (switch on)


