using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMessageScript : MonoBehaviour
{
    private float TimeBetweenFlash;
    [SerializeField] TMP_Text TextToFlash;

    // Update is called once per frame
    void Update()
    {
        TimeBetweenFlash -= Time.deltaTime;
        if (TimeBetweenFlash <= 0) 
        {
            Flash();
        }
    }

    void Flash ()
    {
        TimeBetweenFlash = 0.5f;
        if (TextToFlash.gameObject.activeInHierarchy)
        {
            TextToFlash.gameObject.SetActive(false);
        }
        else
        {
            TextToFlash.gameObject.SetActive(true);
        }
    }
}
