using UnityEngine;

public class Character : Actor
{
    public int Hit(int currentHp, int maxHp, int damage)
    {
        var val = currentHp - damage;
        return Mathf.Clamp(val - damage, 0, maxHp); ;
    }
}
