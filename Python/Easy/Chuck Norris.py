import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

message = input()

# Write an action using print
# To debug: print("Debug messages...", file=sys.stderr)

bin_string = ""
for i in range(0, len(message)):
    c = ord(message[i])
    bin_letter = str(bin(c)[2:])
    print("Letter " + chr(c) + ": " + bin_letter, file=sys.stderr)
    print("Pure bin: " + str(bin(c)), file=sys.stderr)
    # add leading zeros to make a 7-bit character
    while len(bin_letter) < 7:
        bin_letter = "0" + bin_letter
    
    bin_string += bin_letter



code_string = ""
last_value = ""
for i in range(0, len(bin_string)):
    c = (bin_string[i])
    if c == last_value:
        code_string += "0"
    else:
        if last_value != "":
            code_string += " "
        
        last_value = c
        if c == "0" :
            code_string += "00 0"
        else:
            code_string += "0 0"

print(code_string)