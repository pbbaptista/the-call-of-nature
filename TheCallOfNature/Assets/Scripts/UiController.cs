using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    public UIDocument uiDocumentStartMenu;
    public Button playButton;

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

        playButton.clicked += Click_PlayButton;
    }

    void OnDestroy()
    {
        if (playButton != null)
            playButton.clicked -= Click_PlayButton;
    }

    void Click_PlayButton()
    {
        playButton.style.display = DisplayStyle.None;
    }
}
