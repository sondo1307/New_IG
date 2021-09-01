using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerate : MonoBehaviour
{
    [SerializeField] private Texture2D map;
    [SerializeField] private MapColor[] mapColor;
    public float x = 0.5f;
    public float y = 0.5f;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for (int i = 0; i < map.height; i++)
        {
            for (int j = 0; j < map.width; j++)
            {
                Color a = map.GetPixel(j, i);
                foreach (MapColor item in mapColor)
                {
                    if (item.color == a)
                    {
                        Instantiate(item.prefab, new Vector3(x, y, 0), Quaternion.identity, transform);
                    }
                }
                x += 1f;
            }
            x = 0.5f;
            y += 1f;
        }
    }
}
