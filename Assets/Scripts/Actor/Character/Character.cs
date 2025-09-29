using UnityEngine;

public class Character : Actor
{
    public int Hit(int currentHp, int maxHp, int damage)
    {
        var val = currentHp - damage;
        return Mathf.Clamp(val, 0, maxHp); ;
    }
}
