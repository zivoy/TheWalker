using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public NotificationManager noteManager;
    public GameObject Object;
    [NonSerialized] public bool isShown = true;
    private bool shown;

    void Start()
    {
        Object.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        noteManager.UpdateNotification(this);
    }

    public void Show()
    {
        if (shown) return;
        Object.SetActive(true);
        isShown = true;
        shown = true;
    }

    public void Hide()
    {
        Object.SetActive(false);
        isShown = false;
    }

    void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitForSec());
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Hide();
    }
}