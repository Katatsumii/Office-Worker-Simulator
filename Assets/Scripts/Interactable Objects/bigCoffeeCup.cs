using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigCoffeeCup : Interactable
{
    public bool drinkedToday = false;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerSkills playerSkills;

    private void Update()
    {
        if (drinkedToday == false)
            promptMessage = "Press <color=yellow>E</color> to drink";
        else
            promptMessage = "Empty";
    }
    protected override void Interact()
    {
        if (drinkedToday == false)
        {
            if (playerSkills.boostCoffeBought)
                playerStats.UpdateEnergy(80);
            else
                playerStats.UpdateEnergy(40);
            drinkedToday = true;
        }
        else if (drinkedToday == true)
            return;


    }
}
