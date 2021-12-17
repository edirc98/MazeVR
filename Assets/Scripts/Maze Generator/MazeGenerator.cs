using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; 

public class MazeGenerator : MonoBehaviour
{
    [Header("Texture Map Design")]
    public Texture2D Map;
    public List<Color> ColorCodes;

    [Header("Maze Prefabs")]
    public List<GameObject> WallPrefabs;

    private GameObject _groundInstance; 
    #region FUNCTIONS
    public void GenerateMazeMap()
    {
        createMazeGround();
        for (int i = 0; i < Map.width; i++)
        {
            for (int j = 0; j < Map.height; j++)
            {
                Color currentPixelColor = Map.GetPixel(i, j);
                if (currentPixelColor == ColorCodes[0])
                {
                    Instantiate(WallPrefabs[0], new Vector3(i, 0, j),WallPrefabs[0].transform.rotation,transform);
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

    private void createMazeGround()
    {
        _groundInstance = Instantiate(WallPrefabs[1], new Vector3(((Map.width - 1.0f) / 2.0f), -1.0f, ((Map.height - 1.0f) / 2.0f)), Quaternion.identity, transform);
        _groundInstance.transform.localScale = new Vector3(Map.width, 0.1f, Map.height);
        _groundInstance.GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2(Map.width, Map.height);
        _groundInstance.AddComponent<TeleportationArea>();
    }
    #endregion

}
