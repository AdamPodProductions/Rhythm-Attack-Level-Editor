using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutManager : MonoBehaviour
{
    public static ShortcutManager instance;

    public InputField saveField;
    public InputField specialtyNumberField;

    private LevelGenerator levelGenerator;
    private PropertiesWindow propertiesWindow;

    private bool canActivate = true;

    private void Start()
    {
        instance = this;

        levelGenerator = LevelGenerator.instance;
        propertiesWindow = PropertiesWindow.instance;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (canActivate)
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
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                propertiesWindow.SetDirection("Up-Left");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                propertiesWindow.SetDirection("Up");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                propertiesWindow.SetDirection("Up-Right");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                propertiesWindow.SetDirection("Right");
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                propertiesWindow.SetDirection("Down-Right");
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                propertiesWindow.SetDirection("Down");
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                propertiesWindow.SetDirection("Down-Left");
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                propertiesWindow.SetDirection("Left");
            }
        }

        canActivate = saveField.isFocused == false && specialtyNumberField.isFocused == false;
    }
}
