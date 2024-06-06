using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int playerHealth = 10;
    public int playerDamage = 10;

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
        //Debug.Log("" + timer);
    }

    public void damaged(int damage){
        playerHealth -= damage;
        if (playerHealth <= 0){
            Destroy(this.transform.gameObject);
            Debug.Log("nice");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("" + other.gameObject.name);
        if (timer >= cooldown){
            other.GetComponent<MobScript>().damaged(playerDamage);
            timer = 0;
        }
    }

    public void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Handles.Label(transform.position, playerHealth.ToString());
    }
}
