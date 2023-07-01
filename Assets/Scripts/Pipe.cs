using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private GameManager gameManager;

    public float speed = 4;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
