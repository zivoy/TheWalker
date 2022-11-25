using UnityEngine;

public class triggerAdjustments : MonoBehaviour
{
    [Tooltip("target for adjusting")]
    public GameObject player;

    private adjustMovement _playerMoveScript;
    
    [Tooltip("Change Player movement gravity")]
    public bool changeGravity = false;
    
    [Tooltip("Value to set the gravity to")]
    public float setGravity;

    
    [Tooltip("Change Player movement speed multiplier")]
    public bool changeSpeed = false;
    
    [Min(.001f), Tooltip("Value to set the speed multiplier to")]
    public float setSpeedMultiplier;
    
    private void Start()
    {
        _playerMoveScript = player.GetComponent<adjustMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null)
        {
            // exit if doesnt have a parent (not the object we are looking for)
            return;
        }
        GameObject otherParent = other.transform.parent.gameObject;

        if (otherParent != player) 
        {
            //Debug.Log(other.gameObject);

            // exit if was not the player colliding
            return;
        }
        //Debug.Log("collided with player");
        
        if (changeSpeed)
        {
            Debug.Log("setting speed multiplier to "+setSpeedMultiplier);
            _playerMoveScript.speedMultiplier = setSpeedMultiplier;
        }
        
        if (changeGravity)
        {
            Debug.Log("setting gravity to "+setGravity);
            _playerMoveScript.gravity = setGravity;
        }
    }
}
