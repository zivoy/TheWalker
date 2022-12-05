using System;
using System.Collections;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public GameObject Object;

    void Start()
    {
        Object.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        Object.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitForSec());
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(Object);
    }
}