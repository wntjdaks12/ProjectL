using UnityEngine;

public class CharacterObject : ActorObject, ICaster, IHeath
{
    [SerializeField] private StatAbility statAbility;
    public StatAbility StatAbility => statAbility;

    private WeaponObject weaponObject;

    [field: SerializeField] public Transform WeaponNode { get; private set; }
    public Transform Caster { get; set; }

    private Character character;

    public override void Init(Entity entity)
    {
        base.Init(entity);

        character = Entity as Character;

        Stat stat = GameApplication.Instance.GameModel.PresetData.ReturnData<Stat>(nameof(Stat), Entity.Id);
        statAbility?.AddStatData(StatAbility.StatInfo.StatDataType.Main, stat);

        StatAbility.CurrentSpeed = statAbility.MaxSpeed;
        StatAbility.CurrentHp = statAbility.MaxHp;

        Caster = transform;
    }

    public void SetWeapon(WeaponObject weaponObject)
    {
        this.weaponObject = weaponObject;

        statAbility?.AddStatData(StatAbility.StatInfo.StatDataType.Sub, weaponObject.StatAbility.StatInfos);
    }

    public void TryAttack()
    {
        weaponObject?.TryAttack(this);
    }
     
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * StatAbility.CurrentSpeed * Time.deltaTime, Space.World);
    }

    public void Heal(int amount)
    {
    }

    public void Hit(int damage)
    {
        StatAbility.CurrentHp = character.Hit(StatAbility.CurrentHp, StatAbility.MaxHp, damage);

        if (StatAbility.CurrentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnRemoveEntity();
    }
}
