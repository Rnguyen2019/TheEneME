using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MineDamage : MonoBehaviour
{
    public int mineHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damaged(int damage){
        mineHealth -= damage;
        if (mineHealth <= 0){
            Destroy(this.transform.gameObject);
            CoinCreate.captured--;
            PlayerMovement.targets.RemoveAt(0);
        }
    }

    public void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Handles.Label(transform.position, mineHealth.ToString());
    }
}
