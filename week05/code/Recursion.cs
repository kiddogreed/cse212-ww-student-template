using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {   
        // TODO Start Problem 1

        // Base Case: Stop if n drops to 0 or below (prevents infinite loop)
        if (n <= 0)
        {
            return 0;
        }

        // Add the current number squared to the sum of all smaller numbers
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2

        // Base Case: Save our finished word once it reaches the target length
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try picking each available letter as the next character in our word
        for (int i = 0; i < letters.Length; i++)
        {
            char chosenChar = letters[i];
            
            // Remove the picked letter so we don't reuse it in the same word
            string remainingLetters = letters.Remove(i, 1);

            // Pass the growing word and remaining letters to the next step
            PermutationsChoose(results, remainingLetters, size, word + chosenChar);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb 's' stairs using memoization.
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize our cheat-sheet dictionary if this is the first call
        remember ??= new Dictionary<int, decimal>();

        // Base Cases: Quick answers for tiny staircases
        if (s <= 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3

        // Cheat Sheet Check: Return the cached answer if we solved this step before
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Sum the ways from taking a 1, 2, or 3-stair leap (passing our cheat sheet along)
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);

        // Save our newly found answer to the cheat sheet before returning
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    /// 
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {   
        // TODO Start Problem 4

        // Locate the first wildcard '*' in our pattern string
        int index = pattern.IndexOf('*');

        // Base Case: If no '*' remains, our binary string is complete
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Slice the string into pieces right before and right after the '*'
        string prefix = pattern[..index];
        string suffix = pattern[(index + 1)..];

        // Branch into two recursive paths: one with '0' replacing '*' and one with '1'
        WildcardBinary(prefix + '0' + suffix, results);
        WildcardBinary(prefix + '1' + suffix, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize path on first call
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }

        // TODO Start Problem 5

        // Drop a breadcrumb by recording our current spot in the path
        currPath.Add((x, y));

        // Base Case: If we hit the exit, convert path to string and add to results
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Set up movement offsets for Right, Left, Down, and Up
            (int dx, int dy)[] directions = { (1, 0), (-1, 0), (0, 1), (0, -1) };

            foreach (var (dx, dy) in directions)
            {
                int newX = x + dx;
                int newY = y + dy;

                // Move forward only if the next spot is valid (in bounds, open, unvisited)
                if (maze.IsValidMove(currPath, newX, newY))
                {
                    SolveMaze(results, maze, newX, newY, currPath);
                }
            }
        }

        // Backtrack: Remove current spot so other branches can explore through here
        currPath.RemoveAt(currPath.Count - 1);
    }
}