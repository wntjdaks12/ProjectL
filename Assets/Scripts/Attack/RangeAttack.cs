using UnityEngine;

public class RangeAttack : IAttack
{
    private Transform spawn;

    public RangeAttack(Transform spawn)
    {
        this.spawn = spawn;
    }

    public void ExcuteAttack(ICaster caster)
    {
        Projectile projectile = PlayerManager.Instance.GetProjectile(Projectile.ProjectileType.Shuriken);

        if (projectile == null) return;

        GameApplication.Instance.EntityController.Spawn<Projectile, ProjectileObject>(projectile, spawn.position, caster.Caster.rotation);
    }
}
