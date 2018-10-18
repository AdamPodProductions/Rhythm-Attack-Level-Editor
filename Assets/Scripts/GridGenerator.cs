using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject nodePrefab;

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

        int xHalf = Mathf.FloorToInt(size.x / 2f);
        int yHalf = Mathf.FloorToInt(size.y / 2f);

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Transform generatedNode = Instantiate(nodePrefab, new Vector2(x - xHalf, y - yHalf), Quaternion.identity).transform;
                generatedNode.parent = transform;
            }
        }

        Camera.main.orthographicSize = 0.635f * ((size.x > size.y) ? size.x : size.y);
    }
}
