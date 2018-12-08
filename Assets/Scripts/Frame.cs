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

    public Frame(List<BulletStats> bullets, List<Node> nodes)
    {
        this.bullets = bullets;
        this.nodes = nodes;
    }

    public Frame(Frame frame)
    {
        bullets = frame.bullets;
        nodes = frame.nodes;
    }
}
