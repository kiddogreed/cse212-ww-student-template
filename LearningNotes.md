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



week 2



Stack - LIFO
Queue - FIFO