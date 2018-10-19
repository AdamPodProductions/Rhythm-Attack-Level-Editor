using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public BulletStats bulletStats;

    public GameObject selectOverlay;

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
    }

    public void ToggleSelectOverlay(bool toggle)
    {
        selectOverlay.SetActive(toggle);
    }
}
