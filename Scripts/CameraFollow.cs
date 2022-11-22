using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public GameObject player;

    
    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        ZoomOut();


    }


    public float minZoom = 1f;
    public float maxZoom = 5f;
    public float zoomStep = 0.1f;
    public float smoothness = 0.1f;

    public void ZoomOut()
    {
        StartCoroutine(ZoomOutSmoothly());
    }

    private IEnumerator ZoomOutSmoothly()
    {
        
        WaitForSeconds myWait = new WaitForSeconds(smoothness);
        Camera.main.orthographicSize = minZoom; //you could also comment this line out and just use your current zoomValue... It's just for having a start position for the zoomanimation
        while (Camera.main.orthographicSize < maxZoom)
        {
            Camera.main.orthographicSize += zoomStep * (Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.x)) ; //take your players one for the velocity  
            yield return myWait;
        }
        Camera.main.orthographicSize = maxZoom; //ensure it is exactly set to the maxZoom value after the animation
    }
}
