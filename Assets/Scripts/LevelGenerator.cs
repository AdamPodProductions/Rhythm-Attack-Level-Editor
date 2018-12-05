using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    public Level level;
    public int currentFrameIndex = 0;

    public Text nameText;
    public Text sizeXText;
    public Text sizeYText;
    public Toggle customSongToggle;
    public InputField pathText;
    public Text bpmText;
    public Text framesText;

    public Node[] nodes;

    private GridGenerator gridGenerator;

    private void OnEnable()
    {
        instance = this;
    }

    private void Start()
    {
        gridGenerator = FindObjectOfType<GridGenerator>();
    }

    public void CreateLevel()
    {
        AudioClip song = null;

        if (customSongToggle.isOn)
        {
            WWW www = new WWW("file://" + pathText.text);
            song = www.GetAudioClip();

            level = new Level(nameText.text, new Vector2(int.Parse(sizeXText.text), int.Parse(sizeYText.text)), song, int.Parse(bpmText.text), int.Parse(framesText.text));
        }
        else
        {
            level = new Level(nameText.text, new Vector2(int.Parse(sizeXText.text), int.Parse(sizeYText.text)), int.Parse(framesText.text));
        }

        nodes = gridGenerator.GenerateGrid(level.size);
        gridGenerator.AddBatteries();
    }

    public void ChangeFrame(int newFrameIndex)
    {
        if (newFrameIndex >= 0 && newFrameIndex < level.frames.Length)
        {
            currentFrameIndex = newFrameIndex;

            foreach (Node node in nodes)
            {
                node.ChangeFrame();
            }

            if (level.GetCurrentFrame().bullets.Count > 0)
            {
                for (int i = 0; i < level.frames[currentFrameIndex].bullets.Count; i++)
                {
                    Frame currentFrame = level.frames[currentFrameIndex];
                    currentFrame.nodes[i].ShowPropertiesOnSelf(currentFrame.bullets[i]);
                }
            }
        }

        FrameWindow.instance.frameNumberText.text = "Frame #" + (currentFrameIndex + 1) + "/" + level.frames.Length;
    }

    public void FrameUp()
    {
        ChangeFrame(currentFrameIndex + 1);
    }

    public void FrameDown()
    {
        ChangeFrame(currentFrameIndex - 1);
    }
}

[System.Serializable]
public class Level
{
    public string name = "New Level";
    public Vector2 size = Vector2.one * 13f;
    public AudioClip song;
    public int bpm;
    public int amountOfFrames;

    public Frame[] frames = new Frame[0];

    public Level()
    {

    }

    public Level(string name, Vector2 size, AudioClip song, int bpm, int amountOfFrames)
    {
        this.name = name;
        this.size = size;
        this.song = song;
        this.bpm = bpm;
        this.amountOfFrames = amountOfFrames;

        frames = new Frame[amountOfFrames];
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i] = new Frame();
        }
    }

    public Level(string name, Vector2 size, int amountOfFrames)
    {
        this.name = name;
        this.size = size;
        this.amountOfFrames = amountOfFrames;

        frames = new Frame[amountOfFrames];
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i] = new Frame();
        }
    }

    public Frame GetCurrentFrame()
    {
        return frames[LevelGenerator.instance.currentFrameIndex];
    }

    public void AddBulletToCurrentFrame(Node node, BulletStats bullet)
    {
        frames[LevelGenerator.instance.currentFrameIndex].nodes.Add(node);
        frames[LevelGenerator.instance.currentFrameIndex].bullets.Add(bullet);
    }

    public void RemoveBulletFromCurrentFrame(Node node, BulletStats bullet)
    {
        frames[LevelGenerator.instance.currentFrameIndex].nodes.Remove(node);
        frames[LevelGenerator.instance.currentFrameIndex].bullets.Remove(bullet);
    }
}
