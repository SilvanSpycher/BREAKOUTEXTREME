﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    [SerializeField] private float chanceIncrease;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject block;
    [SerializeField] private LevelBuilder levelBuilder;
    [SerializeField] private Paddle paddle;


    public static GameManager instance = null;
    private float powerUpChance = 0f;
    private int powerid;
    public float orthographicSize = 5;
    public float aspect = 1.33333f;

    // Use this for initialization
    void Start ()
    {
        //Camera.main.projectionMatrix = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, camera.nearClipPlane, camera.farClipPlane);
      
        BuildLevel(1);
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {

        }

        DontDestroyOnLoad(gameObject);
    }

    public void Delete(GameObject obj)
    {
        Destroy(obj.gameObject);
    }

    public void DeleteBall(Ball ball)
    {
        Destroy(ball.gameObject);
    }

    public void TouchBlock(Block block)
    {
        block.OnHit();
    }

    public void BlockDestroyed(Vector3 blockposition)
    {
        powerUpChance += chanceIncrease;
        if(Random.Range(0f, 1f) < powerUpChance)
        {
            GameObject newPowerUp = Instantiate(powerUp) as GameObject;
            blockposition.z = -0.5f;
            newPowerUp.transform.position = blockposition;
            newPowerUp.SendMessage("TheStart", powerid);
            powerUpChance = 0;
        }
    }
    
    public void PowerActivate(int power)
    {
        switch (power)
        {
            case 1:         //paddle bigger
                paddle.grow();
                break;
            case 2:         //paddle smaller

                break;
            case 3:         //3 balls

                break;
            case 4:         //ball faster

                break;
            case 5:         //ball slower

                break;
            case 6:         //ball sticks to paddle

                break;
            case 7:         //ball destroys blocks without bouncing

                break;
            case 8:         //ball bigger

                break;
            case 9:         //ball smaller

                break;
            case 10:        //rockets from paddle

                break;
            case 11:        //+1 life

                break;
            case 12:        //bullettime

                break;      

        }
    }

    private void BuildLevel(int levelnumber)
    {
        levelBuilder.BuildLevel(levelnumber);
    }
}
