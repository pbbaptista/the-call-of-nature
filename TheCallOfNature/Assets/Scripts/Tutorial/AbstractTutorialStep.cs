using UnityEngine;
using UnityEngine.UIElements;

public abstract class AbstractTutorialStep : MonoBehaviour
{
    public System.Action OnCompleted;
    private UIDocument _uiTutorialDocument;
    private string _directiveName;

    internal void Complete()
    {
        OnCompleted.Invoke();
    }
    
    internal void ShowStepDirective()
    {
        _uiTutorialDocument.rootVisualElement.Q<Label>(_directiveName).style.display = DisplayStyle.Flex;
    }

    internal void HideStepDirective()
    {
        if (_uiTutorialDocument != null && !string.IsNullOrEmpty(_directiveName))
        {
            _uiTutorialDocument.rootVisualElement.Q<Label>(_directiveName).style.display = DisplayStyle.None;
        }
    }

    internal void Enter(UIDocument uiTutorialDocument, string directiveName)
    {
        _uiTutorialDocument = uiTutorialDocument;
        _directiveName = directiveName;
        ShowStepDirective();
    }

    internal void Exit()
    {
        HideStepDirective();
    }

}