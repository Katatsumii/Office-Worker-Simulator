using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourseButtonScript : MonoBehaviour
{
    [SerializeField] private CoursesScriptable scriptable;
    [SerializeField] private TextMeshProUGUI courseName;
    [SerializeField] private TextMeshProUGUI coursePrice;
    [SerializeField] private TextMeshProUGUI courseDescription;
    [SerializeField] private Image courseImage;
    [SerializeField] private Image courseIcon;
    [SerializeField] private Sprite lifehackIcon;
    [SerializeField] private Sprite talkIcon;
    public int courseType;

    void Start()
    {
        courseName.text = scriptable.CourseName;
        coursePrice.text = scriptable.CoursePrice;
        courseDescription.text = scriptable.CourseDescription;
        courseImage.sprite = scriptable.CourseImage;
        courseType=scriptable.CourseType;
        if (courseType == 1)
            courseIcon.sprite = lifehackIcon;
        else
            courseIcon.sprite = talkIcon;
    }
}
