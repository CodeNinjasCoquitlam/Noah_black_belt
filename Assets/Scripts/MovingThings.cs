using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingThings : MonoBehaviour
{

    public float amp;
    public float speed;
    public float startPosX;
    public float startPosY;

    void Start()
    {
        startPosX = gameObject.transform.position.x;
        startPosY = gameObject.transform.position.y;
    }

    void Update()
    {
        if (gameObject.tag == "X")
        {
            transform.position = new Vector3((Mathf.Sin(Time.time * speed) * amp) + startPosX, startPosY, 0);
        }

        if (gameObject.tag == "Y")
        {
            transform.position = new Vector3(startPosX, (Mathf.Sin(Time.time * speed) * amp) + startPosY, 0);
        }
    }
}
