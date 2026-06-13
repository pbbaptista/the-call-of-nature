using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    public UIDocument uiDocument;
    public Button playButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton = uiDocument.rootVisualElement.Q<Button>("PlayButton");
    }

    // Update is called once per frame
    void Update()
    {
        playButton.clicked += Click_PlayButton();
    }

    System.Action Click_PlayButton()
    {
        playButton.style.display = DisplayStyle.None;

        return null;
    }
}
