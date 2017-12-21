import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.


# game loop
while True:
    mountain_h = []
    for i in range(8):
        mountain_h.append(int(input()))  # represents the height of one mountain, from 9 to 0.

    highest_mountain = -1
    highest_height = 0
    
    for i in range(8):
        if mountain_h[i] > highest_height:
            highest_mountain = i
            highest_height = mountain_h[i]

    print(highest_mountain)