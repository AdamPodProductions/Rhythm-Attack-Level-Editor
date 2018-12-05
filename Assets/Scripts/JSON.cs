using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JSON
{
    public static void SaveLevel(Level level, string path)
    {
        string fullPath = path + "/" + level.name + ".json";
        string json = JsonUtility.ToJson(level);

        File.WriteAllText(fullPath, json);
    }

    public static Level LoadLevel(string path)
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<Level>(json);
    }
}
