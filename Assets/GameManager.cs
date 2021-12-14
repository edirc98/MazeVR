using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Rig")]
    public GameObject PlayerOrigin;
    public Transform StartPoint; 
    // Start is called before the first frame update
    void Start()
    {
        PlayerOrigin.transform.position = StartPoint.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
