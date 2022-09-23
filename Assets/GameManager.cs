using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WallCreator _wallCreator;
    [SerializeField] private CanvasPanels _canvasPanels;
    [SerializeField] private List<Cube> _cubes = new List<Cube>();
    
    private void OnDisable()
    {
        GlobalEvents.Instance.onProjectileHit -= CheckCubes;
    }

    private void Start()
    {
        foreach (GameObject cube in _wallCreator._cubes)
        {
            var shootableCube = cube.GetComponent<Cube>();
            if(shootableCube) _cubes.Add(shootableCube);
        }
        
        GlobalEvents.Instance.onProjectileHit += CheckCubes;
    }

    private void CheckCubes()
    {
        foreach (Cube cube in _cubes)
        {
            if(!cube.IsShooted) return;
        } 
        _canvasPanels.ShowLevelCompletedPanel();
    }
}
