import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

n = int(input())
pi = []
for i in range(n):
    pi.append(int(input()))

# Write an action using print
# To debug: print("Debug messages...", file=sys.stderr)
pi.sort()
min_difference = sys.maxsize
for i in range(1, len(pi)):
    diff = pi[i] - pi[i-1]
    if diff < min_difference:
        min_difference = diff
    #print("Strength" + str(i) + ": " + str(pi[i]), file=sys.stderr)
print(min_difference)