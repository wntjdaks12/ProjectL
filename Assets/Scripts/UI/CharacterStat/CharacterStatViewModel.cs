public class CharacterStatViewModel : ViewModel
{
    private StatAbility statAbility;

    public CharacterStatViewModel(StatAbility statAbility)
    {
        this.statAbility = statAbility;
    }

    public float MaxSpeed => statAbility.MaxSpeed;
    public float MaxHp => statAbility.MaxHp;
    public int AttackDamage => statAbility.AttackDamage;
    public int AbilityPower => statAbility.AbilityPower;
    public float AttackSpeed => statAbility.AttackSpeed;
}
