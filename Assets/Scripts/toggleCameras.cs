using UnityEngine;

public class toggleCameras : MonoBehaviour
{
    public Camera cameraObj; 
    public MonoBehaviour firstPersonScript; 
    public MonoBehaviour thirdPersonScript;
    public KeyCode toggleKey = KeyCode.F5;
    public string playerLayer = "Player";
    
    private bool _firstPerson = true;
    private int maskBit;

    void updateScripts()
    {
        firstPersonScript.enabled = _firstPerson;
        thirdPersonScript.enabled = !_firstPerson;

        if (_firstPerson) cameraObj.cullingMask &= ~maskBit;
        else cameraObj.cullingMask |= maskBit;
    }    
    
    void Start()
    {
        maskBit = 1 << LayerMask.NameToLayer(playerLayer);
        updateScripts();
    }

    void Update()
    {
        if (!Input.GetKeyDown(toggleKey)) return;
        
        _firstPerson = !_firstPerson;
        updateScripts();
    }
}
