using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public BulletStats bulletStats;

    public GameObject selectOverlay;
    public GameObject directionArrow;
    public GameObject[] bulletOverlays;

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

        if (bulletStats.bulletType == "None" && bulletStats.direction == Vector2.zero)
        {
            directionArrow.SetActive(false);
        }
        else
        {
            directionArrow.SetActive(true);

            /*
            Vector3 dir = new Vector3(bulletStats.direction.x, bulletStats.direction.y, 0) + transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            directionArrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            */

            int angle = (bulletStats.direction.DirectionToDropdownIndex() - 1) * -45;
            directionArrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void ToggleSelectOverlay(bool toggle)
    {
        selectOverlay.SetActive(toggle);
    }
}
