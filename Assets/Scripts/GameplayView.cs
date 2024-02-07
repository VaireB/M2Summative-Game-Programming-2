using UnityEngine;

public class GameplayView : View
{
    private Job currentPlayer;

    public override void Initialize()
    {
        // Initialize gameplay elements, set up references, etc.
        // For now, let's create a Warrior as the default player character
        currentPlayer = gameObject.AddComponent<Warrior>();
    }

    public override void Show()
    {
        base.Show();
        // Additional logic to execute when the gameplay view is shown
    }

    public override void Hide()
    {
        base.Hide();
        // Additional logic to execute when the gameplay view is hidden
    }

    // Implement or add methods related to gameplay actions and events
    public void PerformAttack()
    {
        currentPlayer.Attack();
    }

    public void PerformDefend()
    {
        currentPlayer.Defend();
    }

    public void PerformEvade()
    {
        currentPlayer.Evade();
    }

    public void SwitchCharacterToWarrior()
    {
        Destroy(currentPlayer); // Destroy the current player character
        currentPlayer = gameObject.AddComponent<Warrior>(); // Add a new Warrior as the player character
    }

    public void SwitchCharacterToArcher()
    {
        Destroy(currentPlayer);
        currentPlayer = gameObject.AddComponent<Archer>();
    }

    public void SwitchCharacterToAssassin()
    {
        Destroy(currentPlayer);
        currentPlayer = gameObject.AddComponent<Assassin>();
    }

    public void SwitchCharacterToWizard()
    {
        Destroy(currentPlayer);
        currentPlayer = gameObject.AddComponent<Wizard>();
    }
}
