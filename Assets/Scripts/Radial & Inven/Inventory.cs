using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InvenPanel;
    public bool invenActive;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Cursor.visible = true;
            invenActive = true;
            if (invenActive)
            {
                InvenPanel.SetActive(true);
            }
            
        }

        else
        {
            invenActive = false;
        }
    }
}
