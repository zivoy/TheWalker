using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToSee;
    RaycastHit whatIHit;
    public Inventory playerInventory;

    void Start()
    {
        playerInventory = gameObject.GetComponentInParent<Inventory>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * distanceToSee, Color.magenta);

        if (!Physics.Raycast(transform.position, transform.forward, out whatIHit, distanceToSee)) return;
        
        if (!Input.GetKeyDown(KeyCode.E)) return;

        Debug.Log("Interacted with" + whatIHit.collider.gameObject.name);
        if (whatIHit.collider.tag == "Keys")
        {
            switch (whatIHit.collider.gameObject.GetComponent<KeyManager>().whatKeyAmI)
            {
                case KeyManager.Keys.redKey:
                    playerInventory.hasRedKey = true;
                    Destroy(whatIHit.collider.gameObject);
                    break;
                case KeyManager.Keys.blueKey:
                    playerInventory.hasBlueKey = true;
                    Destroy(whatIHit.collider.gameObject);
                    break;
                case KeyManager.Keys.greenKey:
                    playerInventory.hasGreenKey = true;
                    Destroy(whatIHit.collider.gameObject);
                    break;
            }
        }

        if (whatIHit.collider.tag == "Doors")
        {
            switch (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI)
            {
                case DoorManager.Doors.redDoor:
                    if (!playerInventory.hasRedKey)
                    {
                        Debug.Log("Find the Red Key");
                        return;
                    }

                    playerInventory.hasRedKey = false;
                    Destroy(whatIHit.collider.gameObject);
                    break;
                case DoorManager.Doors.blueDoor:
                    if (!playerInventory.hasBlueKey)
                    {
                        Debug.Log("Find the Blue Key");
                        return;
                    }

                    playerInventory.hasBlueKey = false;
                    Destroy(whatIHit.collider.gameObject);
                    break;
                case DoorManager.Doors.greenDoor:
                    if (!playerInventory.hasGreenKey)
                    {
                        Debug.Log("Find the Green Key");
                        return;
                    }

                    playerInventory.hasGreenKey = false;
                    Destroy(whatIHit.collider.gameObject);
                    break;
            }
        }
    }
}