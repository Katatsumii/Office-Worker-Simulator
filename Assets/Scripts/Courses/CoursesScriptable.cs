using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="Course",menuName ="ScriptableObjects/Course")]
public class CoursesScriptable : ScriptableObject
{
    public string CourseName;
    public string CourseDescription;
    public string CoursePrice;
    public Sprite CourseImage;
    public int CourseType;
    

}
