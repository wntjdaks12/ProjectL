using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] private HeroObject heroObject;

    private void Update()
    {
        if (heroObject != null)
        {
            heroObject.TryAttack();
        }
    }
}
