using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    EntitySpeed speed;
    Transform direction;

    private void Start()
    {
        speed = GetComponent<EntitySpeed>();
        direction = GetComponent<Transform>();
    }

    private void Update()
    {
       
    }

}
