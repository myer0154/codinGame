import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

n = int(input())  # Number of elements which make up the association table.
q = int(input())  # Number Q of file names to be analyzed.
mime_types = dict()
print("List of types:", file=sys.stderr)
for i in range(n):
    # ext: file extension
    # mt: MIME type.
    ext, mt = input().split()
    mime_types[ext.lower()] = mt
    
    print(ext + ": " + mt, file=sys.stderr)
print("\nList of files:", file=sys.stderr)
for i in range(q):
    fname = input()  # One file name per line.
    ext = fname.split('.')
    if len(ext) > 1:
        ext = ext[-1].lower()
    else:
        ext = ""
    print(fname + ": " + ext, file=sys.stderr)
    try:
        print(mime_types[ext])
    except:
        print("UNKNOWN")
    