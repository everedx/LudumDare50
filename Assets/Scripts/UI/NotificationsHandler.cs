using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationsHandler : MonoBehaviour
{
    [SerializeField] GameObject notificationPrefab;
    [SerializeField] Transform canvasObject;

    public static NotificationsHandler instance { get; protected set; }

    public static bool instanceExists
    {
        get { return instance != null; }
    }

    private void Awake()
    {
        if (instanceExists)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }


    public void ShowNotification(string text)
    {
        GameObject notifInstance = Instantiate(notificationPrefab, canvasObject);
        notifInstance.GetComponent<Notificator>().SetNotifText(text);
    }
}
