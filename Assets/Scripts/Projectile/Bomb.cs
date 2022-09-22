
public class Bomb : Projectile
{
    public override void Damage(IShootable shootable)
    {
        shootable.GetDamage();
    }
}
