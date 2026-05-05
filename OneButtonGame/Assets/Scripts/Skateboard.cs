using FMODUnity;
using UnityEngine;

public class Skateboard : MonoBehaviour
{
    Spider spider;

    StudioEventEmitter emitter;
    public float parameter = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spider = GetComponentInParent<Spider>();

        emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spider.attached == true)
        {
            emitter.SetParameter("Skateboard", 1);
            Debug.Log("Skateboard");
        }
        else if (spider.attached == false)
        {
            emitter.SetParameter("Skateboard", 0);
        }
    }
}
