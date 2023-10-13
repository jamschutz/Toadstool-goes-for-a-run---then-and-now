using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapToadMaterials : MonoBehaviour
{
    public Material opaqueMat;
    public Material transparentMat;


    public Renderer[] toadRenderers;


    private void Start()
    {
        foreach(var toad in toadRenderers) {
            toad.material = opaqueMat;
        }
    }


    public void SwapMaterials()
    {
        foreach(var toad in toadRenderers) {
            toad.material = transparentMat;
        }
    }
}
