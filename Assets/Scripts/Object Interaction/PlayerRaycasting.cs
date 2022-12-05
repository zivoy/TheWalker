using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToSee;
    RaycastHit whatIHit;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        if(Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {
            if (Input.GetKeyDown (KeyCode.E))
            {
                Debug.Log ("Interacted with" +whatIHit.collider.gameObject.name);
                if(whatIHit.collider.tag == "ShipPart")
                {
                    if(whatIHit.collider.gameObject.GetComponent<ShipPart>().whatPartAmI)
                    {
                        Destroy (whatIHit.collider.gameObject);
                    }
                }
            }
        }
    }
}
