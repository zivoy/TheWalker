using System.Collections;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public GameObject Object;

    void Start()
    {
        Object.SetActive(false);
    }


    void OnTriggerEnter()
    {
        Object.SetActive(true);
        StartCoroutine(WaitForSec());
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(Object);
    }
}