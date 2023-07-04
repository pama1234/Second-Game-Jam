using System.IO;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public static class FileAccess 
{
    private const string _defaultExtension = ".json";
    private static string BasePath => Path.Combine(Application.persistentDataPath);
    public static bool SaveString(string filename, bool includesExtension, string value)
    {
        return true;
    }

}
