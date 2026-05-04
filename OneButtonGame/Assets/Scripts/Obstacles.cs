using UnityEngine;

public class Obstacles : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(-0.005f, 0, 0);
    }
}
