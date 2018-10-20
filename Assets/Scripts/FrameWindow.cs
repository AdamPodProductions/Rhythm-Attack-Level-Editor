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
        frameNumberText.text = "Frame #" + levelGenerator.currentFrameIndex + "/" + levelGenerator.level.amountOfFrames;
    }

    public void Save()
    {
        Level level = levelGenerator.level;
        JSON.SaveLevel(level, saveInput.text );
    }
}
