using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpringJoint2D grappler;
    public LayerMask whatIsGrappleable;
    private LineRenderer lr;
    private Vector2 grapplePoint;
    public GameObject grappleSound;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        grappler = gameObject.AddComponent<SpringJoint2D>();
        grappler.autoConfigureDistance = false;
        grappler.enableCollision = true;
        grappler.enabled = false;

        grappler.dampingRatio = 1f;
        grappler.frequency = 1.2f;
    }
    private void Update()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        drawRope();
        if (Input.GetMouseButtonDown(0))
            {
                StartGrapple();
                Instantiate(grappleSound, transform.position, Quaternion.identity);
                
            }
    
        if (Input.GetMouseButtonUp(0))
            {
                StopGrapple();
            }

    }

    
    private void StartGrapple()
    {
        if (grappler.enabled) return;

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(origin: transform.position, direction: dir, distance: 200, whatIsGrappleable);
        
        if (!hit.collider) return;

        grapplePoint = hit.collider.transform.position;

        print(hit.collider.gameObject.name);
        grappler.connectedBody = hit.collider.attachedRigidbody;
        grappler.distance = hit.distance * 0.6f;

        grappler.enabled = true;
    }
    
    private void StopGrapple()
    {
        if (!grappler.enabled) return;

        grappler.enabled = false;

    }

    private void drawRope()
    {
        lr.enabled = grappler.enabled;

        if(!lr.enabled) return;

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, grapplePoint);

    }

    

}