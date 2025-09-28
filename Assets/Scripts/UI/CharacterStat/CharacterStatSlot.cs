using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatSlot : MonoBehaviour
{
    public enum StatType 
    {
        MaxHp = 101,
        AttackDamage = 102,
        AbilityPower = 103,
        AttackSpeed = 104,
        MaxSpeed = 105,
        AttackRange = 106
    }

    [field: SerializeField] public StatType Type { get; private set; }

    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI valueText;

    public void UpdateUI(float value)
    {
        IconInfo iconInfo = GameApplication.Instance.GameModel.PresetData.ReturnData<IconInfo>(nameof(IconInfo), (int)Type);

        if (iconImage != null) iconImage.sprite = Resources.Load<Sprite>(iconInfo.Path);
        if (valueText != null) valueText.text = value.ToString();
    }
}
