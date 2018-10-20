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
        ShowBulletStats();
    }

    private void ShowBulletStats()
    {
        PropertiesWindow.instance.ShowProperties(this);
    }

    public void ApplyProperties(BulletStats newProperties)
    {
        if (level.GetCurrentFrame().bullets.Contains(new BulletStats()))
        {
            level.RemoveBulletFromCurrentFrame(bulletStats);
        }

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

        level.AddBulletToCurrentFrame(bulletStats);
    }

    public void ClearProperties(bool updateFrame)
    {
        if (level.GetCurrentFrame().bullets.Contains(new BulletStats()) && updateFrame)
        {
            level.RemoveBulletFromCurrentFrame(bulletStats);
        }

        bulletStats = BulletStats.BlankBulletStats(bulletStats.position);

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

        if (updateFrame)
        {
            level.AddBulletToCurrentFrame(bulletStats);
        }
    }

    public void ToggleSelectOverlay(bool toggle)
    {
        selectOverlay.SetActive(toggle);
    }
}
