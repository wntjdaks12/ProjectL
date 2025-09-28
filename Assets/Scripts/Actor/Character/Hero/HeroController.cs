using System.Linq;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] private HeroObject heroObject;

    private CharacterStat characterStat;

    private void Awake()
    {
        characterStat = FindObjectOfType<CharacterStat>();
    }

    private void Update()
    {
        if (heroObject == null) return;

        Collider[] hits = Physics.OverlapSphere(transform.position, 100f, 1 << LayerMask.NameToLayer("Monster"));
        hits = hits.OrderBy(x => Vector3.Distance(heroObject.transform.position, x.transform.position)).ToArray();

        Collider[] hitsInAttackRange = hits.Where(x => Vector3.Distance(heroObject.transform.position, x.transform.position) <= heroObject.StatAbility.AttackRange).ToArray();
        if (hitsInAttackRange.Length > 0)
        {
            Vector3 dir = (hitsInAttackRange[0].transform.position - heroObject.transform.position).normalized;
            heroObject.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

            heroObject.TryAttack();
        }
        else
        {
            Vector3 dir = (hits[0].transform.position - heroObject.transform.position).normalized;
            heroObject.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
            heroObject.Move(dir);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, 1 << LayerMask.NameToLayer("Hero")))
            {
                OnHeroClicked();
            }
        }
    }

    public void OnHeroClicked()
    {
        if (characterStat != null)
        {
            CharacterStatViewModel viewModel = new CharacterStatViewModel(heroObject.StatAbility);
            characterStat.Bind(viewModel);
            characterStat.Show();
        }
    }
}
