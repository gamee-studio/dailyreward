using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class ExtensionIO
{
    /// <summary>
    /// Create dictionary with <paramref name="directoryPath"/>
    /// </summary>
    /// <param name="directoryPath"></param>
    public static void CreateDirectory(this string directoryPath) { Directory.CreateDirectory(directoryPath); }

    /// <summary>
    /// Indicate if the directory with path <paramref name="directoryPath"/> exists?
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <returns></returns>
    public static bool DirectoryExists(this string directoryPath) { return Directory.Exists(directoryPath); }
    public static bool FileExists(this string filePath) { return File.Exists(filePath); }
}
