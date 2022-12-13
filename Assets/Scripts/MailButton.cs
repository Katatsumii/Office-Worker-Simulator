using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MailButton : MonoBehaviour
{
    private MailSpawner mailSpawner;
    [SerializeField]
    GameObject mailAnswersHolder;
    [SerializeField]
    GameObject selectedResponseHolder;
    [SerializeField]
    GameObject bigMailHolder;
    [SerializeField]
    private GameObject mailWhole;
    [SerializeField]
    private Mails mailScriptableObject;
    [SerializeField]
    private Sprite readSprite;
    TextMeshProUGUI child1, child2, child3;
    [SerializeField]
    private MailManager manager;
    public bool isSelected = false;
    public bool isActive = false;

    private void Start()
    {
        mailSpawner = GameObject.Find("TimeManager").GetComponent<MailSpawner>();
        child1 = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        child1.text = mailScriptableObject.sender;
        child2 = this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        child2.text = mailScriptableObject.title;
        child3 = this.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        child3.text = mailScriptableObject.smallPart;



    }

    public void Setup(Mails mail,MailManager manager)
    {
        this.mailScriptableObject = mail;
        this.manager = manager;
    }
    public void OnClick()

    { bigMailHolder.SetActive(true);
        foreach (var btn in mailSpawner.mailButtons)
        {
            btn.isSelected = false;
        }
        isSelected = true;
        foreach(Transform item in mailAnswersHolder.transform)
        {
            Destroy(item.gameObject);
        }
        selectedResponseHolder.SetActive(false);
        manager.SetActiveMail(mailScriptableObject);
    }
   

    public void MailButtonPressed()
    {
        this.gameObject.GetComponent<Image>().sprite = readSprite;
        child1=this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        child2 = this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        child3 = this.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        child1.color = Color.black;
        child2.color = Color.black;
        child3.color = Color.black;
        mailWhole.SetActive(true);
    }
    public void DeleteThisMail()
    {
        Destroy(gameObject);
    }
}
