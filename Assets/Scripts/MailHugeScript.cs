using UnityEngine;
using TMPro;
public class MailHugeScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI data;
    TimeManager timeManager;
    void Start()
    {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        data.text = (timeManager.days).ToString("00") + "." + (timeManager.months).ToString("00") + "." + (timeManager.years).ToString("00");
    }
}

