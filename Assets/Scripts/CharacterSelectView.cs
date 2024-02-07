using System;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelectView // Add the namespace to the class
{
    public class CharacterSelectView : View // Ensure CharacterSelectView inherits from View
    {
        [SerializeField] private Button warriorButton;
        [SerializeField] private Button archerButton;
        [SerializeField] private Button assassinButton;
        [SerializeField] private Button wizardButton;

        [SerializeField] private Button backButton;

        public override void Initialize()
        {
            warriorButton.onClick.AddListener(() => SelectCharacter(JobType.Warrior));
            archerButton.onClick.AddListener(() => SelectCharacter(JobType.Archer));
            assassinButton.onClick.AddListener(() => SelectCharacter(JobType.Assassin));
            wizardButton.onClick.AddListener(() => SelectCharacter(JobType.Wizard));
            backButton.onClick.AddListener(()=> ViewManager.ShowLast());
        }

        private void SelectCharacter(JobType characterType)
        {
            if (CharacterSelectionManager.instance != null)
            {
                CharacterSelectionManager.instance.SetSelectedCharacter(characterType);
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameplayScene");
            }
            else
            {
                Debug.LogError("CharacterSelectionManager instance is not found.");
            }
        }
    }
}
