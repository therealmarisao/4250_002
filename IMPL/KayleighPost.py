combined = int(0)
validInput = False
twoInputs = False

#need to make sure that they give you something
#need to make sure that they give you ONLY two numbers
#need to make sure that they give you valid numbers
while not twoInputs or not validInput:
    try:
        num1, num2 = input('Please enter two numbers: ').split()
        twoInputs = True
        combined = int(num1) + int(num2)
        validInput = True
    except:
        print('Didn\'t receive two numberic values, try again.')

#if they pass all the checks:
#catch all the easy cases of single digit right off the bat
#this also takes care of the base case
def add_least_significant():
    if combined > -10 and combined < 10 :
        return combined     

#not base case, separate the last digit and add it to the remaining
#parse the string version of combined, chop off LSD

#oh god, i have to deal with negatives!!!

print(add_least_significant())
