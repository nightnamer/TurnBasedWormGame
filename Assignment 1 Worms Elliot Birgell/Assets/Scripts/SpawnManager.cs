using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Image winnerImage;
    [SerializeField] private NumberOfPlayers _players;
    
    private CameraController _cameraScript;
    private CinemachineVirtualCamera _cmCam;
    private InputHandler _input;
    [SerializeField] private GameObject[] spawnPoint;

    public PlayerController playerPrefab;
    public List<PlayerController> playerList;
    public int playerAmount;
    public int currentPlayer;
    private void Awake()
    {
        //Set amount of players from NumberOfPlayers script
        playerAmount = _players.players;
        
        //Set list
        playerList = new List<PlayerController>();

        //Get access to scripts
        _cameraScript = FindObjectOfType<CameraController>().GetComponent<CameraController>();
        _cmCam = FindObjectOfType<CinemachineVirtualCamera>().GetComponent<CinemachineVirtualCamera>();
       
    }

    void Start()
    {
        //Create the players
        for (int i = 0; i < playerAmount; i++)
        {

            PlayerController newplayer = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //playerList[i] = Instantiate(playerPrefab, new Vector3(0+r_x, 5, 0+r_y), Quaternion.identity);
            
            //Turn off events
            newplayer.GetComponent<InputHandler>().enabled = false;
            newplayer.GetComponent<PlayerController>().plrControl = false;
            //Assign sprites
            newplayer.transform.GetChild(2+i).GetComponent<SpriteRenderer>().enabled = true;
            newplayer.transform.GetChild(2+i).GetComponent<Billboard>().enabled = true;
            newplayer.transform.GetChild(2+i).GetComponent<Billboard>()._camera = Camera.main;
            
            //Spawn points
            newplayer.transform.position = spawnPoint[i].transform.position;
            playerList.Add(newplayer);
        }
        //Start with player 1
        playerList[currentPlayer].GetComponent<InputHandler>().enabled = true;
        playerList[currentPlayer].GetComponent<PlayerController>().plrControl = true;
        //Assign camera to players
        _cameraScript.followObject = playerList[currentPlayer].transform.GetChild(0).transform;
        _cmCam.Follow = _cameraScript.followObject;
    }

    private void UpdateToNewPlayer(int previousPlayer)
    {
        //Update camera to new player
        _cameraScript.followObject = playerList[currentPlayer].transform.GetChild(0).transform;
        _cmCam.Follow = _cameraScript.followObject;

        //Reset previous player
        var previousPlayerController = playerList[previousPlayer].GetComponent<PlayerController>(); //Set previous var
        previousPlayerController.plrControl = false; //Turn off plrControl
        playerList[previousPlayer].GetComponent<PlayerDistanceCheck>().previousLocation = playerList[previousPlayer].transform.position; //set new previous position
        playerList[previousPlayer].GetComponent<InputHandler>().enabled = false; //Turn off input handler
        
        //Update to new player
        var currentPlayerController = playerList[currentPlayer].GetComponent<PlayerController>();
        currentPlayerController.plrControl = true;
        playerList[currentPlayer].GetComponent<InputHandler>().enabled = true;
    }

    public void NextPlayer()
    {
        if (currentPlayer >= playerAmount-1)
        {
            currentPlayer = 0;
            UpdateToNewPlayer(playerAmount-1);
        }
        else
        {
            currentPlayer += 1;
            UpdateToNewPlayer(currentPlayer-1);
        }
    }

    private void Update()
    {
        if (playerList.Count <= 1)
        {
            if (playerList[currentPlayer] != playerList[0])
            {
                UpdateToNewPlayer(0);
            }
            winnerImage.enabled = true;
            _cmCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = 3;
            _cmCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        }
    }
}
