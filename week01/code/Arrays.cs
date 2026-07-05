public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // PLAN:
        // 1. Create a new array of doubles called 'multiples' with a size equal to 'length'.
        // 2. Create a loop that starts at index 0 and counts up to 'length - 1'.
        // 3. Inside the loop, calculate the current multiple by multiplying 'number' by (index + 1).
        // 4. Save that calculated value into the 'multiples' array at the current index.
        // 5. After the loop finishes, return the completed 'multiples' array.

      
        // array of doubles to hold the multiples
            double[] multiples = new double[length];
            // loop through the length of the array
            for (int i = 0; i < length; i++)
            {
                // calculate the multiple and store it 
                // index + 1 is used because we want the first multiple to be number * 1, not number * 0
                multiples[i] = number * (i + 1);
            }
            // return the array of multiples
            return multiples;
        
       
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        // PLAN:
        // 1. Check if the list is empty or if the amount to rotate is 0 or equal to data.Count. If so, no rotation is needed, so return early.
        // 2. Calculate the index where the split needs to happen.The numbers moving to the front start at index: (data.Count - amount).
        // 3. Extract the back slice of the list using GetRange starting from the split index to the end.
        // 4. Extract the front slice of the list using GetRange starting from index 0 up to the split index.
        // 5. Clear the original 'data' list so we can rebuild it.
        // 6. Add the back slice to the 'data' list first (using AddRange).
        // 7. Add the front slice to the 'data' list second (using AddRange).


    // check if no need to rotate
        if (data.Count <= 1 || amount == 0 || amount == data.Count)
        {
            return;
        }

            // find split point
        int splitIndex = data.Count - amount;

        //slice the list into two parts
        List<int> backSlice = data.GetRange(splitIndex, amount);
        List<int> frontSlice = data.GetRange(0, splitIndex);

        data.Clear(); // clear the original list
        data.AddRange(backSlice); // add the back slice first
        data.AddRange(frontSlice); // add the front slice second
    }
}
