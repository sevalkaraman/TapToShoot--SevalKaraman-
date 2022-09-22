using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed = 2f;
    
    public abstract void Damage();
    public void MoveToTarget(Vector3 targetPos)
    {
        transform.DOMoveZ(targetPos.z, 1f / speed );
    }

    private void OnTriggerEnter(Collider other)
    {
        var iShootable = other.GetComponent<IShootable>();
        if (iShootable != null)
        {
            Damage();
            DespawnProjectile();
        }
    }

    private void DespawnProjectile()
    {
        PoolManager.Instance.Despawn(Pools.Types.Projectile , gameObject);
    }
}
