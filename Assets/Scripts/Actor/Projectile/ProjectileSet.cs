using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSet", menuName = "Projectile/ProjectileSet")]
public class ProjectileSet : ScriptableObject
{
    [SerializeField] private string hitVFXPath;
    public string HitVFXPath => hitVFXPath;
}
