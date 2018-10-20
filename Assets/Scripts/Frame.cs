﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Frame
{
    public List<BulletStats> bullets = new List<BulletStats>();
    public List<Node> nodes = new List<Node>();

    public Frame()
    {

    }
}
