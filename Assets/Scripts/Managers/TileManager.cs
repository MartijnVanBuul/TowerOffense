using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public static TileManager instance;

    public int InitialWidth = 11;
    public int InitialDepth = 11;

    public Vector3 InitialPosition;

    public List<GameObject> TilePrefabs;


    private void Awake()
    {
        instance = this;
    }

    void Start () {
        InitializeGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitializeGrid()
    {
        for(int i = -InitialWidth / 2; i <= InitialWidth / 2; i++)
        {
            for (int j = -InitialDepth / 2; j <= InitialDepth / 2; j++)
            {
                GameObject tile = Instantiate(TilePrefabs[0], new Vector3(i, 0, j), Quaternion.identity);
                tile.transform.SetParent(transform);
            }
        }
    }
}
