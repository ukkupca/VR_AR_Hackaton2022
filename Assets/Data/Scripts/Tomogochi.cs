/*--+----1----+----2----+----3----+----4----+----5----+----6----+----7----+--*/
/*  System Name   : ALIENWARE                                                */
/*  Machine & OS  : Oculus Quest (Android)                                   */
/*  Language      : Microsoft C#                                             */
/*                                                                           */
/*  File Contents : Tomogochi pet AI and state machine.                      */
/*  File Attribute: SOURCE                                                   */
/*  File Name     : Tomogochi.CS                                             */
/*                                                                           */
/*--+----1----+----2----+----3----+----4----+----5----+----6----+----7----+--*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomogochi : MonoBehaviour
{
    public string namey;
    public int HP;
    public int ENERGY;
    public int FOOD;
    public int FOODCAP;
    public int STR;
    public int AGI;
    public int DEF;
    public int LEVEL;
    public int EXP;
    public int NextLevel;

    public enum TomyStates
    {
        Idle,
        Walking,
        Eating,
        Battle,
        Death,
        Revive
    }


    public enum TomyEmotions
    {
        Born,
        Sad,
        Happy,
        Anxious,
        Angry,
        Annoyed,
        Scared,
        Curious
    }

    public TomyStates currentTomyState;
    public TomyEmotions currentTomyEmotion;

    // Start is called before the first frame update
    void Start()
    {
        currentTomyState = TomyStates.Idle;

        currentTomyEmotion = TomyEmotions.Born;
        // This part here is for the first ever init when we have done the thing for 
    }

    // Update is called once per frame
    void Update()
    {
        // This part here takes care of the level up, and exp calculation
        if(NextLevel <= 0)
        {
            LEVEL += 1;
            int nextEXP = (int)Mathf.Pow(2, LEVEL) + 10 * LEVEL;
            NextLevel += nextEXP;

            HP += (int)Random.Range(0, 5);
            ENERGY += (int)Random.Range(0, 5);
            STR += (int)Random.Range(0, 5);
            AGI += (int)Random.Range(0, 5);
            DEF += (int)Random.Range(0, 5);
            FOODCAP += (int)Random.Range(0, 10);
        }

        switch(currentTomyState)
        {
            case TomyStates.Idle:
                switch (currentTomyEmotion)
                {
                    case TomyEmotions.Born:

                        break;

                    case TomyEmotions.Angry:

                        break;

                    case TomyEmotions.Annoyed:

                        break;

                    case TomyEmotions.Anxious:

                        break;

                    case TomyEmotions.Curious:

                        break;

                    case TomyEmotions.Happy:

                        break;

                    case TomyEmotions.Sad:

                        break;

                    case TomyEmotions.Scared:

                        break;
                }
                break;

            case TomyStates.Eating:

                break;

            case TomyStates.Battle:

                break;

            case TomyStates.Death:

                break;

            case TomyStates.Revive:

                break;

            case TomyStates.Walking:

                break;
        }


    }

    
}
