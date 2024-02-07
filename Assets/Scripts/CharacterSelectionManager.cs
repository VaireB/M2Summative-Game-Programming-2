using System;
using UnityEngine;

namespace CharacterSelectView
{
    // Enum to represent different character types
    public enum JobType
    {
        Warrior,
        Archer,
        Assassin,
        Wizard
    }

    public class CharacterSelectionManager : MonoBehaviour
    {
        // Singleton instance of CharacterSelectionManager
        public static CharacterSelectionManager instance;

        // Store the selected character type
        public JobType selectedCharacterType;

        private void Awake()
        {
            // Ensure only one instance of CharacterSelectionManager exists
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return; // Ensure we exit early after destroying duplicate instances
            }

            // Keep the GameObject persistent across scenes
            DontDestroyOnLoad(gameObject);
        }

        // Method to set the selected character type
        public void SetSelectedCharacter(JobType characterType)
        {
            selectedCharacterType = characterType;
        }
    }
}
