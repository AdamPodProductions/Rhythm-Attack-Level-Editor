using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject nodePrefab;

    private int xHalf;
    private int yHalf;

    public void GenerateGrid(Vector2 size)
    {
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

                if (x >= xHalf - 1 && x <= xHalf + 1 && y >= yHalf - 1 && y <= yHalf + 1 && size.x > 3 && size.y > 3)
                {
                    generatedNode.GetComponent<SpriteRenderer>().color = Color.black;
                }
            }
        }

        Camera.main.orthographicSize = 0.635f * ((size.x > size.y) ? size.x : size.y);
        Camera.main.transform.position = new Vector3(0.1f * size.x + 2f, 0, -10f);
    }

    public Vector2 GetPositionFromGrid(Vector2 positionOnGrid)
    {
        return positionOnGrid - new Vector2(xHalf, yHalf);
    }
}
