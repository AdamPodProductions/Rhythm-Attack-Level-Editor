using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject nodePrefab;

    private int xHalf;
    private int yHalf;

    private List<Node> batteryNodes = new List<Node>();

    public Node[] GenerateGrid(Vector2 size)
    {
        List<Node> nodes = new List<Node>();

        if (size.x % 2 == 0)
        {
            size.x++;
        }

        if (size.y % 2 == 0)
        {
            size.y++;
        }

        xHalf = Mathf.FloorToInt(size.x / 2f);
        yHalf = Mathf.FloorToInt(size.y / 2f);

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Transform generatedNode = Instantiate(nodePrefab, GetPositionFromGrid(new Vector2(x, y)), Quaternion.identity).transform;
                generatedNode.parent = transform;
                generatedNode.GetComponent<Node>().bulletStats = BulletStats.BlankBulletStats(new Vector2(x, y));
                nodes.Add(generatedNode.GetComponent<Node>());

                if (x >= xHalf - 1 && x <= xHalf + 1 && y >= yHalf - 1 && y <= yHalf + 1 && size.x > 3 && size.y > 3)
                {
                    generatedNode.GetComponent<SpriteRenderer>().color = Color.black;
                    generatedNode.GetComponent<Node>().editable = false;
                }

                if ((x == 2 && y == 2) || (x == 10 && y == 2) || (x == 2 && y == 10) || (x == 10 && y == 10))
                {
                    batteryNodes.Add(generatedNode.GetComponent<Node>());
                }
            }
        }

        Camera.main.orthographicSize = 0.635f * ((size.x > size.y) ? size.x : size.y);
        Camera.main.transform.position = new Vector3(0.1f * size.x + 2f, 0, -10f);

        return nodes.ToArray();
    }

    public void AddBatteries()
    {
        if (batteryNodes.Count > 0)
        {
            foreach (Node batteryNode in batteryNodes)
            {
                batteryNode.ApplyProperties(new BulletStats("RedBattery", batteryNode.bulletStats.position, Vector2.zero));
            }
        }
    }

    public Vector2 GetPositionFromGrid(Vector2 positionOnGrid)
    {
        return positionOnGrid - new Vector2(xHalf, yHalf);
    }
}
