using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Prefab 
    public GameObject applePrefab;


    //Speed at which the AppleTree 
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Change that the AppleTree will change di
    public float chanceToChangeDirection = 0.1f;

    //Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }


    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
 


        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //right
        }else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //left
        } else if (UnityEngine.Random.value < chanceToChangeDirection){
            speed *= -1; //direction change
        }
        
    }

    void FixedUpdate()
    {
        //Changing Direction Rnadomly is now t

        if(UnityEngine.Random.value < chanceToChangeDirection)
        {
            speed *= -1; //Change direction
        } else if (UnityEngine.Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
    }



}
