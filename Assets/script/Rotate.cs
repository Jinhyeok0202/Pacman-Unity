using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float Speed = 30f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Vector3.forward * Speed * Time.deltaTime);
    }
}
