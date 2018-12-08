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

        this.bullets = new List<BulletStats>();
        this.nodes = new List<Node>();

        foreach (BulletStats bullet in bullets)
        {
            this.bullets.Add(bullet);
        }

        foreach (Node node in nodes)
        {
            this.nodes.Add(node);
        }
    }

    public Frame(Frame frame)
    {
        bullets = frame.bullets;
        nodes = frame.nodes;

        bullets = new List<BulletStats>();
        nodes = new List<Node>();

        foreach (BulletStats bullet in frame.bullets)
        {
            bullets.Add(bullet);
        }

        foreach (Node node in frame.nodes)
        {
            nodes.Add(node);
        }
    }
}
