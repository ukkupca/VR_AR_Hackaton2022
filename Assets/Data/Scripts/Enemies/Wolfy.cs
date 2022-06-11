using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.

public class Wolfy : MonoBehaviour
{

    public Vector3 playerPosXYZ;

    float timer = 0.0f;
    float velocityX, velocityY;
    float Rotation;
    int health = 20;

    float huntingRadius = 24;

    public enum WolfyStates
    {
        Idle,
        Walking,
        Charging,
        Battle,
        Devouring,
        Death
    }

    WolfyStates wolfystaty;

    // Start is called before the first frame update
    void Start()
    {
        wolfystaty = WolfyStates.Idle;

    }

    // Update is called once per frame
    void Update()
    {
        switch (wolfystaty)
        {
            case WolfyStates.Idle:

                if(timer % 200 == 0)
                {
                    wolfystaty = WolfyStates.Walking;

                    if((timer / 40)% 2 == 0)
                    {
                        Rotation = ((timer / 40) % 360) * -1;
                    }
                    else
                    {
                        Rotation = ((timer / 40) % 360);
                    }
                }
                //this.transform.rotation += Rotation;
                timer = 0;
                break;

            case WolfyStates.Walking:

                if (timer % 200 != 0)
                {
                    //this.transform.position.x += velocityX;
                    //this.transform.position.y += velocityY;
                    if(isHumanNearby(playerPosXYZ.x, playerPosXYZ.y))
                    {

                        wolfystaty = WolfyStates.Charging;

                    }
                }
                else
                {
                    wolfystaty = WolfyStates.Idle;
                }

                break;

            case WolfyStates.Devouring:

                break;

            case WolfyStates.Death:

                break;

            case WolfyStates.Charging:
                // Charge towards the player
                //if() ... collided wtih player, battle
                //{

                //}
                break;

            case WolfyStates.Battle:
                if(health >= 0)
                {
                    wolfystaty = WolfyStates.Death;
                }
                break;
        }
    }

    bool isHumanNearby(float posx, float posy)
    {
        float tempx = this.transform.position.x;
        float tempy = this.transform.position.y;
        if (Mathf.Sqrt(((tempx - posx) * (tempx - posx)) + ((tempy - posy) * (tempy - posy))) <= huntingRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
