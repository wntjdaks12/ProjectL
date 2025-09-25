using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 스탯 능력치
public class StatAbility : MonoBehaviour
{
    public class StatInfo
    {
        public enum StatDataType { Main, Sub }

        public StatDataType statDataType;
        public Stat stat;

        public StatInfo(StatDataType statDataType, Stat stat)
        {
            this.statDataType = statDataType;
            this.stat = stat;
        }
    }

    public List<StatInfo> StatInfos { get; private set; }

    private void Awake()
    {
        StatInfos = new List<StatInfo>();
    }

    /// <summary>
    /// 스탯 데이터 추가
    /// </summary>
    /// <param name="statDataType">스탯 데이터 타입</param>
    /// <param name="statData">스탯 데이터</param>
    public void AddStatData(StatInfo.StatDataType statDataType, Stat stat)
    {
        StatInfos.Add(new StatInfo(statDataType, stat));
    }

    /// <summary>
    /// 스텟 데이터 삭제
    /// </summary>
    /// <param name="statDataType">스탯 데이터 타입</param>
    /// <param name="statData">스탯 데이터</param>
    public void RemoveStatData(StatInfo.StatDataType statDataType, Stat stat)
    {
        var statInfo = StatInfos.Where(x => x.statDataType == statDataType && x.stat.Id == stat.Id).FirstOrDefault();

        if (statInfo == null)
        {
        }
        else
        {
            StatInfos.Remove(statInfo);
        }
    }

    // 현재 이동 속도
    private float currentSpeed;
    public float CurrentSpeed
    {
        get { return currentSpeed; }
        set { currentSpeed = value; }
    }
    // 현재 체력
    private int currentHp;
    public int CurrentHp
    {
        get { return currentHp; }
        set { currentHp = value; }
    }

    // 최대 이동 속도
    public float MaxSpeed
    {
        get { return StatInfos.Sum(x => x.stat.MaxSpeed); }
    }
    // 최대 체력
    public int MaxHp
    {
        get { return (int)StatInfos.Sum(x => x.stat.MaxHp); }
    }
    // 물리 공격력
    public int AttackDamage
    {
        get { return (int)StatInfos.Sum(x => x.stat.AttackDamage); }
    }
    // 마법 공격력
    public int AbilityPower
    {
        get { return (int)StatInfos.Sum(x => x.stat.AbilityPower); }
    }
    // 총 공격력
    public int AttackPower
    {
        get { return AttackDamage + AbilityPower; }
    }
    // 공격 속도
    public float AttackSpeed
    {
        get { return StatInfos.Sum(x => x.stat.AttackSpeed); }
    }
    // 공격 사거리
    public float AttackRange
    {
        get { return StatInfos.Sum(x => x.stat.AttackRange); }
    }
}
