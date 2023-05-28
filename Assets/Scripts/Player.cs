using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;

    public float blockingStart = 0.15f;
    private float unblocking;

    public Text healthDisplay;
    public int health = 5;

    public GameObject panel;
    public GameObject SpawnAsteroid;
    public GameObject ScoreManager;
    private void Update()
    {
        healthDisplay.text = health.ToString();
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W) & transform.position.y < maxHeight & unblocking <= 0)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            unblocking = blockingStart;       
        }
        else if (Input.GetKeyDown(KeyCode.S) & transform.position.y > minHeight & unblocking <= 0)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            unblocking = blockingStart;       
        }
        unblocking -= Time.deltaTime;
        if (health == 0)
        {
            Destroy(gameObject);
            panel.SetActive(true);
            SpawnAsteroid.SetActive(false);
            ScoreManager.SetActive(false);
        }
    }  
    public void DamageOnPlayer(int damageonplayer)
    {
        health -= damageonplayer;
    }
}
