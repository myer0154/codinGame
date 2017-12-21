import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

l = int(input())
h = int(input())
t = input().upper()

ascii_letter_rows = []
for i in range(h):
    ascii_letter_rows.append(input())

for i in range(h):
    output = ""
    for c in t:
        value = ord(c) - ord('A')
        # assign value of 0-26 (A-Z, ?) to each letter
        if value < 0 or value > 25:
            value = 26
        # print the portion of the alphabet row that corresponds to each character
        output += ascii_letter_rows[i][value * l:(value + 1) * l]
    print(output)