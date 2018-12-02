using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameWindow : MonoBehaviour
{
    public static FrameWindow instance;

    public Text levelTitleText;
    public Text frameNumberText;
    public InputField saveInput;

    public Text saveText;

    private LevelGenerator levelGenerator;

    public void Start()
    {
        instance = this;
        levelGenerator = LevelGenerator.instance;

        Setup();
    }

    public void Setup()
    {
        levelTitleText.text = LevelGenerator.instance.level.name;
        frameNumberText.text = "Frame #" + (levelGenerator.currentFrameIndex + 1) + "/" + levelGenerator.level.amountOfFrames;
    }

    public void Save()
    {
        try
        {
            Level level = levelGenerator.level;
            JSON.SaveLevel(level, saveInput.text);

            saveText.text = "Saved successfully";
            saveText.color = new Color(0, 0.75f, 0);
        }
        catch
        {
            saveText.text = "Please try again";
            saveText.color = Color.red;
        }
    }
}
