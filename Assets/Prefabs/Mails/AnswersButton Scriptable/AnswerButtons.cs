using UnityEngine;
[CreateAssetMenu(fileName = "MailAnswer", menuName = "ScriptableObjects/MailAnswer")]
public class AnswerButtons : ScriptableObject
{
    public string btnText;
    public float staminaCost;
    public float socialCost;
    public int isGameOver;
    public int money;
    public float work;
    public bool isChoosen = false;
   [TextArea] public string consequences;
}
