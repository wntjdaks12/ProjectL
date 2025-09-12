using UnityEngine;

public class ProjectileObject : ActorObject
{
    [SerializeField] private StatAbility statAbility;

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
}
