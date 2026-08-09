performance cheat sheet
O(1)   <   O(log n)   <   O(n)   <   O(n log n)   <   O(n^2)   <   O(2^n)



# Week 03 Activity Summary: Sets and Maps

## Overview
This week, I implemented collection data structures (`HashSet` and `Dictionary`) in C# to achieve optimal $O(1)$ and $O(n)$ data processing efficiency across four distinct tasks: finding word patterns, parsing flat-file datasets, processing custom structural comparison algorithms, and navigating directional graph coordinates.

---

## What I Did & How I Fixed It

### Problem 1: Symmetric Word Pairs (`FindPairs`)
* **What I Did:** Implemented a system to parse an array of 2-letter words and find matching reflections (e.g., matching "am" with "ma") using linear time complexity.
* **How I Fixed It:** Used a `HashSet<string>` to store visited items. For every word encountered, the program reverses its characters and inspects the set using a quick lookahead check. 
  * *Correction Note:* A critical bug involving an early `return [];` statement at the top of the template loop was removed, restoring proper code control and loop execution.

### Problem 2: Education Census Processing (`SummarizeDegrees`)
* **What I Did:** Programmed a file parser that tracks and tallies total occurrences of unique educational degrees located inside a flat CSV data block.
* **How I Fixed It:** Used `File.ReadLines` to streams data efficiently without memory spikes. Split string buffers across raw row commas, targeting column index 3 (`fields[3]`). Fed target elements directly into a dynamic `Dictionary<string, int>`, automatically resolving unique keys and incrementing numerical counters.

### Problem 3: Optimization-Safe String Matching (`IsAnagram`)
* **What I Did:** Constructed an algorithmic character matching system to test if two inputs share identical alphabetic content under isolated conditions (case-insensitive, space-agnostic).
* **How I Fixed It:** Sanitized inputs by applying `.ToLower()` and stripping structural blanks via `.Replace(" ", "")`. Employed a character-tracking `Dictionary<char, int>` inventory system: matching characters on the first word incremented inventory keys, while tracking through the second decremented them. Any negative offset or unmatched keys triggered a safe `false` exit.

### Problem 4: Grid Tracking Coordinates (`Maze.cs`)
* **What I Did:** Developed state logic handlers inside the `Maze` class to change movement coordinate positions based on bitwise dictionary directions `[left, right, up, down]`.
* **How I Fixed It:** mapped multidirectional paths through coordinate keys mapped via structural values (`ValueTuple<int, int>`). Upgraded basic print statements into structural state boundaries by throwing a designated `InvalidOperationException("Can't go that way!")` whenever a collision boundary (`false` index state) was violated.

### Problem 5: USGS Dynamic Schema Mapping (`EarthquakeDailySummary`)
* **What I Did:** Parsed structural geological datasets downloaded from live remote web sources down into application entity frames.
* **How I Fixed It:** Extracted structural classes from procedural runtime routines and refactored them directly inside `FeatureCollection.cs` as standard, explicit structural node pathways (`FeatureCollection`, `Feature`, and `Properties`). Resolved compiler exceptions in `SetsAndMaps.cs` by properly initializing a localized processing engine collection (`var summary = new List<string>();`) prior to iterative object mapping.



## Week 02

Stack - LIFO
Queue - FIFO



# Week 04 Activity Summary: Linked Lists

## Overview
This week, I implemented core operations for a doubly linked list structure (`LinkedList`) in C#. I focused on managing bi-directional pointer references (`_head`, `_tail`, `Next`, and `Prev`) while maintaining optimal time complexities: $O(1)$ for insertion and deletion at list boundaries, and $O(n)$ for search, replacement, and traversal operations.

---

## What I Did & How I Fixed It

### Problem 1: Appending End Nodes (`InsertTail`)
* **What I Did:** Constructed an insertion function to append new data elements directly to the end of the doubly linked list in $O(1)$ constant time.
* **How I Fixed It:** Created a new `Node` instance and checked for an empty list state (`_head is null`). For empty lists, both `_head` and `_tail` were mapped to the new node. For existing lists, linked the current `_tail.Next` to the new node, pointed `newNode.Prev` back to `_tail`, and updated `_tail` to refer to the new node.

