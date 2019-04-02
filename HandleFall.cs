using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleFall : MonoBehaviour
{
    public Rigidbody player;
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 10, 0);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            player.velocity = new Vector3(0, 0, 0);
        }
    }
}
