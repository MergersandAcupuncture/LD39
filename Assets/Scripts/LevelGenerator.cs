/*
* Copyright (c) Mergers and Acupuncture
*/
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public Texture2D map;
	public ColorToPrefab[] tiles;

	void Start ()
    {
		GenerateMap();	
	}

    void GenerateMap()
	{
        Color[] pixels = map.GetPixels();
        int width = map.width;
        int height = map.height;

        for(int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				GenerateTile(pixels[(y * width) + x], x, y);
			}
		}
	}

	void GenerateTile(Color c, int x, int y)
	{

		if (c.a == 0)
		{
			// Transparent pixel, don't instantiate anything.
			return;
		}

		foreach (ColorToPrefab tile in tiles)
		{
			if (tile.color.Equals(c))
			{
				Vector2 position = new Vector2(x, y);
				Instantiate(tile.prefab, position, Quaternion.identity, transform);
			}
		}
	}
}
