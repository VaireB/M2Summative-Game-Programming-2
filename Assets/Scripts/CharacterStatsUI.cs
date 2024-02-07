using UnityEngine;
using UnityEngine.UI;
using CharacterSelectView;
public class CharacterStatsUI : MonoBehaviour
{
    public Text healthText;
    public Text manaText;
    public Text attackText;
    public Text defenseText;
    public Text levelText;

    private CharacterSelectionManager selectionManager;

    private void Start()
    {
        // Find and store the CharacterSelectionManager instance
        selectionManager = FindObjectOfType<CharacterSelectionManager>();

        // Ensure the CharacterSelectionManager instance is found
        if (selectionManager == null)
        {
            Debug.LogError("CharacterSelectionManager not found in the scene.");
        }
    }

    private void Update()
    {
        // Update UI based on the selected character
        if (selectionManager != null)
        {
            UpdateUI(selectionManager.selectedCharacterType);
        }
    }

    private void UpdateUI(JobType characterType)
    {
        // Get the instance of the selected character type
        Job characterInstance = GetCharacterInstance(characterType);

        // Update UI elements with character stats based on the selected character type
        if (characterInstance != null)
        {
            UpdateUIText(characterInstance);
        }
        else
        {
            Debug.LogError("Character instance not found for type: " + characterType.ToString());
        }
    }

    private Job GetCharacterInstance(JobType characterType)
    {
        // Get the instance of the selected character type
        switch (characterType)
        {
            case JobType.Warrior:
                return Warrior.Instance;
            case JobType.Archer:
                return Archer.Instance;
            case JobType.Assassin:
                return Assassin.Instance;
            case JobType.Wizard:
                return Wizard.Instance;
            default:
                return null;
        }
    }

    private void UpdateUIText(Job character)
    {
        healthText.text = "Health: " + character.HealthPoints.ToString();
        manaText.text = "Mana: " + character.ManaPoints.ToString();
        attackText.text = "Attack: " + character.AttackPoints.ToString();
        defenseText.text = "Defense: " + character.DefensePoints.ToString();
        levelText.text = "Level: " + character.LevelPoints.ToString();
    }
}
