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
		for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GenerateTile(x, y);
			}
		}
	}

	void GenerateTile(int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0)
		{
			// Transparent pixel, don't instantiate anything.
			return;
		}

		foreach (ColorToPrefab tile in tiles)
		{
			if (tile.color.Equals(pixelColor))
			{
				Vector2 position = new Vector2(x, y);
				Instantiate(tile.prefab, position, Quaternion.identity, transform);
			}
		}
	}
}
