using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public BulletStats bulletStats = new BulletStats();

    public GameObject selectOverlay;
    public GameObject directionArrow;
    public GameObject[] bulletOverlays;

    private Level level;

    private void Start()
    {
        level = LevelGenerator.instance.level;
    }

    private void OnMouseDown()
    {
        ShowPropertiesOnWindow();
    }

    private void ShowPropertiesOnWindow()
    {
        PropertiesWindow.instance.ShowProperties(this);
    }

    public void ApplyProperties(BulletStats newProperties)
    {
        if (level.GetCurrentFrame().bullets.Contains(new BulletStats()))
        {
            level.RemoveBulletFromCurrentFrame(this, bulletStats);
        }

        ShowPropertiesOnSelf(newProperties);

        level.AddBulletToCurrentFrame(this, newProperties);
    }

    public void ShowPropertiesOnSelf(BulletStats newProperties)
    {
        bulletStats = newProperties;

        for (int i = 1; i < bulletOverlays.Length; i++)
        {
            if (i.DropdownIndexToBulletType() == bulletStats.bulletType)
            {
                bulletOverlays[i].SetActive(true);
            }
            else
            {
                bulletOverlays[i].SetActive(false);
            }
        }

        if (bulletStats.bulletType == "None" || bulletStats.direction == Vector2.zero)
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
        if (level.GetCurrentFrame().bullets.Contains(new BulletStats()) && updateFrame)
        {
            level.RemoveBulletFromCurrentFrame(this, bulletStats);
        }

        ShowPropertiesOnSelf(BulletStats.BlankBulletStats(bulletStats.position));

        if (updateFrame)
        {
            level.AddBulletToCurrentFrame(this, bulletStats);
        }
    }

    public void ToggleSelectOverlay(bool toggle)
    {
        selectOverlay.SetActive(toggle);
    }
}
