using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{

    public static GameStateMachine instance;

    public AudioSource Music;

    public AudioClip DayMusic;
    public AudioClip NightMusic;
    public AudioClip BattleMusic;
    public AudioClip PanicMusic;

    public float ingameTimer = 0;
    float previousTime = 0;

    bool InitMusic = true;

    public enum mainGameStates
    {
        MainMenu,
        Playing,
        Crafting,
        Battle,
        GameOver
    }

    public enum BattleActions
    {
        Attack,
        Guard,
        Item,
        Run
    }

    public enum DayNight
    {
        Day,
        Night
    }

    mainGameStates gameStatesy;

    DayNight dayLight;

    BattleActions battyActiony;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        gameStatesy = mainGameStates.MainMenu;
        dayLight = DayNight.Day;
    }

    // Update is called once per frame
    void Update()
    {
        previousTime = ingameTimer;
        ingameTimer += Time.deltaTime;
        if(InitMusic)
        {
            ingameTimer -=3;
            InitMusic = false;
        }

        if(((int)ingameTimer % 100 == 0) && ((int)previousTime != (int)ingameTimer))
        {
            // Daytime
            if (dayLight != DayNight.Day)
            {
                dayLight = DayNight.Day;
                Music.PlayOneShot(DayMusic);
            }
            else
            {
                dayLight = DayNight.Night;
                Music.PlayOneShot(NightMusic);
            }


        }

        switch(dayLight)
        {
            case DayNight.Day:
                
                break;

            case DayNight.Night:
                
                break;
        }

        // State Machine 
        switch (gameStatesy)
        {
            case mainGameStates.MainMenu:

                break;

            case mainGameStates.Playing:

                break;

            case mainGameStates.Battle:

                break;

            case mainGameStates.Crafting:

                break;

            case mainGameStates.GameOver:

                break;
        }


    }

    void Battle(Tomogochi Tomy, Wolfy Enemy)
    {
        // Show GUI


        switch (battyActiony)
        {
            case BattleActions.Attack:

                break;

            case BattleActions.Guard:

                break;

            case BattleActions.Item:

                break;

            case BattleActions.Run:

                break;
        }
    }

    public void setBattle(Tomogochi Tomy, Wolfy Enemy)
    {
        Debug.Log($"Start battle between {Tomy}/ {Enemy}");
    }


}
