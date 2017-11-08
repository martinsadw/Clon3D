using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour
{
	public static MapManager instance = null;

	public class Block
	{
		public int id;
		public Vector3 pos;

		public Block(int id, Vector3 pos)
		{
			this.id = id;
			this.pos = pos;
		}
	}

	public GameObject[] block0;

	private List<Block> map = new List<Block>();
	private Transform mapHolder;

	void InitializeList()
	{
		for (int j = -6; j < 6; ++j)
		{
			for (int i = -6; i < 6; ++i)
			{
				map.Add(new Block(0, new Vector3(i, 0, j)));
			}
		}

		map.Add(new Block(0, new Vector3(-2, 1, 0)));
		map.Add(new Block(0, new Vector3(-3, 1, 1)));
		map.Add(new Block(0, new Vector3(-3, 2, 1)));
		map.Add(new Block(0, new Vector3(-3, 1, 2)));
		map.Add(new Block(0, new Vector3(-3, 1, 3)));
		map.Add(new Block(0, new Vector3(-3, 1, 4)));

		map.Add(new Block(0, new Vector3(1, 1, 0)));
		map.Add(new Block(0, new Vector3(1, 1, 1)));
		map.Add(new Block(0, new Vector3(1, 1, 2)));
		map.Add(new Block(0, new Vector3(1, 1, 3)));
		map.Add(new Block(0, new Vector3(0, 1, 3)));
		map.Add(new Block(0, new Vector3(0, 1, 4)));
	}

	void MapSetup()
	{
		mapHolder = new GameObject("Map").transform;

		for (int j = 0; j < map.Count; ++j)
		{
			GameObject toInstantiate;
			switch (map[j].id)
			{
				case 0:
					toInstantiate = block0[Random.Range(0, block0.Length)];
					break;
				default:
					toInstantiate = block0[Random.Range(0, block0.Length)];
					break;
			}

			GameObject instance = Instantiate(toInstantiate, map[j].pos, Quaternion.identity) as GameObject;

			instance.gameObject.tag = "Wall";
			instance.transform.SetParent(mapHolder);
		}
	}

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		InitializeList();
		MapSetup();
	}

	void Update()
	{

	}
}
