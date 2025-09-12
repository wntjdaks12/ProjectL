using UnityEngine;

public class RangeAttack : IAttack
{
    private Projectile projectile;
    private Transform spawn;

    public RangeAttack(Projectile projectile, Transform spawn)
    {
        this.projectile = projectile;
        this.spawn = spawn;
    }

    public void ExcuteAttack()
    {
        if (projectile == null) return;

        Quaternion rot = Quaternion.Euler(0, 0, Random.Range(23, 60));
        if (projectile.Type == Projectile.ProjectileType.Shuriken)
        {
            rot = Quaternion.Euler(0, 0, Random.Range(23, 60));
        }

        GameApplication.Instance.EntityController.Spawn<Projectile, ProjectileObject>(projectile, spawn.position, rot);
    }
}
