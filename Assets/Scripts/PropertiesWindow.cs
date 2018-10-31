using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertiesWindow : MonoBehaviour
{
    public static PropertiesWindow instance;

    public Text positionText;

    public Image[] modeButtons;
    public Image[] bulletTypeButtons;
    public Image[] directionButtons;

    [HideInInspector] public Node node;

    private string mode = "Select";
    private string selectedBulletType = "None";
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

            for (int i = 0; i < bulletTypeButtons.Length; i++)
            {
                if (i == bulletStats.bulletType.BulletTypeToDropdownIndex() && bulletStats.bulletType != "None")
                {
                    bulletTypeButtons[i].color = Color.white * 0.9f;
                }
                else
                {
                    bulletTypeButtons[i].color = Color.white;
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
            BulletStats bulletStats = new BulletStats(selectedBulletType, node.bulletStats.position, selectedDirection.DirectionStringToVector());
            node.ApplyProperties(bulletStats);

            ShowProperties();
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

    public void SelectBulletType(string bulletType)
    {
        selectedBulletType = bulletType;

        if (node != null && mode == "Draw")
        {
            node.bulletStats.bulletType = bulletType;
            node.ShowPropertiesOnSelf(node.bulletStats);
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
    public static int BulletTypeToDropdownIndex(this string bulletType)
    {
        if (bulletType == "Red")
        {
            return 0;
        }
        else if (bulletType == "Green")
        {
            return 1;
        }
        else if (bulletType == "Yellow")
        {
            return 2;
        }
        else if (bulletType == "Orange")
        {
            return 3;
        }
        else if (bulletType == "Blue")
        {
            return 4;
        }
        else if (bulletType == "Purple")
        {
            return 5;
        }
        else
        {
            return -1;
        }
    }

    public static string DropdownIndexToBulletType(this int index)
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
