using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletStats
{
    public string type = "None";
    public Vector2 position = Vector2.zero;
    public Vector2 direction = Vector2.zero;
    public float specialtyNumber = 0;

    public BulletStats()
    {

    }

    public BulletStats(string type, Vector2 position, Vector2 direction)
    {
        this.type = type;
        this.position = position;
        this.direction = direction;
    }

    public BulletStats(string type, Vector2 position, Vector2 direction, float specialtyNumber)
    {
        this.type = type;
        this.position = position;
        this.direction = direction;
        this.specialtyNumber = specialtyNumber;
    }

    public static BulletStats BlankBulletStats(Vector2 position)
    {
        return new BulletStats("None", position, Vector2.zero);
    }
}
