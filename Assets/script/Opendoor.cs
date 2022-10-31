using UnityEngine;

public class Opendoor : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    [SerializeField]
    private GameObject blackhole;

    private bool isOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
            return;

        int feedCount = GameObject.FindGameObjectsWithTag("Respawn").Length;
        if (feedCount == 0)
        {
            // 문 열고
            Destroy(door);

            // 블랙홀 SetActive(true)
            blackhole.SetActive(true);

            // 오픈도어체크 X
            isOpen = true;
        }
    }
}
