
using UnityEngine;

public class Bomb : Projectile
{
    public override void Damage(IShootable shootable)
    {
        shootable.GetDamage();
        AddForce(shootable as Cube);
    }

    public override void AddForce(Cube cube)
    {
        if(!cube) return;
        cube.rb.AddExplosionForce(20f, transform.position, 5f);
    }
}
