using UnityEngine;

public class Character : Actor
{
    public StatData StatData { get; set; }
    public StatAbility StatAbility { get; set; }

    public override void Init(Transform transform = null)
    {
        base.Init(transform);
        // ���� ���� �߰� ----------------------------------------------------------------------------------------
        StatAbility = new StatAbility();


        // ���� ���� �߰�
        StatAbility.AddStatData(StatAbility.StatInfo.StatDataType.Main, StatData);

        StatAbility.CurrentSpeed = StatAbility.MaxSpeed;
        StatAbility.CurrentHp = StatAbility.MaxHp;
        StatAbility.CurrentMp = StatAbility.MaxMp;
        StatAbility.CurrentStamina = StatAbility.MaxStamina;
        StatAbility.CurrentBasicAttackRange = StatAbility.BasicAttackRange;
        // --------------------------------------------------------------------------------------------------------
    }
}
