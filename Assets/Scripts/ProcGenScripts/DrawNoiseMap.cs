using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawNoiseMap : MonoBehaviour
{
    public Renderer textureRen;
    FastNoiseLite noiseGen;
    public VegitationNoise settings;

    float scale;
    
    void SetupNoise()
    {
        noiseGen = new FastNoiseLite();
        scale = settings.scale;
        noiseGen.SetFractalLacunarity(settings.lacunarity);
        noiseGen.SetFractalOctaves(settings.octives);
        noiseGen.SetFractalType(settings.fractalType);
        noiseGen.SetNoiseType(settings.noiseType);   
    }
    float[,] CreateNoiseMap()
    {
        float [,] noise = new float[256,256];
        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < 256; y++)
            {
                noise[x,y] = (noiseGen.GetNoise((float)x/scale,(float)y/scale) + 1) *0.5f;
            }   
        }
        return noise;
    }
    void CreateTextureFromNoise(float[,] noise)
    {
        int width = noise.GetLength(0);
        int height = noise.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        Color[] color = new Color[width * height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                color[y * width + x] = Color.Lerp(Color.black, Color.white, noise[x, y]);
            }
        }
        texture.SetPixels(color);
        texture.Apply();

        textureRen.sharedMaterial.mainTexture = texture;
        textureRen.transform.localScale = new Vector3(width, 1, height);
    }

    public void DrawNoise()
    {
        SetupNoise();
        CreateTextureFromNoise(CreateNoiseMap());
    }
}
[System.Serializable]
public struct VegitationNoise
{
    public int seed;
    public float scale;
    public float lacunarity;
    public int octives;
    public FastNoiseLite.NoiseType noiseType;
    public FastNoiseLite.FractalType fractalType;

}
