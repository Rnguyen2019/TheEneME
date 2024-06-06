using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureMine : MonoBehaviour
{
    private bool captured = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown(){
        transform.Find("Flag").gameObject.SetActive(true);
        if(!captured){
            CoinCreate.captured++;
            captured = true;
        }
    }
}
