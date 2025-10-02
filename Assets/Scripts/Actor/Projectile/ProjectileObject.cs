using UnityEngine;

public class ProjectileObject : ActorObject, IStatAbility
{
    [SerializeField] private ProjectileSet projectileSet;

    public StatAbility StatAbility { get; set; } 

    public ICaster Caster { get; set; }
    
    private IHeath cacheHeath;
    private IStatAbility cacheStatAbility;

    public override void Init(Entity entity)
    {
        base.Init(entity);

        StatAbility = new StatAbility();
        Stat stat = GameApplication.Instance.GameModel.PresetData.ReturnData<Stat>(nameof(Stat), Entity.Id);
        StatAbility.AddStatData(StatAbility.StatInfo.StatDataType.Main, stat);
    }

    public void Move()
    {
        transform.Translate(transform.forward * StatAbility.MaxSpeed * Time.deltaTime, Space.World);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform == Caster.Caster) return;

        if (cacheHeath == null)
        {
            if (other.transform.TryGetComponent(out IHeath health))
            {
                cacheHeath = health;
            }
        }

        if (cacheStatAbility == null)
        {
            if (Caster is IStatAbility statAbility)
            {
                cacheStatAbility = statAbility;
            }
        }

        if (cacheHeath != null && cacheStatAbility != null)
        {
            cacheHeath.Hit(cacheStatAbility.StatAbility.AttackPower);

            if (projectileSet != null)
            {
                GameApplication.Instance.EntityController.Spawn<VFX,VFXObject>(projectileSet.HitVFXPath, other.transform.position, Quaternion.identity);
            }

            OnRemoveEntity();
        }
    }
}
