using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Camera _mainCam;
    private IShootable _currentTarget;
    private Vector3 _shootPosition;
    private Pools.Types _projectileType;
    
    private void Start()
    {
        _mainCam = Camera.main;
    }
    private void Update()
    {
        CheckShootable();
        
        if (_currentTarget == null) return;
        
        Shoot();

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

    private void Shoot()
    {
       
        var randomNumber = Random.Range(0, 2);
        _projectileType = randomNumber == 1 ? Pools.Types.Bullet : Pools.Types.Bomb;
        
        var newProjectile =
            PoolManager.Instance.Spawn(_projectileType, _shootPosition - new Vector3(0f, 0f, 20f), Quaternion.identity).GetComponent<Projectile>();
        newProjectile.MoveToTarget(_shootPosition);
        _currentTarget = null;
    }
}
