using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Texture Map Design")]
    public Texture2D Map;
    public Color WallColor;
    public Color PathColor; 

    [Header("Maze Prefabs")]
    public GameObject Wall;
    public GameObject Path; 
    // Start is called before the first frame update
    void Start()
    {
        //GenerateMazeMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region FUNCTIONS
    public void GenerateMazeMap()
    {
        for (int i = 0; i < Map.width; i++)
        {
            for (int j = 0; j < Map.height; j++)
            {
                if (Map.GetPixel(i, j) == WallColor)
                {

                    Instantiate(Wall, new Vector3(i, 1, j), Quaternion.identity, transform);
                }
                else if (Map.GetPixel(i, j) == PathColor)
                {
                    Instantiate(Path, new Vector3(i, 0, j), Quaternion.identity, transform);
                }
            }
        }
    }

    public void DeleteMazeMap()
    {
        int numChildren = transform.childCount;
        if (numChildren > 0)
        {
            List<GameObject> children = new List<GameObject>();
            foreach (Transform child in transform) children.Add(child.gameObject);
            children.ForEach(child => DestroyImmediate(child));
            Debug.Log("Deleted " + numChildren + " objects.");
        }
        else Debug.Log("No objects to delete.");
        
    }
    #endregion

}
