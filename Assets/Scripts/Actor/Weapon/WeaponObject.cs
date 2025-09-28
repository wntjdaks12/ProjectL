using UnityEngine;

public class WeaponObject : ActorObject
{
    [SerializeField] private StatAbility statAbility;
    public StatAbility StatAbility => statAbility;

    protected IAttack currentAttack;
    private float lastAttackTime;

    public override void Init(Entity entity)
    {
        base.Init(entity);

        Stat stat = GameApplication.Instance.GameModel.PresetData.ReturnData<Stat>(nameof(Stat), Entity.Id);
        statAbility?.AddStatData(StatAbility.StatInfo.StatDataType.Main, stat);
    }

    public void TryAttack(ICaster caster)
    {
        if (Time.time < lastAttackTime + statAbility.AttackSpeed) return;

        currentAttack.ExcuteAttack(caster);
        lastAttackTime = Time.time;
    }
}
