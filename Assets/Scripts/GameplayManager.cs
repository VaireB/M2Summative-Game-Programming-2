using UnityEngine;
using CharacterSelectView; // Add this using directive to import the namespace

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPointWarrior;
    [SerializeField] private Transform spawnPointArcher;
    [SerializeField] private Transform spawnPointAssassin;
    [SerializeField] private Transform spawnPointWizard;

    [SerializeField] private GameObject warriorPrefab;
    [SerializeField] private GameObject archerPrefab;
    [SerializeField] private GameObject assassinPrefab;
    [SerializeField] private GameObject wizardPrefab;

    private void Start()
    {
        // Retrieve the selected character type from CharacterSelectionManager
        JobType selectedCharacterType = CharacterSelectionManager.instance.selectedCharacterType;

        // Spawn the selected character based on the retrieved character type
        switch (selectedCharacterType)
        {
            case JobType.Warrior:
                SpawnCharacter(spawnPointWarrior, warriorPrefab);
                break;
            case JobType.Archer:
                SpawnCharacter(spawnPointArcher, archerPrefab);
                break;
            case JobType.Assassin:
                SpawnCharacter(spawnPointAssassin, assassinPrefab);
                break;
            case JobType.Wizard:
                SpawnCharacter(spawnPointWizard, wizardPrefab);
                break;
        }
    }

    private void SpawnCharacter(Transform spawnPoint, GameObject characterPrefab)
    {
        Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
