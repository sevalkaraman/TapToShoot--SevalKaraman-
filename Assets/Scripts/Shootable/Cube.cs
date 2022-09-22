using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour , IShootable
{
    private MeshRenderer _renderer;

    private void OnDisable()
    {
        GlobalEvents.Instance.onProjectileHit -= GetRandomColor;
    }

    private void Start()
    {
        _renderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        GlobalEvents.Instance.onProjectileHit += GetRandomColor;
        GetRandomColor();
    }
    
    
    public void GetDamage()
    {
    }

    public void GetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
