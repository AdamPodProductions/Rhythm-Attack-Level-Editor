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

            else if (Input.GetKeyDown(KeyCode.X))
            {
                RotateClockwise();
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                RotateCounterClockwise();
            }
        }

        canActivate = saveField.isFocused == false && specialtyNumberField.isFocused == false;
    }

    private void RotateClockwise()
    {
        BulletStats bulletStats = propertiesWindow.node.bulletStats;
        Vector2 newDirection = Vector2.zero;

        if (bulletStats.direction == Vector2.zero || bulletStats.direction == new Vector2(-1, 1))
        {
            newDirection = Vector2.up;
        }
        else if (bulletStats.direction == Vector2.up)
        {
            newDirection = Vector2.one;
        }
        else if (bulletStats.direction == Vector2.one)
        {
            newDirection = Vector2.right;
        }
        else if (bulletStats.direction == Vector2.right)
        {
            newDirection = new Vector2(1, -1);
        }
        else if (bulletStats.direction == new Vector2(1, -1))
        {
            newDirection = Vector2.down;
        }
        else if (bulletStats.direction == Vector2.down)
        {
            newDirection = -Vector2.one;
        }
        else if (bulletStats.direction == -Vector2.one)
        {
            newDirection = Vector2.left;
        }
        else if (bulletStats.direction == Vector2.left)
        {
            newDirection = new Vector2(-1, 1);
        }

        propertiesWindow.node.bulletStats.direction = newDirection;
        propertiesWindow.SetDirection(newDirection);
    }

    private void RotateCounterClockwise()
    {
        BulletStats bulletStats = propertiesWindow.node.bulletStats;
        Vector2 newDirection = Vector2.zero;

        if (bulletStats.direction == Vector2.zero || bulletStats.direction == Vector2.one)
        {
            newDirection = Vector2.up;
        }
        else if (bulletStats.direction == Vector2.up)
        {
            newDirection = new Vector2(-1, 1);
        }
        else if (bulletStats.direction == new Vector2(-1, 1))
        {
            newDirection = Vector2.left;
        }
        else if (bulletStats.direction == Vector2.right)
        {
            newDirection = Vector2.one;
        }
        else if (bulletStats.direction == new Vector2(1, -1))
        {
            newDirection = Vector2.right;
        }
        else if (bulletStats.direction == Vector2.down)
        {
            newDirection = new Vector2(1, -1);
        }
        else if (bulletStats.direction == -Vector2.one)
        {
            newDirection = Vector2.down;
        }
        else if (bulletStats.direction == Vector2.left)
        {
            newDirection = -Vector2.one;
        }

        propertiesWindow.node.bulletStats.direction = newDirection;
        propertiesWindow.SetDirection(newDirection);
    }
}
