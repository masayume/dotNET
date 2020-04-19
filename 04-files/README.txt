# Introduction to streams

* [Microsoft Documentation](https://docs.microsoft.com/en-us/dotnet/standard/io)

## Benefits of streams
- incremental data processing
- abstraction of the backing store (tcp port, USB etc.)
- flexibility/control (i.e. random access)
- composability/pipelines (i.e. encryption, compression)

## .NET class hierarchy overview
- Stream class (abstract)
- FileStream (backing store: file)
- MemoryStream (backing store: memory)

System.Object -> BinaryReader/BinaryWriter
TextReader(abstract) -> StreamReader, StringReader
TextWriter(abstract) -> StreamWriter, StringWriter

## Using streams to read and write text

## selectively processing part of stream

## using streams to read and write binary data

## using binaryReader and binaryWriter

## Specifying text encodings

## Using streams to append data

## Rando FileStream access

## MemoryStream overview