### Problem 2: Tail Node Removal (`RemoveTail`)
* **What I Did:** Developed a boundary removal algorithm to clear the final node from the list while preventing dangling pointers or null reference exceptions.
* **How I Fixed It:** Evaluated single-element or empty list conditions using `_head == _tail` to safely reset both references to null. For multi-node lists, updated `_tail.Prev.Next` to null to detach the final node before shifting `_tail` backward to point to `_tail.Prev`.

### Problem 3: Value-Based Node Deletion (`Remove`)
* **What I Did:** Implemented a targeted search and delete procedure that locates the first occurrence of a specific value and decouples its node from the list chain.
* **How I Fixed It:** Iterated through the list starting at `_head`. Integrated delegate execution for boundary nodes by calling `RemoveHead()` or `RemoveTail()` when matching on `_head` or `_tail`. For middle nodes, bridged the surrounding links by setting `curr.Prev.Next = curr.Next` and `curr.Next.Prev = curr.Prev`, exiting early via `return` immediately upon first match removal.

### Problem 4: Global Value Substitution (`Replace`)
* **What I Did:** Built a search and update routine that scans the entire data structure to substitute all instances of `oldValue` with `newValue`.
* **How I Fixed It:** Traversed the sequence linearly from `_head` to `_tail` using a while loop. Updated node values directly via `curr.Data = newValue` without modifying node pointer references (`Next`/`Prev`), allowing continuous iteration across the entire list to replace all occurrences.

### Problem 5: Reverse Traversal Iteration (`Reverse`)
* **What I Did:** Built a custom reverse iterator using C#'s `yield return` state engine to allow backwards iteration across the collection using `foreach` loops.
* **How I Fixed It:** Patterned the generator logic after `GetEnumerator()`, but reversed direction by initializing `curr` at `_tail`. Used a `while (curr is not null)` loop to `yield return curr.Data`, stepping backward through the collection on each iteration using `curr = curr.Prev`.



# Week 05 Activity Summary: Recursion

## Overview
This week, I focused on writing recursive algorithms in C# to solve problems by dividing them into smaller sub-problems. I practiced identifying base cases to terminate recursion safely, managing call stack depth, and applying optimization strategies like memoization to reduce time complexity from exponential $O(2^n)$ down to linear $O(n)$, alongside implementing search trees and backtracking algorithms.

---

## What I Did & How I Fixed It

### Problem 1: Recursive Squares Sum (`SumSquaresRecursive`)
* **What I Did:** Implemented a recursive accumulator to compute the sum of squares $1^2 + 2^2 + \dots + n^2$ without using any iterative loops.
* **How I Fixed It:** Defined a clear terminating base case that returns `0` when $n \le 0$. Formulated the recursive step as `(n * n) + SumSquaresRecursive(n - 1)`, reducing $n$ by $1$ on each frame until reaching the base case.

### Problem 2: Permutations Choose (`PermutationsChoose`)
* **What I Did:** Formulated a recursive algorithm to generate all string permutations of a given length `size` using unique letters from a target pool.
* **How I Fixed It:** Implemented a recursive branch-and-bound strategy using a base case that checks if `word.Length == size`. In the recursive step, iterated through available characters, detached the selected character from the pool via `.Remove(i, 1)`, and passed the updated substring and partial word into the next recursive call stack frame.

### Problem 3: Staircase Climbing with Memoization (`CountWaysToClimb`)
* **What I Did:** Calculated the total ways to climb $s$ stairs given 1-, 2-, or 3-step leaps, optimizing the calculation to handle large inputs efficiently.
* **How I Fixed It:** Set up base cases for $s \le 0 \rightarrow 0$, $s=1 \rightarrow 1$, $s=2 \rightarrow 2$, and $s=3 \rightarrow 4$. Integrated dynamic memoization using a `Dictionary<int, decimal>` passed across recursive frames: checked if `remember.ContainsKey(s)` to return pre-computed cached values instantly, reducing runtime complexity from $O(3^n)$ to $O(n)$.

