using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditManage : MonoBehaviour
{
    //PlayerAction inputAction;

    public Camera mainCam;
    public Camera editorCam;

    // public GameObject prefab1;
    // public GameObject prefab2;

    // GameObject item;
    PlayerController tempController;

    public bool editorMode = false;
    //bool instantiated = false;

    // Start is called before the first frame update
    void Awake()
    {
        //inputAction = PlayerController.instance.inputAction;

        //inputAction.Editor.EnableEdit.performed += cntxt => SwitchCamera();

        mainCam.enabled = true;
        editorCam.enabled = false;

    }

    private void SwitchCamera()
    {
        mainCam.enabled = !mainCam.enabled;
        editorCam.enabled = !editorCam.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCam.enabled == false && editorCam.enabled == true)
        {
            editorMode = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            editorMode = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}