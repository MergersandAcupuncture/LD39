/*
* Copyright (c) Mergers and Acupuncture
*/
using UnityEngine;

[System.Serializable]
public class ColorToPrefab 
{
	public Color32 color;
	public GameObject prefab;
}

public class LevelGenerator : MonoBehaviour
{
	public Texture2D map;

	public ColorToPrefab[] tiles;

	void Start ()
	{
		GenerateMap();
	}

	void ClearMap ()
	{
		while (transform.childCount > 0)
		{
			Transform c = transform.GetChild(0);
			c.SetParent(null);
			Destroy(c.gameObject);
		}
	}

	void GenerateMap ()
	{
		ClearMap();

		Color32[] allPixels = map.GetPixels32();
		int width = map.width;
		int height = map.height;

		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				GenerateTile ( allPixels[(y * width) + x], x, y);
			}
		}
	}

	void GenerateTile (Color32 c, int x, int y)
	{
		if (c.a <= 0)
		{
			// Transparent pixel, don't instantiate anything.
			return;
		}

		foreach(ColorToPrefab tile in tiles)
		{
			if (c.Equals(tile.color))
			{
				Vector2 position = new Vector2(x, y);
				Instantiate(tile.prefab, position, Quaternion.identity, transform);
				return;
			}
		}
	}
}
