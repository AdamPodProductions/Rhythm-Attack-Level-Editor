using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    public Level level;

    public Text nameText;
    public Text sizeXText;
    public Text sizeYText;

    private GridGenerator gridGenerator;

    private void Start()
    {
        gridGenerator = GetComponent<GridGenerator>();
    }

    public void CreateLevel()
    {
        level = new Level(nameText.text, new Vector2(int.Parse(sizeXText.text), int.Parse(sizeYText.text)));
        gridGenerator.GenerateGrid(level.size);
    }
}

[System.Serializable]
public class Level
{
    public string name = "New Level";
    public Vector2 size = Vector2.one * 13f;

    public Level()
    {

    }

    public Level(string name, Vector2 size)
    {
        this.name = name;
        this.size = size;
    }
}
