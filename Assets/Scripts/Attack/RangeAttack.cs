using UnityEngine;

public class RangeAttack : IAttack
{
    private Transform spawn;

    public RangeAttack(Transform spawn)
    {
        this.spawn = spawn;
    }

    public void ExcuteAttack()
    {
        Projectile projectile = PlayerManager.Instance.GetProjectile(Projectile.ProjectileType.Shuriken);

        if (projectile == null) return;
        /*
        Quaternion rot = Quaternion.Euler(0, 0, Random.Range(23, 60));
        if (projectile.Type == Projectile.ProjectileType.Shuriken)
        {
            rot = Quaternion.Euler(0, 0, Random.Range(23, 60));
        }*/
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        GameApplication.Instance.EntityController.Spawn<Projectile, ProjectileObject>(projectile, spawn.position, rot);
    }
}
