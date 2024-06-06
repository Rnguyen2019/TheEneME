using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCreate : MonoBehaviour
{
    public Text coins;
    public static int coinageCount = 0;
    public static int captured = 0;

    public float cooldown;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown){
            UpdateCoinCount(captured);
            timer = 0;
        }
        coins.text = "" + coinageCount;
    }

    public void UpdateCoinCount(int num)
    {
        coinageCount += num;
    }
}
