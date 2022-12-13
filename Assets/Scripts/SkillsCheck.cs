using UnityEngine;
using UnityEngine.UI;

public class SkillsCheck : MonoBehaviour
{
    [SerializeField] private PlayerSkills playerSkills;
    [SerializeField] private GameObject skipQuestion;
    [SerializeField] private Image skipQuestionImage;
    [SerializeField] private Sprite skipQuestionSpriteCooldown;
    [SerializeField] private GameObject changeAnswers;
    [SerializeField] private Image changeAnswersImage;
    [SerializeField] private Sprite changeAnswersSpriteCooldown;
    [SerializeField] private GameObject restartTalk;
    [SerializeField] private Image restartTalkImage;
    [SerializeField] private Sprite restartTalkSpriteCooldown;
    [SerializeField] private TalkingStates talkingStates;



    void Update()
    {
        if (playerSkills.skipbought)
            skipQuestion.SetActive(true);
        else
        skipQuestion.SetActive(false);
        if(playerSkills.changeBought)
            changeAnswers.SetActive(true);
        else 
            changeAnswers.SetActive(false);
        if(playerSkills.restartbought)
             restartTalk.SetActive(true);
        else
            restartTalk.SetActive(false);
        if (talkingStates.skill1Used)
            changeAnswersImage.sprite = changeAnswersSpriteCooldown;
        if (talkingStates.restartCooldown > 0)
            restartTalkImage.sprite = restartTalkSpriteCooldown;
        if(talkingStates.skipCooldown > 0)
            skipQuestionImage.sprite = skipQuestionSpriteCooldown; 
    }

}
