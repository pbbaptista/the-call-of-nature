using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    public GameObject player;
    public UIDocument uiDocumentStartMenu;
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

        playButton.clicked += Click_PlayButton;

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
    }

    void OnDestroy()
    {
        if (playButton != null)
            playButton.clicked -= Click_PlayButton;
    }

    void Click_PlayButton()
    {
        playButton.style.display = DisplayStyle.None;
        gameTitle.style.display = DisplayStyle.None;
        uiMainChar.style.display = DisplayStyle.None;
        player.GetComponent<Renderer>().enabled = true;
        player.SetActive(true);
        player.transform.localScale = new Vector3(-0.025f, -0.025f);
        player.transform.position = new Vector3(0f, -2.63f);
    }
}
