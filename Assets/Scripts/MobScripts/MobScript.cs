using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MobScript : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamage;

    private Transform target;
    public int speed;

    public float cooldown;
    private float timer = 0;

    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        target = GameObject.Find("Player").transform;
        /*if (PlayerMovement.targets[0] != null){
            if(PlayerMovement.targets[0].gameObject.GetComponent<MineDamage>() != null){
                PlayerMovement.targets.Insert(0,gameObject);
            }
            else{
                PlayerMovement.targets.Add(gameObject);
            }
        }
        if (PlayerMovement.targets[0] == null){
            PlayerMovement.targets.Add(gameObject);
        }*/
        PlayerMovement.targets.Insert(0,gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null){
            gameObject.transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
    }
    }

    public void damaged(int damage){
        enemyHealth -= damage;
        if (enemyHealth <= 0){
            Destroy(this.transform.gameObject);
            PlayerMovement.targets.RemoveAt(0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerDamage>() != null){
            timer += Time.deltaTime;
            if (timer >= cooldown){
                other.gameObject.GetComponent<PlayerDamage>().damaged(enemyDamage);
                timer = 0;
            }
        }
    }

    public void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Handles.Label(transform.position, enemyHealth.ToString());
    }
}
