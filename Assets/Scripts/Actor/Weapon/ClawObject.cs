public class ClawObject : WeaponObject
{
    public override void Init(Entity entity)
    {
        base.Init(entity);

        
        currentAttack = new RangeAttack(transform);
    }
}
