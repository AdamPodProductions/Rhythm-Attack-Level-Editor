using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSON : MonoBehaviour
{
    public static void SaveLevel(Level level, string path)
    {
        string fullPath = path + "/" + level.name + ".json";
        string json = JsonUtility.ToJson(level);

        File.WriteAllText(fullPath, json);
    }
}
