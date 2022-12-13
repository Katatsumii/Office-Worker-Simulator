using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAffection : MonoBehaviour
{
    public float Affection=0.0f;
    public int typeOfAnswer;
    public int typeOfClientAnswer;
    public int typeOfClient;
    public int typeOfClient2;
    public int typeOfClient3;
    private float maxAffection = 100f;

    [SerializeField]
    private Image affectionFill;



    [SerializeField]
    private TalkingStates talkingStates;
    [SerializeField]
    private ClientData clientData;


    private void Start()
    {
   
    }
    private void Update()
    {
        affectionFill.fillAmount = Affection / maxAffection;
        
             typeOfAnswer = talkingStates.chosenAnswer;
               if(talkingStates.clientTextScript!=null)

             typeOfClientAnswer = talkingStates.clientTextScript.type;
             typeOfClient = clientData.type;
             typeOfClient2 = clientData.type2;
             typeOfClient3=clientData.type3;
    }


    public void calculateAffection()
    {
        if (typeOfAnswer == 0)
        {
            Affection += 0f;
        }
        else if (typeOfAnswer != 0 && typeOfAnswer == typeOfClientAnswer && typeOfAnswer == typeOfClient)
            Affection += 40f;
        else if (typeOfAnswer != 0 && typeOfAnswer == typeOfClientAnswer && typeOfAnswer == typeOfClient2 || typeOfAnswer == typeOfClient3)
            Affection += 30f;
        else if (typeOfAnswer != 0 && typeOfAnswer == typeOfClientAnswer && typeOfAnswer != typeOfClient && typeOfAnswer != typeOfClient2 && typeOfAnswer != typeOfClient3)
            Affection += 20f;
        else if (typeOfAnswer != 0 && typeOfAnswer != typeOfClientAnswer && typeOfAnswer == typeOfClient)
            Affection += 20f;
        else if (typeOfAnswer != 0 && typeOfAnswer != typeOfClientAnswer && typeOfAnswer == typeOfClient2 || typeOfAnswer == typeOfClient3)
            Affection += 10f;
        else if (typeOfAnswer != 0 && typeOfAnswer != typeOfClientAnswer && typeOfAnswer != typeOfClient3 && typeOfAnswer != typeOfClient2 && typeOfAnswer != typeOfClient3)
            Affection += 0f;
        
            
        
    }
}
