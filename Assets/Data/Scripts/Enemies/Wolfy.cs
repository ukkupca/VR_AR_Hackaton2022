using System.Collections;
using System.Collections.Generic;
using Data.Scripts;
using UnityEngine;

public class Wolfy : MonoBehaviour
{
    public Rigidbody SlimeyRigidy;

    public Player player;

    public float timer = 0.0f;
    public float velocityX, velocityY;
    public float Rotation;
    public bool BattleTurn = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        switch (wolfystaty)
        {
            case WolfyStates.Idle:

                if((int)timer % 20 == 0)
                {
                    wolfystaty = WolfyStates.Walking;

                    if(((int)timer / 4)% 2 == 0)
                    {
                        Rotation = (((int)timer / 4) % 360) * -1;
                    }
                    else
                    {
                        Rotation = (((int)timer /4) % 360);
                    }
                }
                this.transform.rotation.Set(Rotation, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
                //timer = 0;
                break;

            case WolfyStates.Walking:

                if ((int)timer % 20 != 0)
                {
                    SlimeyRigidy.AddForce(new Vector3(velocityX, 0, 0));

                    /*if (isHumanNearby())
                    {
                        wolfystaty = WolfyStates.Charging;
                    }*/
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

    /*bool isHumanNearby()
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

    /*f(Vector3.Distance(player.transform.position, this.transform.position) < huntingRadius)
     {
         return true;
     }
     else
     {
         return false;
     }

 }*/

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entering Collision");
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.TryGetComponent<Tomogochi>(out Tomogochi Tomy))
        {
            GameStateMachine.instance.setBattle(Tomy, this);
        }
    }
}
