using UnityEngine;

public class CharacterObject : ActorObject, ICaster, IHeath, IStatAbility
{
    public StatAbility StatAbility { get; set; } = new StatAbility();

    private WeaponObject weaponObject;

    [field: SerializeField] public Transform WeaponNode { get; private set; }
    public Transform Caster { get; set; }

    private Character character;

    public override void Init(Entity entity)
    {
        base.Init(entity);

        character = Entity as Character;

        Caster = transform;
    }

    public void SetWeapon(WeaponObject weaponObject)
    {
        this.weaponObject = weaponObject;
    }

    public void TryAttack(float attackSpeed)
    {
        weaponObject?.TryAttack(this, attackSpeed);
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
