using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public Transform target;
    public float destroyDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if(target.position.x - transform.position.x >= destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
