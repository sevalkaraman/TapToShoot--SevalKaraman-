
public class Bullet : Projectile
{

    public override void Damage(IShootable shootable)
    {
        shootable.GetDamage();
    }
}
