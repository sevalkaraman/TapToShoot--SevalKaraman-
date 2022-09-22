using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    
    private Camera _mainCam;
    private IShootable _currentTarget;
    private Vector3 _shootPosition;
    
    private void Start()
    {
        _mainCam = Camera.main;
    }
    private void Update()
    {
        CheckShootable();
        
        if (_currentTarget == null) return;
        
        Shoot(_currentTarget);

    }
    
    private Ray SendRay()
    {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        return ray;
    }

    private void CheckShootable()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(SendRay(), out hit, 1000f))
            {
                var shootable = hit.transform.GetComponent<IShootable>();
                if (shootable != null)
                {
                    _currentTarget = shootable;
                    _shootPosition = hit.point;
                }
                
            }
            else _currentTarget = null;
        }
    }

    private void Shoot(IShootable target)
    {
        var newProjectile = Instantiate(projectile, _shootPosition - new Vector3(0f, 0f, 20f), Quaternion.identity);
        newProjectile.transform.DOMoveZ(_shootPosition.z, 0.5f);
        _currentTarget = null;
    }
}