using UnityEngine;

public class WeaponObject : ActorObject
{
    protected IAttack currentAttack;
    private float lastAttackTime;

    public void TryAttack(ICaster caster, float attackSpeed)
    {
        if (Time.time < lastAttackTime + attackSpeed) return;

        currentAttack.ExcuteAttack(caster);
        lastAttackTime = Time.time;
    }
}
