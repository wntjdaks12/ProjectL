using UnityEngine;

public class ProjectileObject : ActorObject, ICaster
{
    [SerializeField] private StatAbility statAbility;

    public Transform Caster { get; set; }

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

        if (other.transform.TryGetComponent(out IHeath target))
        {
            target.Hit(10);
        }
    }
}
