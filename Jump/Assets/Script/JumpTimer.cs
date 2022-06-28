using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class JumpTimer : MonoBehaviour
{
    public static float timer;
    //public Text jumpTimer; 
    Image fillTimer;

    // Start is called before the first frame update
    void Start()
    {
        fillTimer = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        fillTimer.fillAmount = timer*.5f ;
        
        
    }
}
