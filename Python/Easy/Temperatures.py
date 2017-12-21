import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

n = int(input())  # the number of temperatures to analyse
temps = [int(temp) for temp in input().split()]  # the n temperatures expressed as integers ranging from -273 to 5526

# Write an action using print
# To debug: print("Debug messages...", file=sys.stderr)
lowest_abs = 5527

if len(temps) == 0:
    print("0")
else:
    for temp in temps:
    
        if abs(temp) < abs(lowest_abs):
            lowest_abs = temp
        elif temp == -lowest_abs:
            lowest_abs = abs(lowest_abs)
    print(lowest_abs)