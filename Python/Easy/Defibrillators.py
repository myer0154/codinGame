import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

# find the distance between two positions, entered as latitude and longitude
# values, with commas as decimal seperator
def distance(lat_a, lon_a, lat_b, lon_b):
    lat_a = convert_angle(lat_a)
    lat_b = convert_angle(lat_b)
    lon_a = convert_angle(lon_a)
    lon_b = convert_angle(lon_b)
    
    x = (lon_b - lon_a) * math.cos((lat_a + lat_b)/2)
    y = lat_b - lat_a
    d = math.sqrt(x*x + y*y) * 6371
    return d

# convert an angle entered in degrees with a comma decimal seperator into radians    
def convert_angle(text_pos):
    return float(text_pos.replace(',', '.')) * math.pi / 180
    
    

lon = input()
lat = input()
n = int(input())
min_dist = float('inf')

closest_defib = None
for i in range(n):
    defib = input()
    defib_split = defib.split(';')
    defib_name = defib_split[1]
    defib_lon = defib_split[4]
    defib_lat = defib_split[5]
    
    new_dist = distance(lat, lon, defib_lat, defib_lon)
    if new_dist < min_dist:
        min_dist = new_dist
        closest_defib = defib_name
    
# Write an action using print
# To debug: print("Debug messages...", file=sys.stderr)

print(closest_defib)