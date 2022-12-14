using DG.Tweening;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed = 2f;
    public Pools.Types type;
    
    public abstract void Damage(IShootable shootable);
    public abstract void AddForce(Cube shootable);
    public void MoveToTarget(Vector3 targetPos)
    {
        transform.DOMoveZ(targetPos.z + 5f, 1f / speed );
    }

    private void OnTriggerEnter(Collider other)
    {
        var iShootable = other.GetComponent<IShootable>();
        if (iShootable != null)
        {
            Damage(iShootable);
            DespawnProjectile();
            GlobalEvents.Instance.OnProjectileHit();
        }
    }

    private void DespawnProjectile()
    {
        PoolManager.Instance.Despawn(type, gameObject);
    }
}
