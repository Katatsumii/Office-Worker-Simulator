using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallCoffeCup : Interactable
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
            if (playerSkills.boostCoffeBought == true)
                playerStats.UpdateEnergy(40);
            else
                playerStats.UpdateEnergy(20);
            drinkedToday = true;
        }
        else if (drinkedToday == true)
            return;

        
    }
}
