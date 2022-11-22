using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int point = 1;
    public GameObject pointeffect;
    public GameObject pointSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().score += point;
            Instantiate(pointSound, transform.position, Quaternion.identity);
            Instantiate(pointeffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
