using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToSee;
    RaycastHit whatIHit;
    public GameObject player;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        if(Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {
            if (Input.GetKeyDown (KeyCode.E))
            {
                Debug.Log ("Interacted with" +whatIHit.collider.gameObject.name);
                if(whatIHit.collider.tag == "Keys")
                {
                    if(whatIHit.collider.gameObject.GetComponent<KeyManager>().whatKeyAmI == KeyManager.Keys.redKey)
                    {
                        player.GetComponent<Inventory>().hasRedKey = true;
                        Destroy (whatIHit.collider.gameObject);
                    }
                    if(whatIHit.collider.gameObject.GetComponent<KeyManager>().whatKeyAmI == KeyManager.Keys.blueKey)
                    {
                        player.GetComponent<Inventory>().hasBlueKey = true;
                        Destroy (whatIHit.collider.gameObject);
                    }
                    if(whatIHit.collider.gameObject.GetComponent<KeyManager>().whatKeyAmI == KeyManager.Keys.greenKey)
                    {
                        player.GetComponent<Inventory>().hasGreenKey = true;
                        Destroy (whatIHit.collider.gameObject);
                    }
                }
                if(whatIHit.collider.tag == "Doors")
                {
                    if(whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.redDoor)
                    {
                        if(player.GetComponent<Inventory>().hasRedKey == true)
                        {
                            player.GetComponent<Inventory>().hasRedKey = false;
                            Destroy (whatIHit.collider.gameObject);
                        }
                        else
                        {
                            Debug.Log ("Find the Red Key");
                        }
                    }
                    if(whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.blueDoor)
                    {
                        if(player.GetComponent<Inventory>().hasBlueKey == true)
                        {
                            player.GetComponent<Inventory>().hasBlueKey = false;
                            Destroy (whatIHit.collider.gameObject);
                        }
                        else
                        {
                            Debug.Log ("Find the Blue Key");
                        }
                    }
                    if(whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.greenDoor)
                    {
                        if(player.GetComponent<Inventory>().hasGreenKey == true)
                        {
                            player.GetComponent<Inventory>().hasGreenKey = false;
                            Destroy (whatIHit.collider.gameObject);
                        }
                        else
                        {
                            Debug.Log ("Find the Green Key");
                        }
                    }
                }
            }
        }
    }
}
