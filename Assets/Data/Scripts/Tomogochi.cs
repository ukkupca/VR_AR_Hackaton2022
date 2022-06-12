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
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Data.Scripts
{
    public class Tomogochi : MonoBehaviour
    {
        public GameObject xrRig = default;
        public NavMeshAgent navMeshAgent = default;
        private int destinationAttempts = 0;

        public string namey;
        [HideInInspector]
        public int HP;
        [HideInInspector]
        public int HPCAP;
        [HideInInspector]
        public int ENERGY;
        [HideInInspector]
        public int ENERGYCAP;
        [HideInInspector]
        public int FOOD;
        [HideInInspector]
        public int FOODCAP;
    
        private int STR;
        private int AGI;
        private int DEF;
    
        [ReadOnly]
        public int LEVEL;
        [HideInInspector]
        public int EXP;
        private int NextLevel;
    
        public TextMeshProUGUI levelNumber;
        public Slider foodSlider;
        public Slider energySlider;
        public Slider hpSlider;
        public Slider expSlider;

        public Image foodColor;
        public Image energyColor;
        public Image hpColor;

        public float ingameTimer = 0;
        float previousTime = 0;

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

            GenerateStartingStats();

            StartCoroutine(FollowPlayer());
        }

        // Update is called once per frame
        void Update()
        {
            previousTime = ingameTimer;
            ingameTimer += Time.deltaTime;
            
            TargetReached();

            switch (currentTomyState)
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

            if (((int)ingameTimer % 100 == 0) && ((int)previousTime != (int)ingameTimer))
            {
                DecreaseFood(5);
            } 
        }

        private void LevelUp()
        {
            LEVEL += 1;
            int nextEXP = (int)Mathf.Pow(2, LEVEL) + 10 * LEVEL;
            NextLevel += nextEXP;

            int randHp = (int)Random.Range(0, 5);
            HP += randHp;
            HPCAP += randHp;

            int randEnergy = (int)Random.Range(0, 5);
            ENERGY += randEnergy;
            ENERGYCAP += randEnergy;

            int randFood = (int)Random.Range(0, 10);
            FOOD += randFood;
            FOODCAP += randFood;

            SetStats(LEVEL, FOOD, FOODCAP, ENERGY, ENERGYCAP, HP, HPCAP, EXP, NextLevel);

            STR += (int)Random.Range(0, 5);
            AGI += (int)Random.Range(0, 5);
            DEF += (int)Random.Range(0, 5);
        }

        void SetStats(int lvl, int food, int foodCap, int energy, int energyCap, int hp, int hpCap, int exp, int expDiff)
        {
            levelNumber.text = lvl.ToString();

            foodSlider.maxValue = foodCap;
            foodSlider.value = food;

            foodColor.color = food > foodCap/2 ? Color.green : Color.red;

            energySlider.maxValue = energyCap;
            energySlider.value = energy;
        
            energyColor.color = energy > energyCap/2 ? Color.green : Color.red;

            hpSlider.maxValue = hpCap;
            hpSlider.value = hp;
        
            hpColor.color = hp > hpCap/2 ? Color.green : Color.red;

            expSlider.maxValue = exp + expDiff;
            expSlider.value = exp;
        }

        void GenerateStartingStats()
        {
            LEVEL = 0;
            EXP = 0;
            NextLevel = 213;
        
            HP = 3;
            HPCAP = 12;
        
            ENERGY = 3;
            ENERGYCAP = 30;
        
            FOOD = 40;
            FOODCAP = 60;
            
            SetStats(LEVEL, FOOD, FOODCAP, ENERGY, ENERGYCAP, HP, HPCAP, EXP, NextLevel);

            STR = 3;
            AGI = 2;
            DEF = 3;
        }

        public void IncreaseEnergy(int value)
        {
            if (ENERGY < ENERGYCAP && ENERGY + value <= ENERGYCAP)
            {
                ENERGY += value;
            }
            else
            {
                return;
            }

            SetEnergyStats();
        }
        
        public void DecreaseEnergy(int value)
        {
            if (ENERGY > 0 && ENERGY - value >= 0)
            {
                ENERGY -= value;
            }
            else
            {
                ENERGY = 0;
            }

            SetEnergyStats();
        }

        private void SetEnergyStats()
        {
            energySlider.value = ENERGY;
            energyColor.color = ENERGY > ENERGYCAP/2 ? Color.green : Color.red;
        }
        
        public void IncreaseFood(int value)
        {
            if (FOOD < FOODCAP && FOOD + value <= FOODCAP)
            {
                FOOD += value;
            }
            else
            {
                return;
            }

            SetFoodStats();
        }
        
        public void DecreaseFood(int value)
        {
            if (FOOD > 0 && FOOD - value >= 0)
            {
                FOOD -= value;
            }
            else
            {
                FOOD = 0;
            }

            SetFoodStats();
        }

        private void SetFoodStats()
        {
            foodSlider.value = FOOD;
            foodColor.color = FOOD > FOODCAP/2 ? Color.green : Color.red;
        }
        
        public void IncreaseHp(int value)
        {
            if (HP < HPCAP && HP + value <= HPCAP)
            {
                HP += value;
            }
            else
            {
                return;
            }

            SetHpStats();
        }
        
        public void DecreaseHp(int value)
        {
            if (HP > 0 && HP - value >= 0)
            {
                HP -= value;
            }
            else
            {
                HP = 0;
            }

            SetHpStats();
        }

        private void SetHpStats()
        {
            hpSlider.value = HP;
            hpColor.color = HP > HPCAP/2 ? Color.green : Color.red;
        }
        
        public void AddExp(int value)
        {
            int expCap = EXP + NextLevel;
            if (EXP < expCap && EXP + value < expCap)
            {
                EXP += value;
                hpSlider.value = EXP;
            }
            
            if (EXP + value >= expCap)
            {
                EXP += value;
                LevelUp();
            }
        }

        private IEnumerator FollowPlayer()
        {
            while (xrRig != null)
            {
                navMeshAgent.isStopped = false;
                SetDestination();
                yield return new WaitForSeconds(1f);
            }

            yield return null;
        }

        private void SetDestination()
        {
            Vector3 playerToEnemy = xrRig.transform.position - transform.position;

            Vector3 destination = xrRig.transform.position;

            NavMeshPath path = new NavMeshPath();
            navMeshAgent.CalculatePath(destination, path);
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                destinationAttempts = 0;
                navMeshAgent.SetDestination(destination);
            }
            else
            {
                if (destinationAttempts == 10)
                {
                    //Debug.LogError("Destination " + destination.ToString() + "was not reachable for " + gameObject.name + " 10 times!");
                    return;
                }

                destinationAttempts++;
                //Debug.LogWarning("Destination " + destination.ToString() + " was not reachable for " + gameObject.name);

                SetDestination();
            }
        }

        private bool TargetReached()
        {
            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= 1f)
                {
                    navMeshAgent.isStopped = true;
                }
            }

            return false;
        }
    }
}
