using Newtonsoft.Json;
using System;

[Serializable]
public class Stat : Data
{
    [JsonProperty] private float maxHp;                      // 최대 체력
    [JsonProperty] private float attackDamage;               // 물리 공격력
    [JsonProperty] private float abilityPower;               // 마법 공격력
    [JsonProperty] private float maxSpeed;                   // 최대 이동 속도
    [JsonProperty] private float attackSpeed;                // 공격 속도

    public float MaxHp => maxHp;    
    public float AttackDamage => attackDamage;
    public float AbilityPower => abilityPower;
    public float MaxSpeed => maxSpeed;
    public float AttackSpeed => attackSpeed;
}
