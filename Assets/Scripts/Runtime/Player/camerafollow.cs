using UnityEngine;
public class camerafollow : MonoBehaviour
{
    public Transform player;  
    public Transform stagecenter;      
    private Vector3 initialOffset; 

    public float followSpeed = 5f;
    public float rotationSpeed = 20f;
    public float rotationDuration = 5f;

    public bool isFollowing = true;
    public bool isRotating = false;

    void Start()
    {
        initialOffset = transform.position - player.position;
    }

    void Update()
    {
       if (isFollowing)
        {
            FollowBride();
        }
        else if (isRotating)
        {
            RotateAroundStage();
        }
    }
    void FollowBride()
    {
       transform.position = player.position + initialOffset;
       
    }
    public void StartRotate()
    {
        isFollowing = false;
        isRotating = true;

       
        transform.position = stagecenter.position + new Vector3(0, 3f, -7f); 
        transform.LookAt(player); 
        Invoke(nameof(StopRotate), rotationDuration);
    }
     void RotateAroundStage()
    {
        transform.RotateAround(stagecenter.position, Vector3.up, rotationSpeed * Time.deltaTime);
        transform.LookAt(player); 
    }

    void StopRotate()
    {
        isRotating = false;
    }

}

