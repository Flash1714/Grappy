using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShift : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x - transform.position.x >= 50)
        {
            transform.position = new Vector2(transform.position.x + 50, transform.position.y);
        }
    }
}
