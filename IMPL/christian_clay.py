#!/opt/homebrew/bin/python3
from math import floor

n = int(input('Number 1> '))
n += int(input('Number 2> '))
out = 0

def compute(n):
    if abs(n) <= 10:
        print(f'n={n}')
        return n
    to_add = abs(n) % 10
    print(f'to_add={to_add}')
    n = n // 10
    n += to_add
    compute(n)

print(compute(n))

"""
while n >= 10:
    to_add = n % 10
    n = n // 10
    print(f'n={n}\tto_add={to_add}')
    n = n + to_add
    print(f'out={out}')


print(n)
"""
