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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        target = GameObject.Find("Player").transform;
        PlayerMovement.targets.Add(gameObject);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals("Player")){
            other.GetComponent<PlayerDamage>().damaged(enemyDamage);
        }
    }

    public void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Handles.Label(transform.position, enemyHealth.ToString());
    }
}
