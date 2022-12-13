using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class StatsWindowScript : MonoBehaviour
{
    [Header("About me")] 
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] TextMeshProUGUI playerPosition;
    [SerializeField] TextMeshProUGUI playerCharisma;
    [SerializeField] TextMeshProUGUI playerEndurance;
    [SerializeField] TextMeshProUGUI playerInt;
    [SerializeField] TextMeshProUGUI playerMaxE;
    [SerializeField] TextMeshProUGUI playerMaxS;

    [Header("Skills")]
    [SerializeField] TextMeshProUGUI coffeeM;
    [SerializeField] TextMeshProUGUI ninjaTraining;
    [SerializeField] TextMeshProUGUI monkPatience;
    [SerializeField] TextMeshProUGUI secondChance;
    [SerializeField] TextMeshProUGUI fastThinking;
    [SerializeField] TextMeshProUGUI skipQuestion;

    [Header("Experience")]
    [SerializeField] TextMeshProUGUI numberOfPhoneCalls;
    [SerializeField] TextMeshProUGUI numberOfContracts;
    [SerializeField] TextMeshProUGUI freeDays;
    [SerializeField] TextMeshProUGUI mailsAnswered;
    [Header("")]

    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerSkills playerSkills;
    private void Start()
    {
        playerCharisma.text = playerStats.charisma + "";
        playerEndurance.text = playerStats.endurance + "";
        playerInt.text = playerStats.intelligence + "";
        playerMaxE.text = playerStats.maxEnergy + "";
        playerMaxS.text = playerStats.maxSocial + "";
        if (playerSkills.skipbought)
            skipQuestion.color = Color.black;
        if(playerSkills.restartbought)
            secondChance.color = Color.black;
        if(playerSkills.ninjaBought)
            ninjaTraining.color = Color.black;
        if(playerSkills.boostBreakBought)
            monkPatience.color = Color.black;
        if(playerSkills.changeBought)
            fastThinking.color = Color.black;
        if (playerSkills.boostCoffeBought)
            coffeeM.color = Color.black;

        numberOfPhoneCalls.text = playerStats.numberofCalls + "";
        numberOfContracts.text = playerStats.numberofContracts + "";
        freeDays.text = playerStats.freeDays + "";
        mailsAnswered.text = playerStats.mailsAnswered + "";
            
    }

}
