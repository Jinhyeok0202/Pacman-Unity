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
            // �� ����
            Destroy(door);

            // ��Ȧ SetActive(true)
            blackhole.SetActive(true);

            // ���µ���üũ X
            isOpen = true;
        }
    }
}
