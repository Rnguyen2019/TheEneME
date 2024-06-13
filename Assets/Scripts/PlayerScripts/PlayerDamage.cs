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

    public static int kills = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if (other.gameObject.GetComponent<MobScript>() != null && other.gameObject == PlayerMovement.targets[0]){
            timer += Time.deltaTime;
            if (timer >= cooldown){
                other.gameObject.GetComponent<MobScript>().damaged(playerDamage);
                timer = 0;
            }
        }
        if (other.gameObject.GetComponent<MineDamage>() != null){
            timer += Time.deltaTime;
            if (timer >= cooldown){
                other.gameObject.GetComponent<MineDamage>().damaged(playerDamage);
                timer = 0;
            }
        }
    }

    public void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Handles.Label(transform.position, playerHealth.ToString());
    }
}
