using UnityEngine;

public class Obstacles : MonoBehaviour
{
    Spider spider;
    float speed;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        spider = player.GetComponent<Spider>();
        speed = 1f;
    }

    void Update()
    {
        speed += 0.01f * Time.deltaTime;
        if (speed > 2f)
            speed = 2f;

        if (spider.isDead)
            return;
        transform.position += new Vector3(speed * -2.5f * Time.deltaTime, 0, 0);
    }
}
