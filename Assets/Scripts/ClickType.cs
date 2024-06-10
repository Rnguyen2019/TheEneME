using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickType : MonoBehaviour
{
    //Camera cam;
    public static int clicktype = 0; 
    GraphicRaycaster raycaster;
    // Start is called before the first frame update
    void Start()
    {
        //cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        this.raycaster = GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //Set up the new Pointer Event
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            pointerData.position = Input.mousePosition;
            this.raycaster.Raycast(pointerData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                GameObject.Find("BlueGuy").GetComponent<Outline>().effectColor = Color.black;
                GameObject.Find("YellowGuy").GetComponent<Outline>().effectColor = Color.black;
                GameObject.Find("WhiteGuy").GetComponent<Outline>().effectColor = Color.black;

                if(result.gameObject.name.Equals("BlueGuy")){
                    if( clicktype != 1){
                        result.gameObject.GetComponent<Outline>().effectColor = Color.yellow;
                        clicktype = 1;
                    }
                    else{
                        result.gameObject.GetComponent<Outline>().effectColor = Color.black;
                        clicktype = 0;
                    }
                }
                if(result.gameObject.name.Equals("YellowGuy")){
                    if( clicktype != 2){
                        result.gameObject.GetComponent<Outline>().effectColor = Color.yellow;
                        clicktype = 2;
                    }
                    else{
                        result.gameObject.GetComponent<Outline>().effectColor = Color.black;
                        clicktype = 0;
                    }
                }
                if(result.gameObject.name.Equals("WhiteGuy")){
                    if( clicktype != 3){
                        result.gameObject.GetComponent<Outline>().effectColor = Color.yellow;
                        clicktype = 3;
                    }
                    else{
                        result.gameObject.GetComponent<Outline>().effectColor = Color.black;
                        clicktype = 0;
                    }
                }
            }
        }
    }
}
