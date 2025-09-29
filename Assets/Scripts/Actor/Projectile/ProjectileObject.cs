using UnityEngine;

public class ProjectileObject : ActorObject, ICaster
{
    [SerializeField] private StatAbility statAbility;

    public Transform Caster { get; set; }

    private IHeath cacheHeath;
    private StatAbility cacheStatAbility;

    public override void Init(Entity entity)
    {
        base.Init(entity);

        Stat stat = GameApplication.Instance.GameModel.PresetData.ReturnData<Stat>(nameof(Stat), Entity.Id);
        statAbility?.AddStatData(StatAbility.StatInfo.StatDataType.Main, stat);
    }

    public void Move()
    {
        transform.Translate(transform.forward * statAbility.MaxSpeed * Time.deltaTime, Space.World);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform == Caster) return;

        if (cacheHeath == null)
        {
            if (other.transform.TryGetComponent(out IHeath health))
            {
                cacheHeath = health;
            }
        }

        if (cacheStatAbility == null)
        {
            if (Caster.TryGetComponent(out StatAbility statAbility))
            {
                cacheStatAbility = statAbility;
            }
        }

        if (cacheHeath != null && cacheStatAbility != null)
        {
            cacheHeath.Hit(cacheStatAbility.AttackPower);
        }
    }
}
