using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{



    float ingameTimer = 0;

    public enum mainGameStates
    {
        MainMenu,
        Playing,
        Crafting,
        Battle,
        GameOver
    }

    public enum DayNight
    {
        Day,
        Night
    }

    mainGameStates gameStatesy;

    DayNight dayLight;

    // Start is called before the first frame update
    void Start()
    {
        gameStatesy = mainGameStates.MainMenu;
        dayLight = DayNight.Day;
    }

    // Update is called once per frame
    void Update()
    {
        ingameTimer += Time.deltaTime;

        if(ingameTimer % 10000 == 0)
        {
            // Daytime
            dayLight = DayNight.Day;
        }
        else
        {
            if (ingameTimer % 5000 == 0)
            {
                // NightTime
                dayLight = DayNight.Night;
            }
        }

        switch(dayLight)
        {
            case DayNight.Day:

                break;

            case DayNight.Night:

                break;
        }

    }

}
