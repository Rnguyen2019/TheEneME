using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMine : MonoBehaviour
{
    public new BoxCollider2D collider;

    public GameObject mines;
    public Transform mineParent;

    public int numMines;
    // Start is called before the first frame update
    void Start()
    {
        int width = (int)collider.bounds.size.x;
        int height = (int)collider.bounds.size.y;

        for (int i = 0; i < numMines; i++){
            int randNum1 = Random.Range(-(width / 2 - 1), width / 2 - 1);
            int randNum2 = Random.Range(-(height / 2 - 1), height / 2 - 1);
            Instantiate(mines, new Vector3(randNum1, randNum2, 0), Quaternion.Euler(0, 0, 0),mineParent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(collider.transform.position, new Vector2(collider.bounds.size.x, collider.bounds.size.y) );
    }
}
