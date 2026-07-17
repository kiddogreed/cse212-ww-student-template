using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        // LAYMAN'S TERMS:
        // 'result' holds our final matched word pairs (like "am & ma").
        // 'seen' is a digital bucket where we drop words we have already looked at.
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            // LAYMAN'S TERMS:
            // Flip the 2-letter word backwards (e.g., "am" becomes "ma").
            string reversed = "" + word[1] + word[0];

            // LAYMAN'S TERMS:
            // Check our bucket. If the flipped version is already in there, 
            // we found a match! We bundle them together into our results list.
            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                // LAYMAN'S TERMS:
                // If the flipped version isn't in our bucket yet, drop the current 
                // word into the bucket so future words can check against it.
                seen.Add(word);
            }
        }
        
        // Return all the matched pairs we found.
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // LAYMAN'S TERMS:
        // 'degrees' acts like a tally sheet. The "Key" is the degree name,
        // and the "Value" is the running number of people who have it.
        var degrees = new Dictionary<string, int>();
        
        foreach (var line in File.ReadLines(filename))
        {
            // LAYMAN'S TERMS:
            // Cut the line of text into separate columns wherever there is a comma.
            var fields = line.Split(",");
            
            // Make sure the line actually has at least 4 columns of information.
            if (fields.Length > 3)
            {
                // LAYMAN'S TERMS:
                // Grab the 4th column (index 3) and clean off any accidental empty spaces.
                string degree = fields[3].Trim();

                // LAYMAN'S TERMS:
                // If this degree is already on our tally sheet, add 1 to its count.
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    // LAYMAN'S TERMS:
                    // If it's a brand new degree name, write it down on our sheet with a count of 1.
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // LAYMAN'S TERMS:
        // Clean up both words by turning all letters lowercase and erasing spaces.
        string clean1 = word1.ToLower().Replace(" ", "");
        string clean2 = word2.ToLower().Replace(" ", "");

        // LAYMAN'S TERMS:
        // If they don't even have the same number of letters, they can't be anagrams.
        if (clean1.Length != clean2.Length)
        {
            return false;
        }

        // LAYMAN'S TERMS:
        // This dictionary works like an inventory tracker for letters.
        var charCounts = new Dictionary<char, int>();

        // LAYMAN'S TERMS:
        // Walk through the first word. Add every letter to our inventory tracker.
        foreach (char c in clean1)
        {
            if (charCounts.ContainsKey(c))
                charCounts[c]++;
            else
                charCounts[c] = 1;
        }

        // LAYMAN'S TERMS:
        // Walk through the second word. Remove a letter from our inventory for each character seen.
        foreach (char c in clean2)
        {
            // If the second word contains a letter we never tracked, it's not an anagram.
            if (!charCounts.ContainsKey(c))
            {
                return false;
            }

            charCounts[c]--;

            // If we use up more of a letter than we inventory tracked, it's not an anagram.
            if (charCounts[c] < 0)
            {
                return false;
            }
        }
        
        // If everything balances out perfectly, it is an anagram!
        return true;
    }

    /// <summary>
    /// This function will read JSON data from the USGS consisting of earthquake data.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // LAYMAN'S TERMS:
        // Take a giant, raw text block of web data (JSON) and sort it cleanly into the FeatureCollection structure.
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // LAYMAN'S TERMS:
        // Create an empty list where we can build our human-readable text sentences.
        var summary = new List<string>();

        // Make sure the data we downloaded isn't completely empty.
        if (featureCollection?.Features != null)
        {
            // LAYMAN'S TERMS:
            // Cycle through every individual earthquake recorded today.
            foreach (var feature in featureCollection.Features)
            {
                if (feature.Properties != null)
                {
                    // LAYMAN'S TERMS:
                    // Pull out the location name and the size (magnitude) of the quake.
                    string place = feature.Properties.Place;
                    double mag = feature.Properties.Mag;
                    
                    // Format them into a nice, clean string sentence and save it.
                    summary.Add($"{place} - Mag {mag}");
                }
            }
        }
        
        return summary.ToArray();
    }
}