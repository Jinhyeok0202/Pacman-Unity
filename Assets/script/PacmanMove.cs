using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PacmanMove : MonoBehaviour
{

    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    

    void Start()
    {
        dest = transform.position;
    }

    void FixedUpdate()
    {
        Vector2 direction = new Vector2();
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = direction * speed;

        //Animation Parameters
        GetComponent<Animator>().SetFloat("DirX", direction.x);
        GetComponent<Animator>().SetFloat("DirY", direction.y);
    }
}
