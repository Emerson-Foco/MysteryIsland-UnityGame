using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMouse : MonoBehaviour
{
    public bool update = false;
    // Update is called once per frame
    void Update()
    {
        if (update == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            update = true;
        }
    }

    public void ContinuePaper()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }
}
