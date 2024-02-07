using UnityEngine;
using UnityEngine.UI;
using CharacterSelectView; // Import the namespace where CharacterSelectView class is defined

public class MainMenuView : View
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;

    [SerializeField] private Button quitButton;

    public override void Initialize()
    {
        startButton.onClick.AddListener(StartGame);
        optionButton.onClick.AddListener(GameOptions);
        quitButton.onClick.AddListener(Quit);
    }

    private void StartGame()
    {
        // Transition to CharacterSelectView class (not the namespace)
        ViewManager.Show<CharacterSelectView.CharacterSelectView>(); // Assuming CharacterSelectView is the name of the class
    }

    private void GameOptions(){
        ViewManager.Show<OptionsMenuView>();
    }

    private void Quit(){
        Application.Quit();
    }
}
