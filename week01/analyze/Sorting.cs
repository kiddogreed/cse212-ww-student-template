public static class Sorting {
    public static void Run() {
        var numbers = new[] { 3, 2, 1, 6, 4, 9, 8 };
        SortArray(numbers);
        Console.Out.WriteLine("int[]{{{0}}}", string.Join(", ", numbers)); //int[]{1, 2, 3, 4, 6, 8, 9}
    }


// PERFORMANCE: O(n²)
// y = x^2
// x (The Horizontal Line): This is the number of items in your array (the size of your data).
// y (The Vertical Line): This is the time or steps it takes the computer to finish sorting.

// If you double the amount of numbers, it takes 4 times longer to finish
    private static void SortArray(int[] data) {
        // OUTER LOOP: Runs 'n' times (once for every number in the array)
        for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--) {
            // INNER LOOP: Runs inside the outer loop checking numbers.
            // Because it is a loop INSIDE a loop, we multiply their work together: (n * n)
            for (var swapPos = 0; swapPos < sortPos; ++swapPos) {
                // This comparison step takes O(1) "instant" time.
                if (data[swapPos] > data[swapPos + 1]) {
                    // This swapping step also takes O(1) "instant" time.
                    // It just switch the positions of two  numbers.
                    (data[swapPos + 1], data[swapPos]) = (data[swapPos], data[swapPos + 1]);
                }
            }
        }
    }
}