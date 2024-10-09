using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private void OnMouseOver()
    {
        CoreGame.instance.gameManager.ActiveCursor(this.gameObject);
    }

    private void OnMouseExit()
    {
        CoreGame.instance.gameManager.DisableCursor();
    }

    private void OnHit()
    {
        CoreGame.instance.gameManager.DisableCursor();
        Destroy(this.gameObject);
    }
}
