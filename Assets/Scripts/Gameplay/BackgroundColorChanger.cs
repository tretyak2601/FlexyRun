using Imphenzia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField] GradientSkyCamera skyCamera;

    void Start()
    {
        GradientColorKey[] gck = new GradientColorKey[2];
        GradientAlphaKey[] gcka = new GradientAlphaKey[2];

        gck[0] = new GradientColorKey(GetRandomColor(), 0);
        gck[1] = new GradientColorKey(GetRandomColor(), 1);
        gcka[0] = new GradientAlphaKey(1, 0);
        gcka[0] = new GradientAlphaKey(1, 1);
        
        skyCamera.gradient.SetKeys(gck, gcka); 
    }

    Color GetRandomColor()
    {
        return new Color((1f / 255) * Random.Range(0, 256), (1f / 255) * Random.Range(0, 256), (1f / 255) * Random.Range(0, 256), 1);
    }

    public void Restart()
    {
        Start();
    }
}
