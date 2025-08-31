using UnityEngine;

public class CharacterObject : ActorObject
{
    [SerializeField] private StatAbility statAbility;

    public override void Init(Entity entity)
    {
        base.Init(entity);

        Stat stat = GameApplication.Instance.GameModel.PresetData.ReturnData<Stat>(nameof(Stat), Entity.Id);
        statAbility?.AddStatData(StatAbility.StatInfo.StatDataType.Main, stat);

        Debug.Log(stat.AttackDamage);
    }
}
