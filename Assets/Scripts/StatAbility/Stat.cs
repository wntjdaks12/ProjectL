using Newtonsoft.Json;
using System;

[Serializable]
public class Stat : Data
{
    [JsonProperty] private float maxHp;                      // �ִ� ü��
    [JsonProperty] private float attackDamage;               // ���� ���ݷ�
    [JsonProperty] private float abilityPower;               // ���� ���ݷ�
    [JsonProperty] private float maxSpeed;                   // �ִ� �̵� �ӵ�
    [JsonProperty] private float attackSpeed;                // ���� �ӵ�

    public float MaxHp => maxHp;    
    public float AttackDamage => attackDamage;
    public float AbilityPower => abilityPower;
    public float MaxSpeed => maxSpeed;
    public float AttackSpeed => attackSpeed;
}
