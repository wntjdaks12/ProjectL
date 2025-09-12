using UnityEngine;

public class WeaponObject : ActorObject
{
    [SerializeField] private StatAbility statAbility;

    protected IAttack currentAttack;
    private float lastAttackTime;

    public override void Init(Entity entity)
    {
        base.Init(entity);

        Stat stat = GameApplication.Instance.GameModel.PresetData.ReturnData<Stat>(nameof(Stat), Entity.Id);
        statAbility?.AddStatData(StatAbility.StatInfo.StatDataType.Main, stat);
    }

    public void TryAttack()
    {
        if (Time.time < lastAttackTime + statAbility.AttackSpeed) return;

        currentAttack.ExcuteAttack();
        lastAttackTime = Time.time;
    }
}
