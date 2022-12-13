using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerStats : MonoBehaviour,ISavingManager
{
    [SerializeField] private Slider energyBar;
    [SerializeField] private Slider socialBar;
    [SerializeField] private Slider workBar;

    private PlayerSkills playerSkills;

    private GameOver gameOver;

    public float toPromotion = 50f;
    public float energy = 100f;
    public float social = 100f;
    public float money = 250;
    public float energyRestoration;
  
    [SerializeField]
    private TextMeshProUGUI cashAmount;

    public float charisma = 1;
    public float endurance = 1;
    public float intelligence = 1;
  
    public float maxSocial = 100;
    public float maxEnergy = 100;

    public int numberofCalls = 0;
    public int numberofContracts = 0;
    public int freeDays = 0;
    public int mailsAnswered = 0;
    private void Start()
    {
        gameOver = GetComponent<GameOver>();
        playerSkills = GetComponent<PlayerSkills>();
    }
    public void Load(GameData gamedata)
    {
        this.toPromotion=gamedata.toPromotion;
        this.energy = gamedata.energy;
        this.social = gamedata.social;
        this.money = gamedata.money;
        this.energyRestoration = gamedata.energyRestoration;
        this.charisma = gamedata.charisma;
        this.endurance = gamedata.endurance;
        this.intelligence =gamedata.intelligence;
        this.maxSocial = gamedata.maxSocial;
        this.maxEnergy = gamedata.maxEnergy;
        this.numberofCalls = gamedata.numberofcalls;
        this.numberofContracts = gamedata.numberofContract;
        this.freeDays = gamedata.freeDays;
        this.mailsAnswered =gamedata.mailsAnswered;
    }
    public void Save(GameData gamedata)
    {
        gamedata.toPromotion = this.toPromotion;
        gamedata.energy = this.energy;
        gamedata.social = this.social;
        gamedata.money= this.money;
        gamedata.energyRestoration= this.energyRestoration;
        gamedata.charisma = this.charisma;
        gamedata.endurance = this.endurance;
        gamedata.intelligence= this.intelligence;
        gamedata.maxSocial= this.maxSocial;
        gamedata.maxEnergy= this.maxEnergy;
        gamedata.numberofcalls = this.numberofCalls;
        gamedata.numberofContract= this.numberofContracts;
        gamedata.freeDays= this.freeDays;
        gamedata.mailsAnswered = this.mailsAnswered;

    }

    private void Update()
    {
        if(money<0)
             money = 0;
        cashAmount.text = money + "$";
        energyBar.value = energy;
        workBar.value = toPromotion;
        socialBar.value = social;


    }
    public void changeMoney(float value)
    {
        money += value;
    }
    public void energyStatusBar()
    {
        energyBar.value = energy;
    }
    public void workStatusBar()
    {
        workBar.value = toPromotion;
    }
    public void socialStatusBar()
    {
        socialBar.value = social;
    }
    public void UpdateEnergy(float value)
    {
        energy += value;
        if (energy <= 0)
            gameOver.gameOver.Invoke(0);
        if(energy>maxEnergy)
            energy=maxEnergy;

    }
    public void UpdateSocial(float value)
    {
        social += value;
        if (social <= 0)
            gameOver.gameOver.Invoke(1);
        if (social > maxSocial)
            social = maxSocial;
    }
    public void UpdateWork(float value)
    {
        toPromotion += value;
        if (toPromotion <= 0)
            gameOver.gameOver.Invoke(2);
        if (toPromotion > 100)
            toPromotion = 100;
    }
    public void UpdateMoney(float value)
    {
        money += value;
        if (money < 0)
            gameOver.gameOver.Invoke(3);
    }
    public void UpdateCharisma()
    {
        charisma++;
        maxSocial += 10;
    }
    public void UpdateEndurance()
    {
        endurance++;
        maxEnergy += 10;
        energyRestoration = 0;
        energyRestoration = maxEnergy * 0.3f;
        if (playerSkills.boostBreakBought)
            energyRestoration += 30;
    }
    public void UpdateIntelligence()
    {
        intelligence++;
    }

}
