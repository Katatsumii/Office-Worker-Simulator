using UnityEngine;
using TMPro;

public class InteractUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    public void UpdatePrompt(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
