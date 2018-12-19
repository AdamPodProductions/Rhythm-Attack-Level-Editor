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
    public InputField pathInput;

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
        FrameWindow.instance.Setup();
        ShortcutManager.instance.gameObject.SetActive(true);
    }

    public void LoadLevel()
    {
        level = JSON.LoadLevel(pathInput.text);
        nodes = gridGenerator.GenerateGrid(level.size);
        ChangeFrame(0);

        FrameWindow.instance.Setup();
        ShortcutManager.instance.gameObject.SetActive(true);
    }

    public Node GetNodeAtPosition(Vector2 position)
    {
        foreach (Node node in nodes)
        {
            if (node.bulletStats.position == position)
            {
                return node;
            }
        }

        return null;
    }

    public void ChangeFrame(int newFrameIndex)
    {
        if (newFrameIndex >= 0 && newFrameIndex < level.frames.Count)
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

                    try
                    {
                        currentFrame.nodes[i].ShowPropertiesOnSelf(currentFrame.bullets[i]);
                    }
                    catch
                    {
                        Node node = GetNodeAtPosition(currentFrame.bullets[i].position);
                        node.ShowPropertiesOnSelf(currentFrame.bullets[i]);
                        currentFrame.nodes.Add(node);
                    }
                }
            }
        }

        FrameWindow.instance.FrameSetup(currentFrameIndex, level.amountOfFrames);
    }

    public void FrameUp()
    {
        ChangeFrame(currentFrameIndex + 1);
    }

    public void FrameDown()
    {
        ChangeFrame(currentFrameIndex - 1);
    }

    public void AddFrame()
    {
        level.frames.Insert(currentFrameIndex + 1, new Frame());
        level.amountOfFrames++;
        ChangeFrame(currentFrameIndex + 1);

        FrameWindow.instance.FrameSetup(currentFrameIndex, level.amountOfFrames);
    }

    public void RemoveFrame()
    {
        if (level.amountOfFrames > 1)
        {
            level.frames.RemoveAt(currentFrameIndex);
            level.amountOfFrames--;

            if (currentFrameIndex >= level.amountOfFrames)
            {
                ChangeFrame(level.amountOfFrames - 1);
            }

            FrameWindow.instance.FrameSetup(currentFrameIndex, level.amountOfFrames);
        }
    }

    public void DuplicateFrame()
    {
        if (currentFrameIndex < level.frames.Count - 1)
        {
            level.frames[currentFrameIndex + 1] = new Frame(level.frames[currentFrameIndex]);
            FrameUp();
        }
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

    public List<Frame> frames = new List<Frame>();

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

        frames = new List<Frame>();
        for (int i = 0; i < amountOfFrames; i++)
        {
            frames.Add(new Frame());
        }
    }

    public Level(string name, Vector2 size, int amountOfFrames)
    {
        this.name = name;
        this.size = size;
        this.amountOfFrames = amountOfFrames;

        frames = new List<Frame>();
        for (int i = 0; i < amountOfFrames; i++)
        {
            frames.Add(new Frame());
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
