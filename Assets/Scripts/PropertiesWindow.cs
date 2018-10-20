using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertiesWindow : MonoBehaviour
{
    public static PropertiesWindow instance;

    public Text positionText;
    public Dropdown bulletTypeDropdown;
    public Dropdown directionDropdown;

    [HideInInspector] public Node node;
    private BulletStats bulletStats;

    private void OnEnable()
    {
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowProperties(Node newNode)
    {
        gameObject.SetActive(true);

        if (node != null)
        {
            node.ToggleSelectOverlay(false);
        }

        node = newNode;
        bulletStats = newNode.bulletStats;

        newNode.ToggleSelectOverlay(true);

        positionText.text = "(" + bulletStats.position.x + ", " + bulletStats.position.y + ")";
        bulletTypeDropdown.value = bulletStats.bulletType.BulletTypeToDropdownIndex();
        directionDropdown.value = bulletStats.direction.DirectionToDropdownIndex();
    }

    public void ApplyProperties()
    {
        if (node != null)
        {
            bulletStats = new BulletStats(bulletTypeDropdown.value.DropdownIndexToBulletType(), bulletStats.position, directionDropdown.value.DropdownIndexToDirection());
            node.ApplyProperties(bulletStats);
        }
    }
}

public static class Extension
{
    public static int BulletTypeToDropdownIndex(this string bulletType)
    {
        if (bulletType == "None")
        {
            return 0;
        }
        else if (bulletType == "Red")
        {
            return 1;
        }
        else if (bulletType == "Blue")
        {
            return 2;
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
            return "Blue";
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
}
