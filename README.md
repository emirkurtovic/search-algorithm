# Search Algorithm

Internship dev task.

## Explanation of solution

1. In .NET 6 option `<Nullable>enable</Nullable>` is enabled by default, so there is no need to check if `userInput` and `reviewsRepository` are equal to `null`.
2. - It is assumed that the input parameter `reviewsRepository` cannot be changed, so references to new strings (results of `toLower` method) are copied to the new list `temp`.
   - It is assumed that input parameter `userInput` cannot be changed, so `userInput.ToLower()` is assigned to a new variable `input`.
3. The `findAll` method certainly returns a new list (a reference to it). So it makes sense to introduce a new `temp` variable and assign it the result of the `findAll` method in each iteration, so that the search in the next iteration is potentially done over a smaller list.
4. - `temp.Sort()` should not throw `InvalidOperationException` exception because the default comparer is defined for strings.
   - `userInput.Substring(0, i+1)` should not throw an  `ArgumentOutOfRange` exception because `i < userInput.Length`.
   - Arguments of all methods are different from `null` so they can't throw an `ArgumentNullException` exception.

## Time complexity

1. Let `n1 = reviewsRepository.Count` and `n2 = userInput.Length`. We will assume that the string lengths in the `reviewsRepository` are `~ n2`.
2. Assuming the worst case, the number of words that match the first two characters to the first two characters of  `userInput` is equal to `n1` - so sorting is performed at time `O(n1 * log n1)`, so it is better to perform it once at the beginning instead of in each iteration over each result.
3. Let us now consider the following cases:
   - a) `n1 >> n2` -> `O(n1 * log n1)`
   - b) `n1 ~ n2 ~ n` -> `O(n ^ 3)`
   - c) `n2 >> n1` -> `O(n2 ^ 2)`

It is reasonable to assume that `n1` is much larger than `n2`, and in that case, the time complexity of the algorithm is `O(n1 * log n1)`.
## Space complexity

Under the same assumption that the string lengths in `reviewsRepository` are `~ n2`. If we count the referenced strings in the result then the space complexity of the algorithm is `O(n1 * n2 ^ 2)`, and if we don't then it is `O(n1 * n2)`. In both cases if `n1 >> n2` then it becomes `O(n1)`.


