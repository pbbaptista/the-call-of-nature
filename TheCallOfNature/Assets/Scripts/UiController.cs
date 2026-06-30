using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    public GameObject player;
    public float thrustForce = 1f;
    public UIDocument uiDocumentStartMenu;
    public GameObject tutorialRunner;

    private Button playButton;
    private Label gameTitle;
    private Image uiMainChar;

    void Start()
    {
        if (uiDocumentStartMenu == null)
        {
            Debug.LogError("UiController: uiDocumentStartMenu is not assigned in the Inspector.");
            return;
        }

        playButton = uiDocumentStartMenu.rootVisualElement.Q<Button>("PlayButton");
        if (playButton == null)
        {
            Debug.LogError("UiController: PlayButton not found in UI Document (name 'PlayButton').");
            return;
        }

        playButton.clicked += LeaveStartMenu;

        gameTitle = uiDocumentStartMenu.rootVisualElement.Q<Label>("GameTitle");

        if (gameTitle == null)
        {
            Debug.LogError("UiController: GameTitle not found in UI Document");
            return;
        }

        uiMainChar = uiDocumentStartMenu.rootVisualElement.Q<Image>("UiMainChar");

        if (uiMainChar == null)
        {
            Debug.LogError("UiController: UiMainChar not found in UI Document");
        }

        Debug.Log($"Game loaded");
    }

    void OnDestroy()
    {
        if (playButton != null)
            playButton.clicked -= LeaveStartMenu;
    }

    void LeaveStartMenu()
    {
        Debug.Log($"Play button clicked. Leaving Start Menu");
        playButton.style.display = DisplayStyle.None;
        gameTitle.style.display = DisplayStyle.None;
        uiMainChar.style.display = DisplayStyle.None;      
        
        player.SetActive(true);

        tutorialRunner.SetActive(true);
    }
}
