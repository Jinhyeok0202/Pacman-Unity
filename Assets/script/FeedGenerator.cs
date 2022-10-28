using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

[System.Serializable]
public enum FeedGenerateDirection
{
    Up,
    Down,
    Right,
    Left,
}

public class FeedGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject feedPrefab;
    [SerializeField]
    private float interval = 0.1f;
    [SerializeField]
    private FeedGenerateDirection[] directions;

    // Start is called before the first frame update
    void Start()
    {
        foreach (FeedGenerateDirection direction in directions)
        {
            switch (direction)
            {
                case FeedGenerateDirection.Up:
                    CreateFeedLineA(Vector3.up);
                    break;
                case FeedGenerateDirection.Down:
                    CreateFeedLineA(Vector3.down);
                    break;
                case FeedGenerateDirection.Right:
                    CreateFeedLineA(Vector3.right);
                    break;
                case FeedGenerateDirection.Left:
                    CreateFeedLineA(Vector3.left);
                    break;
            }
        }

        CreateFeed(transform.position);
    }

    void CreateFeedLineA(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

        float currentDistance = interval;

        while (true)
        {
            Vector3 nextPosition = transform.position + (direction * currentDistance);
            float nextDistance = Vector2.Distance(transform.position, nextPosition);

            if (nextDistance > hit.distance)
            {
                break;
            }

            CreateFeed(nextPosition);

            currentDistance += interval;
        }
    }

    void CreateFeed(Vector3 pos)
    {
        Instantiate(feedPrefab, pos, transform.rotation, transform);
    }
}
