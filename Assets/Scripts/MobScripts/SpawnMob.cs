using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnMob : MonoBehaviour
{
    public GameObject[] mob;
    public Transform mobParent;

    public float cooldown;
    private float timer = 0;

    private int cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(ClickType.clicktype != 0){
            cost = mob[ClickType.clicktype - 1].gameObject.GetComponent<MobScript>().cost;
        }
        if (Input.GetMouseButton(1) && timer >= cooldown && CoinCreate.coinageCount >= cost && ClickType.clicktype != 0){
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            Instantiate(mob[ClickType.clicktype - 1], mouseWorldPos, new Quaternion(0,0,0,0), mobParent);
            timer = 0;
            CoinCreate.coinageCount -= cost;
            gameObject.GetComponent<CoinCreate>().UpdateCoinCount(0);
        }
    }
}
