
using UnityEngine;

public class Bullet : Projectile
{

    public override void Damage(IShootable shootable)
    {
        shootable.GetDamage();
        AddForce(shootable as Cube);
    }

    public override void AddForce(Cube cube)
    {
        if(!cube) return;
        cube.rb.AddForce(Vector3.forward , ForceMode.Impulse);
    }
}
