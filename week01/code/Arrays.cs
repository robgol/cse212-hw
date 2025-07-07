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
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Create a new double array of the specified 'length'.
        // 2. Loop from index 0 up to 'length - 1'.
        // 3. In each iteration, calculate the current multiple: number * (index + 1).
        // 4. Assign this calculated multiple to the current index in the array.
        // 5. Return the populated array.

        double[] result = new double[length]; // Step 1

        for (int i = 0; i < length; i++) // Step 2
        {
            result[i] = number * (i + 1); // Step 3 & 4
        }

        return result; // Step 5
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

        // Plan:
        // 1. Handle edge cases: If the list is null, empty, or has only one element, no rotation is needed.
        // 2. Calculate the effective amount of rotation using the modulo operator (%).
        //    This reduces 'amount' to its equivalent rotation within the list's length.
        // 3. If the effective amount of rotation is 0, it means the list would end up in its original state,
        //    so we can return early without performing any shifts.
        // 4. Loop 'effectiveAmount' number of times.
        // 5. In each iteration:
        //    a. Get the value of the last element of the list.
        //    b. Remove this last element from its current position.
        //    c. Insert this element at the beginning (index 0) of the list.


        // Quick check: If the list is empty or just has one item, there's nothing to rotate!
        // We'll also implicitly handle cases where the 'amount' of rotation results in no actual shift
        // (like rotating by 0, or a full circle) further down with the modulo calculation.
        if (data == null || data.Count <= 1)
        {
            return;
        }

        // We need to figure out how many actual rotations are necessary.
        // Think of it this way: if you rotate a list of 5 items by 5 positions,
        // it's back where it started, so that's effectively 0 rotations.
        // The modulo operator helps us with this!
        // For example, if we have 5 items and want to rotate by 7,
        // 7 % 5 gives us 2, meaning it's the same as rotating by just 2 positions.
        int effectiveAmount = amount % data.Count;

        // If our calculated 'effectiveAmount' is zero, it means we've rotated the list
        // a full circle (or multiple full circles!), landing right back where we started.
        // So, no actual changes are needed!
        if (effectiveAmount == 0)
        {
            return;
        }

        // The loop uses the 'effectiveAmount' for rotations
        for (int i = 0; i < effectiveAmount; i++) // This loop is controlled by the modulo result
        {
            int lastElement = data[data.Count - 1]; // Step 5a: Get the last element
            data.RemoveAt(data.Count - 1);         // Step 5b: Remove the last element
            data.Insert(0, lastElement);           // Step 5c: Insert it at the beginning
        }
    }
}
