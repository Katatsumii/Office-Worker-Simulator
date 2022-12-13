using UnityEngine;
[CreateAssetMenu(fileName ="Mail",menuName="ScriptableObjects/Mail")]
public class Mails : ScriptableObject
{
    public string title;
    public string sender;
    public string smallPart;
    [TextArea] public string wholeMail;
    public AnswerButtons[] Buttons;
    public bool isAnswered = false;
}
