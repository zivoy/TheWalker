using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{

    ShowText CurrentNotification = null;

    public void UpdateNotification(ShowText notification)
    {
        if (notification == CurrentNotification) return;
        if (CurrentNotification == null || !CurrentNotification.isShown)
        {
            CurrentNotification = notification;
            notification.Show();
            return;
        }

        StartCoroutine(WaitForSec(notification));
    }
    
    IEnumerator WaitForSec(ShowText notification)
    {
        yield return new WaitForSeconds(2);
        CurrentNotification.Hide();
        CurrentNotification = notification;
        notification.Show();
    }
}
