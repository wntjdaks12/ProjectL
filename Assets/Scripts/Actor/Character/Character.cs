using UnityEngine;

public class Character : Actor
{
    public StatData StatData { get; set; }
    public StatAbility StatAbility { get; set; }

    public override void Init(Transform transform = null)
    {
        base.Init(transform);
        // 스탯 관련 추가 ----------------------------------------------------------------------------------------
        StatAbility = new StatAbility();


        // 메인 스탯 추가
        StatAbility.AddStatData(StatAbility.StatInfo.StatDataType.Main, StatData);

        StatAbility.CurrentSpeed = StatAbility.MaxSpeed;
        StatAbility.CurrentHp = StatAbility.MaxHp;
        StatAbility.CurrentMp = StatAbility.MaxMp;
        StatAbility.CurrentStamina = StatAbility.MaxStamina;
        StatAbility.CurrentBasicAttackRange = StatAbility.BasicAttackRange;
        // --------------------------------------------------------------------------------------------------------
    }
}
