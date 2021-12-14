using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MazeGenerator))]
public class MazeGeneratorEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        MazeGenerator generator = (MazeGenerator)target;
        base.OnInspectorGUI();
        //Generate Maze Button
        if(GUILayout.Button("Generate Maze"))
        {
            generator.GenerateMazeMap();
        }
        if(GUILayout.Button("Delete Maze"))
        {
            generator.DeleteMazeMap();
        }
        
    }
}
