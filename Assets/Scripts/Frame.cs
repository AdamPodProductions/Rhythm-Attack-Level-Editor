using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Frame
{
    public List<BulletStats> bullets = new List<BulletStats>();
    [System.NonSerialized] public List<Node> nodes = new List<Node>();

    public Frame()
    {

    }
}
