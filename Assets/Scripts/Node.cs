using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public BulletStats bulletStats = new BulletStats();

    public GameObject selectOverlay;
    public GameObject directionArrow;
    public GameObject[] bulletOverlays;

    public bool editable = true;

    public LevelGenerator levelGenerator;

    private void OnEnable()
    {
        levelGenerator = LevelGenerator.instance;
    }

    private void OnMouseDown()
    {
        ShowPropertiesOnWindow();
    }

    private void ShowPropertiesOnWindow()
    {
        if (editable)
        {
            PropertiesWindow.instance.SelectNode(this);
        }
    }

    public void ApplyProperties(BulletStats newProperties)
    {
        if (editable)
        {
            levelGenerator.level.RemoveBulletFromCurrentFrame(this, bulletStats);
            ShowPropertiesOnSelf(newProperties);
            levelGenerator.level.AddBulletToCurrentFrame(this, newProperties);
        }
    }

    public void ShowPropertiesOnSelf(BulletStats newProperties)
    {
        bulletStats = newProperties;

        if (bulletStats.type.Contains("Battery"))
        {
            bulletStats.direction = Vector2.zero;
        }

        for (int i = 1; i < bulletOverlays.Length; i++)
        {
            if (i.DropdownIndexToType() == bulletStats.type)
            {
                bulletOverlays[i].SetActive(true);
            }
            else
            {
                bulletOverlays[i].SetActive(false);
            }
        }

        if (bulletStats.type == "None" || bulletStats.direction == Vector2.zero)
        {
            directionArrow.SetActive(false);
        }
        else
        {
            directionArrow.SetActive(true);

            int angle = (bulletStats.direction.DirectionToDropdownIndex() - 1) * -45;
            directionArrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void ClearProperties(bool updateFrame)
    {
        if (editable)
        {
            if (updateFrame)
            {
                levelGenerator.level.RemoveBulletFromCurrentFrame(this, bulletStats);
            }

            ShowPropertiesOnSelf(BulletStats.BlankBulletStats(bulletStats.position));
        }
    }

    public void ToggleSelectOverlay(bool toggle)
    {
        selectOverlay.SetActive(toggle);
    }

    public void ChangeFrame()
    {
        if (bulletStats.type.Contains("Battery"))
        {
            if (LevelGenerator.instance.currentFrameIndex == 0)
            {
                editable = true;
            }
            else
            {
                editable = false;
            }
        }

        if (editable)
        {
            ClearProperties(false);
        }
    }
}
