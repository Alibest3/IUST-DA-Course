def segregate_even_odd(arr):
    n = len(arr)
    swaps = 0
    for i in range(n):
        if arr[i] % 2 == 0:
            for j in range(i+1, n):
                if arr[j] % 2 == 1:
                    arr[i], arr[j] = arr[j], arr[i]
                    swaps += 1
                    break
             
    return swaps

def separate_even_odd(arr):
    n = len(arr)
    swaps = 0
    
    for i in range(n-1,-1,-1):
        if arr[i] % 2 == 0:
            for j in range(i-1, -1,-1):
                if arr[j] % 2 == 1:
                    arr[i], arr[j] = arr[j], arr[i]
                    swaps += 1
                    break
    
    return swaps        

#array = [3 , 5, 2, 7, 9, 11, 12]
#arr = array
#n = len(arr)    
print(min(segregate_even_odd([3 , 5, 2, 7, 9, 11, 12]),separate_even_odd([3 , 5, 2, 7, 9, 11, 12])))