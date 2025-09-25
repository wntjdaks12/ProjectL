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

        heroObject.TryAttack();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, 1 << LayerMask.NameToLayer("Character")))
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
