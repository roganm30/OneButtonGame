using UnityEngine;

public class SBMOVER : MonoBehaviour
{
    public GameObject skateboard;
    GameObject player;
    Spider spider;

    void Start()
    {
        player = GameObject.Find("Player");
        spider = player.GetComponent<Spider>();
    }

    void Update()
    {
        skateboard.SetActive(spider.attached);
        transform.position = new Vector3(player.transform.position.x, 0, 0);
    }
}
