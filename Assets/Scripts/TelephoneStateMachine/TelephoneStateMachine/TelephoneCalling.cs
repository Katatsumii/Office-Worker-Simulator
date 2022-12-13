using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneCalling : BaseState
{
    GameObject telephone;
    AudioSource telephoneAudio;
    bool isCounting = false;
   public TelephoneCalling(TelephoneSM stateMachine) : base("Calling",stateMachine) { }


    public override void Start()
    {
        base.Start();
        telephone = GameObject.Find("Telephone");
        telephoneAudio = telephone.GetComponent<AudioSource>();
        telephoneAudio.Play();

    }
    public override void Exit()
    {
        base.Exit();
        telephoneAudio.Stop();
        isCounting = false;
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (isCounting == false)
        {
         
        }
    }
    private IEnumerator CallIncoming()
    {
        isCounting = true;
        yield return new WaitForSeconds(15);
        stateMachine.ChangeState(((TelephoneSM)stateMachine).idleState);

    }

}
