## compile classes for 01-files
csc -t:exe -define:DEBUG -out:files.exe FileProgram.cs FileProcessor.cs

## run program
copy file(s) of data1.txt etc. in in directory before start

// mono files.exe --file in/data1.txt
// mono files.exe --dir in TEXT