using UnityEngine;

public class Web : MonoBehaviour
{
    Spider spider;
    SpriteRenderer sr;
    public bool spriteEnabled = true;

    void Start()
    {
        spider = GetComponentInParent<Spider>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.enabled = spriteEnabled;

        if (spider.attached)
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("snap web");
        spider.attached = false;
        spriteEnabled = false;
    }

}
