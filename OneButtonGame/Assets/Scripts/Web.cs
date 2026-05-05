using UnityEngine;
using FMODUnity;

public class Web : MonoBehaviour
{
    Spider spider;
    SpriteRenderer sr;
    public bool spriteEnabled = true;

    StudioEventEmitter emitter;
    public float parameter = 1;

    void Start()
    {
        spider = GetComponentInParent<Spider>();
        sr = GetComponent<SpriteRenderer>();

        emitter = GetComponent<StudioEventEmitter>();
    }


    private void Update()
    {
        sr.enabled = spriteEnabled;

        if (spider.attached == true)
        {
            emitter.SetParameter("Skateboard", 1);
        } 
        else if (spider.attached == false)
        {
            emitter.SetParameter("Skateboard", 0);
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        UnityEngine.Debug.Log("snap web");
        spider.attached = false;
        spriteEnabled = false;
    }

}
