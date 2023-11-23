using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] SpawnManager spawnmanager;

    public GameObject player;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject sunLight;

    public TMP_Text timerTxt;

    float dayTimer = 120;       //days last 2 minutes
    bool startDay;   //trigger to set daytimer to 120 (2 mins) at the start of a day
    //float gameTimer;

    int nightCount = 0;

    bool waveWon;           //player killed all the enemies in the wave (groups of 20)
    bool nightWon = false;  //player killed all the enemies

    bool startNight = false;       //things to do only at the start of a night
    float numberOfEnemies = 1;     //the number of enemies for calculation purposes
    float difficulty = 1;          //multiplies numberOfEnemies
    float numEnemiesToSpawn = 0;   //number of enemies to spawn in the night

    bool playerDead;      //player health reached 0
    bool playerWon;       //player survived x days (probably 10)

    enum GameState { Start, Day, Night, GameOver, Win };
    GameState gamestate;

    void Start()
    {
        timerTxt.gameObject.SetActive(false);
        gamestate = GameState.Start;

    }

    void Update()
    {
        switch(gamestate)
        {
            case GameState.Start:                   //would say something like Day 1 and show controls on how to play
                {                                           
                    Debug.Log("Game Started");
                    startDay = true;
                    gamestate = GameState.Day;
                    break;
                }
            case GameState.Day:
                {
                    if (startDay)                               //initialise all day procedures
                    {
                        Debug.Log("Daytime");
                        sunLight.SetActive(true);
                        timerTxt.gameObject.SetActive(true);
                        dayTimer = 60;
                        startDay = false;
                    }

                    dayTimer -= Time.deltaTime;
                    int seconds = Mathf.RoundToInt(dayTimer);
                    timerTxt.text = string.Format("{0:D2}:{1:D2}", (seconds / 60), (seconds % 60));

                    if (dayTimer <= 0)   // or if player sleeps in the house?
                    {
                        nightCount++;
                        startNight = true;
                        gamestate = GameState.Night;
                    }

                    break;
                }
            //===========ALGORITHM===========
            case GameState.Night:             
                {
                    if (startNight)                                            //Initialise night procedures
                    {                                                          
                        Debug.Log("Nighttime");                                
                        timerTxt.gameObject.SetActive(false);  
                        sunLight.SetActive(false);                               
                        numberOfEnemies += nightCount;                         //the main part of the mathematical algorithm, increases wave size as the nights go on
                        numEnemiesToSpawn = numberOfEnemies * difficulty;      //difficulty not implemented
                        nightWon = false;                                      
                        startNight = false;
                    }

                    waveWon = true;                                            //if there are no enemies in the scene the wave has been completed
                    enemies.RemoveAll(s => s == null);
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies[i].activeSelf == true)
                        {
                            waveWon = false;
                        }
                    }

                    if (waveWon)                                               //there's a maximum of 20 enemies in the scene at once
                    {
                        if (numEnemiesToSpawn >= 20)                           //if there are 20 or more enemies to spawn, spawn a wave of 20                 
                        {
                            spawnmanager.SpawnEnemies(20);
                            numEnemiesToSpawn -= 20;
                        }
                        else if (0 < numEnemiesToSpawn && numEnemiesToSpawn < 20) //if there are less than 20, spawn that number
                        {
                            spawnmanager.SpawnEnemies(numEnemiesToSpawn);
                            numEnemiesToSpawn = 0;
                        }
                        else                                                   //else, the night has been completed         
                        {
                            nightWon = true;
                        }
                    }

                    if (nightWon && nightCount == 10)                          //if the player beats night 10, they win
                    {
                        gamestate = GameState.Win;
                    }
                    else if (nightWon)                                         //else, if the player beats any other night it continues to the next day
                    {
                        startDay = true;
                        gamestate = GameState.Day;
                    }

                    break;
                }
            case GameState.GameOver:
                {
                    Debug.Log("GameOver");

                    break;
                }
            case GameState.Win:
                {
                    Debug.Log("You Won");

                    break;
                }
        }
    }
}
