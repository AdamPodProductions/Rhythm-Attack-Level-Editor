using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutManager : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    private PropertiesWindow propertiesWindow;

    private void Start()
    {
        levelGenerator = LevelGenerator.instance;
        propertiesWindow = PropertiesWindow.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            levelGenerator.FrameUp();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            levelGenerator.FrameDown();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            levelGenerator.AddFrame();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            levelGenerator.RemoveFrame();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            propertiesWindow.SelectMode("Select");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            propertiesWindow.SelectMode("Draw");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            propertiesWindow.SelectMode("Remove");
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            propertiesWindow.SetDirection("None");
            propertiesWindow.ApplyProperties();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            propertiesWindow.SetDirection("Up-Left");
            propertiesWindow.ApplyProperties();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            propertiesWindow.SetDirection("Up");
            propertiesWindow.ApplyProperties();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            propertiesWindow.SetDirection("Up-Right");
            propertiesWindow.ApplyProperties();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            propertiesWindow.SetDirection("Right");
            propertiesWindow.ApplyProperties();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            propertiesWindow.SetDirection("Down-Right");
            propertiesWindow.ApplyProperties();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            propertiesWindow.SetDirection("Down");
            propertiesWindow.ApplyProperties();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            propertiesWindow.SetDirection("Down-Left");
            propertiesWindow.ApplyProperties();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            propertiesWindow.SetDirection("Left");
            propertiesWindow.ApplyProperties();
        }
    }
}
