using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletStats
{
    public string bulletType = "None";
    public Vector2 position = Vector2.zero;
    public Vector2 direction = Vector2.zero;

    public BulletStats()
    {

    }

    public BulletStats(string bulletType, Vector2 position, Vector2 direction)
    {
        this.bulletType = bulletType;
        this.position = position;
        this.direction = direction;
    }

    public BulletStats(string bulletType, Vector2 direction)
    {
        this.bulletType = bulletType;
        this.direction = direction;
    }
}
