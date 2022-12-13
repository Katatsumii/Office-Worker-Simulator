using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoanWeeksButton : MonoBehaviour
{
    [SerializeField] private LoanManager manager;
    [SerializeField] private Image image;
    [SerializeField] private Sprite sprite;

    public float weeksAmount;

    public void OnClick()
    {
        manager.ResetInstalmentsButtons();
        image.sprite = sprite;
        manager.SetWeeksAmount(weeksAmount);
    }
}
