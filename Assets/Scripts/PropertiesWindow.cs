using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertiesWindow : MonoBehaviour
{
    public static PropertiesWindow instance;

    public Text positionText;

    public Image[] modeButtons;
    public Image[] typeButtons;
    public Image[] directionButtons;

    [HideInInspector] public Node node;

    private string mode = "Select";
    private string selectedtype = "None";
    private string selectedDirection = "None";

    private void OnEnable()
    {
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void ShowProperties()
    {
        gameObject.SetActive(true);

        if (node != null)
        {
            BulletStats bulletStats = node.bulletStats;
            positionText.text = "(" + bulletStats.position.x + ", " + bulletStats.position.y + ")";

            for (int i = 0; i < typeButtons.Length; i++)
            {
                if (i == bulletStats.type.TypeToDropdownIndex() && bulletStats.type != "None")
                {
                    typeButtons[i].color = Color.white * 0.9f;
                }
                else
                {
                    typeButtons[i].color = Color.white;
                }
            }

            for (int i = 0; i < directionButtons.Length; i++)
            {
                if (i == bulletStats.direction.DirectionToDropdownIndex())
                {
                    directionButtons[i].color = Color.white * 0.9f;
                }
                else
                {
                    directionButtons[i].color = Color.white;
                }
            }
        }
    }

    public void SelectNode(Node newNode)
    {
        if (node != null)
        {
            node.ToggleSelectOverlay(false);
        }

        node = newNode;
        node.ToggleSelectOverlay(true);

        if (mode == "Draw")
        {
            ApplyProperties();
        }
        else if (mode == "Remove")
        {
            node.ClearProperties(true);
        }

        ShowProperties();
    }

    public void ApplyProperties()
    {
        if (node != null)
        {
            if (node.bulletStats.type.Contains("Battery"))
            {
                if (LevelGenerator.instance.currentFrameIndex == 0)
                {
                    BulletStats bulletStats = new BulletStats(selectedtype, node.bulletStats.position, selectedDirection.DirectionStringToVector());
                    node.ApplyProperties(bulletStats);

                    ShowProperties();
                }
            }
            else
            {
                BulletStats bulletStats = new BulletStats(selectedtype, node.bulletStats.position, selectedDirection.DirectionStringToVector());
                node.ApplyProperties(bulletStats);

                ShowProperties();
            }
        }
    }

    public void SelectMode(string mode)
    {
        this.mode = mode;

        int modeIndex = (mode == "Select") ? 0 : (mode == "Draw") ? 1 : 2;
        for (int i = 0; i < modeButtons.Length; i++)
        {
            if (i == modeIndex)
            {
                modeButtons[i].color = Color.white * 0.9f;
            }
            else
            {
                modeButtons[i].color = Color.white;
            }
        }
    }

    public void SelectType(string type)
    {
        selectedtype = type;

        if (node != null && mode == "Draw")
        {
            if (node.bulletStats.type.Contains("Battery"))
            {
                if (LevelGenerator.instance.currentFrameIndex == 0)
                {
                    node.bulletStats.type = type;
                    //node.ShowPropertiesOnSelf(node.bulletStats);
                    //node.ApplyProperties(node.bulletStats);
                    SelectNode(node);
                }
            }
            else
            {
                node.bulletStats.type = type;
                SelectNode(node);
            }
        }

        ShowProperties();
    }

    public void SetDirection(string direction)
    {
        selectedDirection = direction;

        if (node != null && mode == "Draw")
        {
            node.bulletStats.direction = direction.DirectionStringToVector();
            node.ShowPropertiesOnSelf(node.bulletStats);
        }

        ShowProperties();
    }
}

public static class Extension
{
    public static int TypeToDropdownIndex(this string type)
    {
        if (type == "Red")
        {
            return 0;
        }
        else if (type == "Green")
        {
            return 1;
        }
        else if (type == "Yellow")
        {
            return 2;
        }
        else if (type == "Orange")
        {
            return 3;
        }
        else if (type == "Blue")
        {
            return 4;
        }
        else if (type == "Purple")
        {
            return 5;
        }
        else if (type == "RedLaser")
        {
            return 6;
        }
        else if (type == "YellowLaser")
        {
            return 7;
        }
        else if (type == "OrangeLaser")
        {
            return 8;
        }
        else if (type == "BlueLaser")
        {
            return 9;
        }
        else if (type == "GreenLaser")
        {
            return 10;
        }
        else if (type == "PurpleLaser")
        {
            return 11;
        }
        else if (type == "RedBattery")
        {
            return 12;
        }
        else if (type == "YellowBattery")
        {
            return 13;
        }
        else if (type == "OrangeBattery")
        {
            return 14;
        }
        else if (type == "BlueBattery")
        {
            return 15;
        }
        else if (type == "GreenBattery")
        {
            return 16;
        }
        else if (type == "PurpleBattery")
        {
            return 17;
        }
        else
        {
            return -1;
        }
    }

    public static string DropdownIndexToType(this int index)
    {
        if (index == 0)
        {
            return "None";
        }
        else if (index == 1)
        {
            return "Red";
        }
        else if (index == 2)
        {
            return "Green";
        }
        else if (index == 3)
        {
            return "Yellow";
        }
        else if (index == 4)
        {
            return "Orange";
        }
        else if (index == 5)
        {
            return "Blue";
        }
        else if (index == 6)
        {
            return "Purple";
        }
        else if (index == 7)
        {
            return "RedLaser";
        }
        else if (index == 8)
        {
            return "YellowLaser";
        }
        else if (index == 9)
        {
            return "OrangeLaser";
        }
        else if (index == 10)
        {
            return "BlueLaser";
        }
        else if (index == 11)
        {
            return "GreenLaser";
        }
        else if (index == 12)
        {
            return "PurpleLaser";
        }
        else if (index == 13)
        {
            return "RedBattery";
        }
        else if (index == 14)
        {
            return "YellowBattery";
        }
        else if (index == 15)
        {
            return "OrangeBattery";
        }
        else if (index == 16)
        {
            return "BlueBattery";
        }
        else if (index == 17)
        {
            return "GreenBattery";
        }
        else if (index == 18)
        {
            return "PurpleBattery";
        }
        else
        {
            return null;
        }
    }

    public static int DirectionToDropdownIndex(this Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return 0;
        }
        else if (direction == Vector2.up)
        {
            return 1;
        }
        else if (direction == Vector2.one)
        {
            return 2;
        }
        else if (direction == Vector2.right)
        {
            return 3;
        }
        else if (direction == new Vector2(1, -1))
        {
            return 4;
        }
        else if (direction == Vector2.down)
        {
            return 5;
        }
        else if (direction == Vector2.one * -1)
        {
            return 6;
        }
        else if (direction == Vector2.left)
        {
            return 7;
        }
        else if (direction == new Vector2(-1, 1))
        {
            return 8;
        }
        else
        {
            return -1;
        }
    }

    public static Vector2 DropdownIndexToDirection(this int index)
    {
        if (index == 0)
        {
            return Vector2.zero;
        }
        else if (index == 1)
        {
            return Vector2.up;
        }
        else if (index == 2)
        {
            return Vector2.one;
        }
        else if (index == 3)
        {
            return Vector2.right;
        }
        else if (index == 4)
        {
            return new Vector2(1, -1);
        }
        else if (index == 5)
        {
            return Vector2.down;
        }
        else if (index == 6)
        {
            return Vector2.one * -1;
        }
        else if (index == 7)
        {
            return Vector2.left;
        }
        else if (index == 8)
        {
            return new Vector2(-1, 1);
        }
        else
        {
            return Vector2.positiveInfinity;
        }
    }

    public static Vector2 DirectionStringToVector(this string directionString)
    {
        if (directionString == "None")
        {
            return Vector2.zero;
        }
        else if (directionString == "Up")
        {
            return Vector2.up;
        }
        else if (directionString == "Up-Right")
        {
            return Vector2.one;
        }
        else if (directionString == "Right")
        {
            return Vector2.right;
        }
        else if (directionString == "Down-Right")
        {
            return new Vector2(1, -1);
        }
        else if (directionString == "Down")
        {
            return Vector2.down;
        }
        else if (directionString == "Down-Left")
        {
            return Vector2.one * -1;
        }
        else if (directionString == "Left")
        {
            return Vector2.left;
        }
        else if (directionString == "Up-Left")
        {
            return new Vector2(-1, 1);
        }
        else
        {
            return Vector2.positiveInfinity;
        }
    }
}
