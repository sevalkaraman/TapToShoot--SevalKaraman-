using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour , IShootable
{
    private MeshRenderer _renderer;

    private void Start()
    {
        _renderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        GetRandomColor();
    }

    public Cube()
    {
      
    }
    
    public void GetDamage()
    {
        print(_renderer == null);
        GetRandomColor();
    }

    public void GetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
