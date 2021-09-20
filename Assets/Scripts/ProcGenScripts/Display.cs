using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public ColorGen colorGen = new ColorGen();
    public void Awake()
    {
        meshFilter.gameObject.AddComponent<MeshCollider>();

    }


    public void DrawMesh(MeshData meshData, MinMaxTracker heightTracker, ColorSettings colorSettings)
    {
        colorGen.UpdateSettings(colorSettings);
        colorGen.UpdateHeight(heightTracker);
        colorGen.UpdateColors();

        meshFilter.sharedMesh = meshData.CreateMesh();
        meshFilter.GetComponent<MeshRenderer>().sharedMaterial = colorSettings.terrainMaterial;
    }
}
