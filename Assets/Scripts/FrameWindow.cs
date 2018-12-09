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

    public void OnEnable()
    {
        instance = this;
        levelGenerator = LevelGenerator.instance;
    }

    public void Setup()
    {
        TitleSetup(levelGenerator.level.name);
        FrameSetup(0, levelGenerator.level.amountOfFrames);
    }

    public void TitleSetup(string name)
    {
        levelTitleText.text = name;
    }

    public void FrameSetup(int currentFrame, int totalFrames)
    {
        frameNumberText.text = "Frame #" + (currentFrame + 1) + "/" + totalFrames;
    }

    public void Save()
    {
        try
        {
            JSON.SaveLevel(levelGenerator.level, saveInput.text);

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
