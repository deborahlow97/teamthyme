﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool debug;
    public static bool hasPickedUp;
    public static int level;

    private static GameObject player;
    private static Vector3 playerInitPos;
    private static GameManager Instance;
    private static GameObject timerText;
    private static List<Trap> traps;
    private static GameObject[] trapGameObjects;
    private static GameObject[] disappearPlatforms;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        level = 0;
        player = GameObject.Find("player");
        playerInitPos = player.transform.position;
        timerText = GameObject.Find("TimerText");
        disappearPlatforms = GameObject.FindGameObjectsWithTag("Disappear");
        //traps = FindObjectsOfType(typeof(Trap)) as Trap[];
        trapGameObjects = GameObject.FindGameObjectsWithTag("Trap");
        traps = new List<Trap>();
        Debug.Log(trapGameObjects.Length);
        foreach (GameObject trapGameObject in trapGameObjects) {
            traps.Add(trapGameObject.GetComponent<Trap>());
        }

        Debug.Log(traps);
        initLevel();
        resetTraps();
    }

    private static void initLevel()
    {
        // TODO: move player back to initial position
        player.GetComponent<Transform>().position = playerInitPos;

        // TODO: initialise variables needed for each level
        switch (level)
        {
            case 0:
                Debug.Log("Level 0");
                break;
            case 1:
                Debug.Log("Level 1");
                break;
            case 2:
                Debug.Log("Level 2");
                break;
            case 3:
                Debug.Log("Level 3");
                break;
            case 4:
                Debug.Log("Level 4");
                break;
            case 5:
                Debug.Log("Level 5");
                break;
            case 6:
                Debug.Log("Level 6");
                break;
            case 7:
                Debug.Log("Level 7");
                break;
            case 8:
                Debug.Log("Level 8");
                break;
            case 9:
                Debug.Log("Level 9");
                break;
            case 10:
                Debug.Log("Level 10");
                break;
            case 11:
                Debug.Log("Level 11");
                break;
            case 12:
                Debug.Log("Level 12");
                break;
            default:
                Debug.Log("Not a valid level");
                break;
        }
    }

    public static void restartLevel(bool hasCompletedLevel)
    {
        hasPickedUp = false;
        if (hasCompletedLevel)
        {
            level++;
        }
        resetTraps();
        timerText.GetComponent<Timer>().stopTimer();
        initLevel();
    }

    public static void resetTraps()
    {
        foreach (Trap trap in traps)
        {
            trap.deactivate();
        }
        foreach (GameObject platform in disappearPlatforms)
        {
            platform.SetActive(true);
        }
        
    }

    public static void startTimerCountdown()
    {
        timerText.GetComponent<Timer>().startTimer();
    }

    public static GameManager getInstance()
    {
        return Instance;
    }

}