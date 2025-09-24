using System.ComponentModel;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    [SerializeField] private GameObject view;
    [SerializeField] private CharacterStatSlot[] slots;
    
    private CharacterStatViewModel viewModel;

    public void Bind(CharacterStatViewModel viewModel)
    {
        this.viewModel = viewModel;
        viewModel.PropertyChanged += OnViewModelPropertyChanged;

        UpdateUI();
    }

    public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }

    public void Show()
    {
        view.SetActive(true);
    }

    public void Hind()
    {
        view.SetActive(false);
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            switch (slots[i].Type)
            {
                case CharacterStatSlot.StatType.MaxHp: slots[i].UpdateUI(viewModel.MaxHp); break;
                case CharacterStatSlot.StatType.AttackDamage: slots[i].UpdateUI(viewModel.AttackDamage); break;
                case CharacterStatSlot.StatType.AbilityPower: slots[i].UpdateUI(viewModel.AbilityPower); break;
                case CharacterStatSlot.StatType.AttackSpeed: slots[i].UpdateUI(viewModel.AttackSpeed); break;
                case CharacterStatSlot.StatType.MaxSpeed: slots[i].UpdateUI(viewModel.MaxSpeed); break;
            }
        }
    }
}
