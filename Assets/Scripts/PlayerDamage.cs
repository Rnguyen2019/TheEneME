using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int playerHealth = 10;
    public int playerDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damaged(int damage){
        playerHealth -= damage;
        if (playerHealth <= 0){
            Destroy(this.transform.gameObject);
            Debug.Log("nice");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<MobScript>().damaged(playerDamage);
    }

    public void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Handles.Label(transform.position, playerHealth.ToString());
    }
}
