using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CaptureMine : MonoBehaviour
{
    public bool captured = false;
    public static bool mouseDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.targets.Count == 0 && captured){
            PlayerMovement.targets.Add(gameObject);
        }
    }

    void OnMouseDown(){
        mouseDown = true;
        if(ClickType.clicktype == 0 || 1 == 1){
            transform.Find("Flag").gameObject.SetActive(true);
            if(!captured){
                CoinCreate.captured++;
                captured = true;
            }
        }
    }

    void OnMouseUp(){
        mouseDown = false;
    }
}
