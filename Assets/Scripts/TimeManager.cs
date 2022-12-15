using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour,ISavingManager
{
    [SerializeField] private TextMeshProUGUI tHours;
    [SerializeField] private TextMeshProUGUI tMinutes;
    [SerializeField] private TextMeshProUGUI tDays;
    [SerializeField] private TextMeshProUGUI tMonth;
    [SerializeField] private TextMeshProUGUI tYears;
    [SerializeField] private TextMeshProUGUI cHours;
    [SerializeField] private TextMeshProUGUI cMinutes;
    [SerializeField] private TextMeshProUGUI cDays;
    [SerializeField] private TextMeshProUGUI cMonth;
    [SerializeField] private TextMeshProUGUI cYears;

    [SerializeField] GameOver gameOver;


    public string currentDate;
    public float hours;
    public float minutes;
    public float days;
    public float months;
    public float years;

    public void Save(GameData gameData)
    {
        gameData.day = this.days;
        gameData.month = this.months;
        gameData.year = this.years;
    }
    public void Load(GameData gameData)
    {
        this.days = gameData.day;
        this.months = gameData.month;
        this.years = gameData.year;
    }
    void Update()
    {
        minutes += Time.deltaTime;
        Checks();
        AssignText();

        currentDate = days.ToString("00")+"."+ months.ToString("00")+"."+ years.ToString("00");

        if (hours > 18)
            gameOver.gameOver.Invoke(0);

       
      
        
    }
    private void Checks()
    {
        if (minutes >= 59)
        {
            minutes = 0;
            hours++;
        }

        if (hours >= 24)
        {
            hours = 0;
        }

        if (days >= 29)
        {
            days = 1;
            months++;
        }
        if (months >= 13)
        {
            months = 1;
            years++;
        }
    }
    private void AssignText()
    {
        tHours.text = (hours).ToString("00");
        tMinutes.text = (minutes).ToString("00");
        tDays.text = (days).ToString("00");
        tMonth.text = (months).ToString("00");
        tYears.text = (years).ToString("00");
        cHours.text = (hours).ToString("00");
        cMinutes.text = (minutes).ToString("00");
        cDays.text = (days).ToString("00");
        cMonth.text = (months).ToString("00");
        cYears.text = (years).ToString("00");
    }
    
}
