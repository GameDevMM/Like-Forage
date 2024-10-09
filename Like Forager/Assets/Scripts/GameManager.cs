using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject actionCursor;

    [SerializeField]
    private GameObject interactionObject;

    public void ActiveCursor(GameObject obj)
    {
        actionCursor.transform.position = obj.transform.position;
        actionCursor.SetActive(true);
        interactionObject = obj;
    }

    public void DisableCursor()
    {
        actionCursor.SetActive(false);
        interactionObject = null;
    }

    public void ObjectHit()
    {
        if (interactionObject == null) { return; }
        interactionObject.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
    }
}
