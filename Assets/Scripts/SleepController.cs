using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Data.Scripts;
using UnityEngine.XR.Interaction.Toolkit;

public class SleepController : MonoBehaviour
{
    public Tomogochi tomogochi;
    public XRSocketInteractor bedSocket;
    private bool _isSleeping;

    private void Awake()
    {
        bedSocket.selectEntered.AddListener(StartSleep);
        bedSocket.selectExited.AddListener(EndSleep);
    }

    void StartSleep(SelectEnterEventArgs args)
    {
        _isSleeping = true;
        while (_isSleeping)
        {
            StartCoroutine(Sleep());
            
        }
    } 
    
    IEnumerator Sleep()
    {
        int startEnergy = tomogochi.ENERGY;
        int maxEnergy = tomogochi.ENERGYCAP;
        yield return new WaitForSeconds(0.5f);
        if (startEnergy < maxEnergy && startEnergy + 1 <= maxEnergy)
        {
            tomogochi.IncreaseEnergy(1);
        }
    }
    
    void EndSleep(SelectExitEventArgs args)
    {
        _isSleeping = false;
    } 

}