using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public int speed;
    public static List<GameObject> targets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //targets.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0){
            if (targets[0] != null){
                gameObject.transform.position = Vector2.MoveTowards(transform.position,targets[0].transform.position, speed * Time.deltaTime);
        }
        }
    }
}
