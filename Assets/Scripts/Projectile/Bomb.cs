using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Projectile
{
    public override void Damage(IShootable shootable)
    {
        shootable.GetDamage();
    }
}
