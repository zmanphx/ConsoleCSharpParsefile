# Console C# File Parser
Console application in c# .net core . Processes a csv or tab delimited file. Produces two separate file outputs based on record validation . 

1. User will be asked the delimiter type tab or csv. 
2. The number of fields expected per record. 
3. The file location. 

Basic Logic for this example code

The first record which is the header is not parsed. 
The program counts the number of [tab] or [ ,] characters and compares it to the expected field count .
Records that meet the field count are placed in "correct.txt".
Records that don't meet the field count are placed in "Incorrect.txt"

File output is a subdirectory of the file location called  "processed"

No out put files are produced if there are no records. 