### Problem 4: Wildcard Binary Patterns (`WildcardBinary`)
* **What I Did:** Evaluated binary string patterns containing wildcard `'*'` characters and recursively generated all possible fully-resolved binary string permutations.
* **How I Fixed It:** Located wildcards using `.IndexOf('*')`. Created a base case where an index of `-1` adds the completed binary string to `results`. For wildcards, sliced the string into prefix and suffix ranges using C# range syntax (`[..index]` and `[(index + 1)..]`), then executed two recursive branches replacing `'*'` with `'0'` and `'1'`.

### Problem 5: Recursive Maze Pathfinding & Backtracking (`SolveMaze`)
* **What I Did:** Constructed a depth-first search (DFS) pathfinder to navigate an $n \times n$ grid maze from $(0,0)$ to the destination node $(x,y)$ using spatial backtracking.
* **How I Fixed It:** Pushed the current position tuple $(x, y)$ onto `currPath`. Check if `maze.IsEnd(x, y)` to add matching path strings to `results`. Loop through directional offset vectors (Right, Left, Down, Up) and validate moves using `maze.IsValidMove`. Applied a strict **backtracking step** (`currPath.RemoveAt(currPath.Count - 1)`) after exploring neighbors to unwind stack state cleanly.



# Week 06 Activity Summary: Trees

## Overview
This week, I implemented core operations for a Binary Search Tree (BST) structure in C# across `Node.cs`, `BinarySearchTree.cs`, and `Trees.cs`. I focused on recursive tree traversals, maintaining BST invariant properties, calculating tree height, enforcing unique values (Set behavior), and constructing balanced trees from sorted arrays in $O(n)$ time.

---

## What I Did & How I Fixed It

### Problem 1: Insert Unique Values Only (`Node.cs`)
* **What I Did:** Modified the node insertion algorithm to ignore duplicate values, ensuring the Binary Search Tree behaves like a mathematical Set containing unique keys.
* **How I Fixed It:** Replaced the default `else` fallback—which previously routed duplicate values to the right branch—with an explicit `else if (value > Data)`. When `value == Data`, the function simply exits without making recursive calls or instantiating new nodes, preventing duplicates from entering the tree.

### Problem 2: Recursive Value Search (`Node.cs`)
* **What I Did:** Implemented a recursive `Contains` method to search for a target value in $O(\log n)$ average time complexity.
* **How I Fixed It:** Defined a base case checking if `value == Data` to return `true`. For smaller or larger target values, checked if `Left` or `Right` child pointers were non-null before recursively calling `Contains(value)` down the appropriate subtree, returning `false` if an empty child spot (`null`) was reached.

### Problem 3: Reverse Order Traversal (`BinarySearchTree.cs`)
* **What I Did:** Implemented the `TraverseBackward` recursive yield-generator to traverse the tree in descending order (largest value down to smallest value), enabling custom `foreach` iteration.
* **How I Fixed It:** Mirrored standard in-order traversal by visiting nodes in reverse order: recursively traversed the `Right` subtree first, yielded the current node's value (`yield return node.Data`), and then recursively traversed the `Left` subtree.

### Problem 4: Recursive Tree Height Calculation (`Node.cs`)
* **What I Did:** Constructed a recursive algorithm to measure the maximum height (depth) of any tree or subtree.
* **How I Fixed It:** Evaluated the height of child branches using null-conditional access (`Left?.GetHeight() ?? 0` and `Right?.GetHeight() ?? 0`). Computed the overall node height using $1 + \max(\text{leftHeight}, \text{rightHeight})$, returning $1$ for a standalone root node with no children.

### Problem 5: Balanced BST Construction from Sorted Array (`Trees.cs`)
* **What I Did:** Developed the recursive `InsertMiddle` function to convert a sorted array into a fully balanced BST without creating dynamic array slices or requiring complex AVL rotation algorithms.
* **How I Fixed It:** Used a divide-and-conquer strategy using `first` and `last` index boundaries. Computed the midpoint index `middle = (first + last) / 2` and inserted `sortedNumbers[middle]` into the BST. Then made two recursive calls—one for the left subarray (`first` to `middle - 1`) and one for the right subarray (`middle + 1` to `last`)—terminating when `first > last`.