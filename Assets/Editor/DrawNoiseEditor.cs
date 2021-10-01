using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DrawNoiseMap))]
public class DrawNoiseEditor : Editor
{
    DrawNoiseMap draw;
    private void OnEnable()
    {
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawNoiseMap draw = (DrawNoiseMap)target;

        if(GUILayout.Button("Generate Noise"))
        {
            draw.DrawNoise();
        }
    }
}
