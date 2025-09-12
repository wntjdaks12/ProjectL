using UnityEngine;

public class CharacterObject : ActorObject
{
    [SerializeField] private StatAbility statAbility;

    private WeaponObject weaponObject;

    [field: SerializeField] public Transform WeaponNode { get; private set; }

    public override void Init(Entity entity)
    {
        base.Init(entity);

        Stat stat = GameApplication.Instance.GameModel.PresetData.ReturnData<Stat>(nameof(Stat), Entity.Id);
        statAbility?.AddStatData(StatAbility.StatInfo.StatDataType.Main, stat);
    }

    public void SetWeapon(WeaponObject weaponObject)
    {
        this.weaponObject = weaponObject;
    }

    public void TryAttack()
    {
        weaponObject?.TryAttack();
    }
}
