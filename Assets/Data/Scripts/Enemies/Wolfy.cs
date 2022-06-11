using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfy : MonoBehaviour
{

    public GameObject player;

    public Rigidbody playerRigidy;

    float timer = 0.0f;
    public float velocityX, velocityY;
    float Rotation;
    bool BattleTurn = false;
    public float huntingRadius = 24;

    public string Namey;
    public int STR;
    public int DEX;
    public int AGI;
    public int HP;


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
        velocityX = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

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
                this.transform.rotation.Set(Rotation, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
                timer = 0;
                break;

            case WolfyStates.Walking:

                if (timer % 200 != 0)
                {
                    playerRigidy.AddForce(new Vector3(velocityX, 0, 0));
                    if (isHumanNearby())
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
                // some kind of eating animation
                break;

            case WolfyStates.Death:
                Object.Destroy(this.gameObject);
                break;

            case WolfyStates.Charging:
                // Charge towards the player
                //if() ... collided wtih player, battle
                //{

                //}
                break;

            case WolfyStates.Battle:
                if(HP >= 0)
                {
                    wolfystaty = WolfyStates.Death;
                }
                int action = (int)Random.Range(0.0f, 3.0f);

                if(BattleTurn)
                {
                    switch(action)
                    {
                        case 0:
                            // Idle

                            break;
                        case 1:
                            // Attack

                            break;
                        case 2:
                            // Guard

                            break;
                        case 3:
                            // Run

                            break;
                    }
                }
                
                break;
        }
    }

    bool isHumanNearby()
    {
        /*float tempx = this.transform.position.x;
        float tempy = this.transform.position.y;
        if (Mathf.Sqrt(((tempx - posx) * (tempx - posx)) + ((tempy - posy) * (tempy - posy))) <= huntingRadius)
        {
            return true;
        }
        else
        {
            return false;
        }*/

        if(Vector3.Distance(player.transform.position, this.transform.position) < huntingRadius)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
