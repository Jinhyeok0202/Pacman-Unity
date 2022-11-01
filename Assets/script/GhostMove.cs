using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GhostMove : MonoBehaviour
{
    [SerializeField]
    private GameObject gameover;

    public Transform[] waypoints;
    int cur = 0;

    public float speed = 0.3f;

    void Start()
    {
        gameover.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector2 direction = (waypoints[cur].position - transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * speed;

        float distance = Vector2.Distance(transform.position, waypoints[cur].position);
        if (distance <= 0.1f)
        {
            cur = (cur + 1) % waypoints.Length;
        }

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            Destroy(co.gameObject);
            gameover.SetActive(true);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i < waypoints.Length; ++i)
        {
            Transform prevWay = i == 0 ? transform : waypoints[i - 1];
            Transform currentWay = waypoints[i];

            Gizmos.DrawLine(prevWay.position, currentWay.position);
        }
    }
}
