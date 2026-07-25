reference
https://byui-cse.github.io/cse212-ww-course/index.html



performance cheat sheet
O(1)   <   O(log n)   <  O(n)   <   O(n log n)   <   O(n^2)   <   O(2^n)



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