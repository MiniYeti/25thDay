using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    public float fadeInTime;
    

    public Image blackScreen;
    


    // Use this for initialization
    void Start () {
        
       blackScreen = GetComponent<Image>();
       blackScreen.CrossFadeAlpha(0f, fadeInTime, false);
       





    }

    // Update is called once per frame
    void Update () {
        if (blackScreen.color.a == 0)
        {
            gameObject.SetActive(false);
        }
    }

    

  

        

}
