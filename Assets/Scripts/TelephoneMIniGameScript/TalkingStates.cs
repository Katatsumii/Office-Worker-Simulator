using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingStates : MonoBehaviour
{
    public conversationstates currentState;
    [SerializeField]
    private GameObject[] clientArguments;
    [SerializeField]
    private GameObject[] arguments;
    [SerializeField]
    private GameObject[] endArguments;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private Animator cameraanim;
    [SerializeField]
    private ClientData clientData;
    [SerializeField]
    private GameObject skillHolder;

    private GameObject finalArgument;
    public GameObject clientArgumentScreen;
    public GameObject AnswersScreen;
    public GameObject clientArgument;
    public GameObject argument1;
    public GameObject argument2;
    public GameObject argument3;
    [SerializeField]
    private GameObject parentOfClientArgument;
    [SerializeField]
    private GameObject parentOfArguments;
    [SerializeField]
    private GameObject parentOfEndArguments;
    [SerializeField]
    private GameObject answersButton;
    [SerializeField]
    private GameObject affectionBar;
    [SerializeField]
    private GameObject timerBar;
    [SerializeField]
    private GameAffection affection;
    [SerializeField]
    private Image timerfill;
    private float timer = 15f;
    private float timer2 = 15f;
    private float maxTimer2 = 15f;
    public int chosenAnswer;

    public ClientTextScript clientTextScript;

    public bool skill1Used = false;
    public  int restartCooldown = 0;
    public int skipCooldown = 0;



    public enum conversationstates
    {   
        start,
        talk1,
        talk2,
        talk3,
        after
    }

    private void Start()
    {
        startStart();
        currentState = conversationstates.talk1;

    }


    private void Update()
    {
        timerfill.fillAmount = timer2 / maxTimer2;
        switch(currentState)
        {
            case conversationstates.start:
                break;
            case conversationstates.talk1:
                talk1Update();
                break;
            case conversationstates.talk2:
                talk2Update();
                break;
            case conversationstates.talk3:
                talk3Update();
                break;
            case conversationstates.after:
                afterUpdate();
                break;
        }
    }
    //=============Start==========================
    void startStart() 
    { 
        if(finalArgument!=null)
        {
            Destroy(finalArgument);
        }
        skill1Used = false;
        affection.Affection = 0f;
        answersButton.SetActive(true);
        affectionBar.SetActive(true);
        timerBar.SetActive(true);
        parentOfClientArgument.SetActive(true);
        parentOfEndArguments.SetActive(false);
        parentOfArguments.SetActive(false);
    }
    void startUpdate() { }
    void startEnd() { }

    //=============talk1==========================
    void talk1Start() 
    {
        chosenAnswer = 0;
        clientArgument = Instantiate(clientArguments[Random.Range(0, clientArguments.Length)]);
        clientTextScript = clientArgument.GetComponent<ClientTextScript>();
        clientArgument.transform.SetParent(parentOfClientArgument.transform, false);
        argument1 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument1ReadData = argument1.GetComponent<ReadData>();
        argument1ReadData.sendType += Argument1Chosen;
        argument1.transform.SetParent(parentOfArguments.transform, false);
        argument2 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument2ReadData = argument2.GetComponent<ReadData>();
        argument2ReadData.sendType += Argument1Chosen;
        argument2.transform.SetParent(parentOfArguments.transform, false);
        argument3 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument3ReadData = argument3.GetComponent<ReadData>();
        argument3ReadData.sendType += Argument1Chosen;
        argument3.transform.SetParent(parentOfArguments.transform, false);
        timer = 15f;
        timer2 = 15f;

    }
    void talk1Update() 
    {
        timer2 -= Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0)
            ChangeConversationState(conversationstates.talk2);
    }
    void talk1End() 
    {
            affection.calculateAffection();
        Destroy(clientArgument);
        Destroy(argument1);
        Destroy(argument2);
        Destroy(argument3);
     }
    //=============talk2==========================
    void talk2Start() 
    {
        chosenAnswer = 0;
        clientArgument = Instantiate(clientArguments[Random.Range(0, clientArguments.Length)]);
        skillHolder.SetActive(false);
        answersButton.SetActive(true);
        parentOfArguments.SetActive(false);
        parentOfClientArgument.SetActive(true);
        clientTextScript = clientArgument.GetComponent<ClientTextScript>();
        clientArgument.transform.SetParent(parentOfClientArgument.transform, false);
        argument1 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument1ReadData = argument1.GetComponent<ReadData>();
        argument1ReadData.sendType += Argument1Chosen;
        argument1.transform.SetParent(parentOfArguments.transform, false);
        argument2 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument2ReadData = argument2.GetComponent<ReadData>();
        argument2ReadData.sendType += Argument1Chosen;
        argument2.transform.SetParent(parentOfArguments.transform, false);
        argument3 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument3ReadData = argument3.GetComponent<ReadData>();
        argument3ReadData.sendType += Argument1Chosen;
        argument3.transform.SetParent(parentOfArguments.transform, false);
        parentOfArguments.SetActive(false);
        parentOfClientArgument.SetActive(true) ;
        timer = 15f;
        timer2 = 15f;

    }
    void talk2Update() 
    {
        timer2 -= Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0)
            ChangeConversationState(conversationstates.talk3);
    }
    void talk2End() 
    {
        affection.calculateAffection();
        Destroy(clientArgument);
        Destroy(argument1);
        Destroy(argument2);
        Destroy(argument3);
    }
    //=============talk3==========================
    void talk3Start()
    {
        chosenAnswer = 0;
        clientArgument = Instantiate(clientArguments[Random.Range(0, clientArguments.Length)]);
        answersButton.SetActive(true);
        parentOfArguments.SetActive(false);
        parentOfClientArgument.SetActive(true);
        clientTextScript = clientArgument.GetComponent<ClientTextScript>();
        clientArgument.transform.SetParent(parentOfClientArgument.transform, false);
        argument1 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument1ReadData = argument1.GetComponent<ReadData>();
        argument1ReadData.sendType += Argument1Chosen;
        argument1.transform.SetParent(parentOfArguments.transform, false);
        argument2 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument2ReadData = argument2.GetComponent<ReadData>();
        argument2ReadData.sendType += Argument1Chosen;
        argument2.transform.SetParent(parentOfArguments.transform, false);
        argument3 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument3ReadData = argument3.GetComponent<ReadData>();
        argument3ReadData.sendType += Argument1Chosen;
        argument3.transform.SetParent(parentOfArguments.transform, false);
        parentOfArguments.SetActive(false);
        skillHolder.SetActive(false);
        parentOfClientArgument.SetActive(true);
        timer = 15f;
        timer2 = 15f;
    }
    void talk3Update() {
        timer2 -= Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0)
            ChangeConversationState(conversationstates.after);
    }
    void talk3End() {
        affection.calculateAffection(); 
        Destroy(clientArgument);
        Destroy(argument1);
        Destroy(argument2);
        Destroy(argument3);
    }
    //=============After==========================
    void afterStart() 
            {
        switch (affection.Affection)
        {
            case >= 80: 
                finalArgument = Instantiate(endArguments[3]);
                playerStats.numberofCalls++;
                playerStats.numberofCalls++;
                playerStats.UpdateSocial(10f);
                playerStats.UpdateWork(5f);

                break;
            case >= 60 and <= 79:
                finalArgument = Instantiate(endArguments[2]);
                playerStats.numberofCalls++;
                playerStats.numberofContracts++;
                break;
            case >= 40 and <= 59:
                finalArgument = Instantiate(endArguments[1]);
                playerStats.UpdateEnergy(-10f);
                playerStats.numberofCalls++;
                break;
            case <= 39:
                finalArgument = Instantiate(endArguments[0]);
                playerStats.UpdateEnergy(-10f);
                playerStats.UpdateWork(-5f);
                playerStats.numberofCalls++;
                break;
            }
        clientData.SwapIndex();
        parentOfArguments.SetActive(false);
        parentOfClientArgument.SetActive(false);
        answersButton.SetActive(false);
        affectionBar.SetActive(false);
        timerBar.SetActive(false);
        skillHolder.SetActive(false);
        restartCooldown--;
        skipCooldown--;

        parentOfEndArguments.SetActive(true);
        
        finalArgument.transform.SetParent(parentOfEndArguments.transform, false);
            }
    void afterUpdate() { }
    void afterEnd() { }
    //=============Other==========================
    public void ChangeConversationState(conversationstates state)
    {
        switch(currentState)
        {
            case conversationstates.start:
                startEnd();
                break;
            case conversationstates.talk1:
                talk1End();
                break;
            case conversationstates.talk2:
                talk2End();
                break;
            case conversationstates.talk3:
                talk3End();
                break;
            case conversationstates.after:
                afterEnd();
                break;
        }
        switch(state)
        {
            case conversationstates.start:
                startStart();
                break;
            case conversationstates.talk1:
                talk1Start();
                break;
            case conversationstates.talk2:
                talk2Start();
                break;
            case conversationstates.talk3:
                talk3Start();
                break;
            case conversationstates.after:
                afterStart();
                break;
        }
        currentState = state;
    }
    public void ChangeToStartState()
    {
        ChangeConversationState(conversationstates.start);
    }
    public void ChangeToTalk1State()
    { ChangeConversationState(conversationstates.talk1);}
    public void ResetCameraAnimator()
    {
        cameraanim.SetTrigger("PutDown");
    }


    void Argument1Chosen(int dataText)
    {
        chosenAnswer = dataText;
    }
   
    public void SetTimerTo1()
    {
        timer = 0.1f;
    }
    public void SkillChangeAnswers()
    {
        if(skill1Used==false)
        {
        Destroy(argument1);
        Destroy(argument2);
        Destroy(argument3);
        argument1 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument1ReadData = argument1.GetComponent<ReadData>();
        argument1ReadData.sendType += Argument1Chosen;
        argument1.transform.SetParent(parentOfArguments.transform, false);
        argument2 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument2ReadData = argument2.GetComponent<ReadData>();
        argument2ReadData.sendType += Argument1Chosen;
        argument2.transform.SetParent(parentOfArguments.transform, false);
        argument3 = Instantiate(arguments[Random.Range(0, arguments.Length)]);
        var argument3ReadData = argument3.GetComponent<ReadData>();
        argument3ReadData.sendType += Argument1Chosen;
        argument3.transform.SetParent(parentOfArguments.transform, false);
            skill1Used = true;

        }


    }
    public void SkillRestart()
    {
        if(restartCooldown<=0)
        {
        ChangeConversationState(conversationstates.talk1);
        skill1Used = false;
        affection.Affection = 0f;
        answersButton.SetActive(true);
        affectionBar.SetActive(true);
        timerBar.SetActive(true);
        parentOfClientArgument.SetActive(true);
        parentOfEndArguments.SetActive(false);
        parentOfArguments.SetActive(false);
            restartCooldown = 3;
        }
        
    }
    public void NextQuestion()
    {
        if(skipCooldown<=0)
        {
        switch(currentState)
        {
            case conversationstates.talk1:ChangeConversationState(conversationstates.talk2);
                affection.Affection += 20;
                break;
            case conversationstates.talk2:ChangeConversationState(conversationstates.talk3);
                affection.Affection += 20;
                break;
            case conversationstates.talk3:ChangeConversationState(conversationstates.after);
                affection.Affection += 20;
                break;
        }
        skipCooldown = 2;
        }
    }
}
