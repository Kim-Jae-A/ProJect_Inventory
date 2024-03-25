using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public Canvas inventory;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.enabled = !inventory.enabled;
        }
    }

    public void InventoryClose()
    {
        inventory.enabled = false;
    }
}
