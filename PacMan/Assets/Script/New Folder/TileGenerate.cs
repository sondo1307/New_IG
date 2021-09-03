using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerate : MonoBehaviour
{
    [SerializeField] private Texture2D map;
    [SerializeField] private Texture2D map2;
    [SerializeField] private MapColor[] mapColor;
    [SerializeField] private MapSead[] mapSeads;
    public float x1 = 0.5f;
    public float y1 = 0.5f;    
    public float x2 = 0.5f;
    public float y2 = 0.5f;

    public Transform blockParent;
    private void Start()
    {
        Generate();
        GenerateSead();
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
                        if (item.prefab.name == "Block"|| item.prefab.name == "BlockInvis")
                        {
                            Instantiate(item.prefab, new Vector3(x1, y1, 0), Quaternion.identity, blockParent);
                        }
                        else
                        {
                            Instantiate(item.prefab, new Vector3(x1, y1, 0), Quaternion.identity, transform);
                        }
                    }
                }
                x1 += 1f;
            }
            x1 = 0.5f;
            y1 += 1f;
        }
    }

    public void GenerateSead()
    {
        for (int i = 0; i < map2.height; i++)
        {
            for (int j = 0; j < map2.width; j++)
            {
                Color a = map2.GetPixel(j, i);
                foreach (MapSead item in mapSeads)
                {
                    if (item.color == a)
                    {
                        Instantiate(item.prefab, new Vector3(x2, y2, 0), Quaternion.identity, transform);
                    }
                }
                x2 += 1f;
            }
            x2 = 0.5f;
            y2 += 1f;
        }
    }
}
