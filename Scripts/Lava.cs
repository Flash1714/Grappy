using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    
    public Transform target;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().health = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        transform.position = new Vector2(target.position.x, transform.position.y);
    }
}
