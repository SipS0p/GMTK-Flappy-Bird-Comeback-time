using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{  
    public void LoadMainScene(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
