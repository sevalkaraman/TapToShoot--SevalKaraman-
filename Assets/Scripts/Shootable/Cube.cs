using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour , IShootable
{
    private MeshRenderer _renderer;
    public Rigidbody rb;

    private bool _isShooted = false;
    public bool IsShooted { get => _isShooted; }

    private void OnDisable()
    {
        GlobalEvents.Instance.onProjectileHit -= GetRandomColor;
    }

    private void Start()
    {
        _renderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        GlobalEvents.Instance.onProjectileHit += GetRandomColor;
        GetRandomColor();
    }
    
    
    public void GetDamage()
    {
        _isShooted = true;
    }

    public void GetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
