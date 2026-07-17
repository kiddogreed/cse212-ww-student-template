using System.Collections.Generic;

/// <summary>
/// LAYMAN'S TERMS:
/// This file acts as a structural blueprint or a "map" for the computer. 
/// When we download the massive block of raw text (JSON) from the USGS website,
/// these classes tell C# exactly where to navigate inside that text block to find
/// the specific earthquake data we care about (the location and the size).
/// </summary>

public class FeatureCollection
{
    // LAYMAN'S TERMS:
    // The USGS data starts with a main container. Inside this container, there is 
    // a list of individual records. We call this list "Features".
    public List<Feature> Features { get; set; }
}

public class Feature
{
    // LAYMAN'S TERMS:
    // Each individual "Feature" represents a single, specific earthquake event.
    // Inside this event record is a folder of details called "Properties".
    public Properties Properties { get; set; }
}

public class Properties
{
    // LAYMAN'S TERMS:
    // Inside the "Properties" folder, we grab the two specific details we need:
    // 1. 'Place' - The text description of where the earthquake happened.
    // 2. 'Mag' - The number representing how strong the earthquake was (magnitude).
    public string Place { get; set; }
    public double Mag { get; set; }
}