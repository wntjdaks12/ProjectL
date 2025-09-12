public class ClawObject : WeaponObject
{
    public override void Init(Entity entity)
    {
        base.Init(entity);

        Projectile projectile = PlayerManager.Instance.GetProjectile(Projectile.ProjectileType.Shuriken);

        currentAttack = new RangeAttack(projectile, transform);
    }
}
