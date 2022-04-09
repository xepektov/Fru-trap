using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit_script : MonoBehaviour
{
    // red  -> 0
    // blue -> 1
    // yellow -> 2

    public int colour=0;
    float dist;

    public GameObject hat;
    public GameObject gamemanager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.gameObject.transform.position , hat.transform.position);

        if(dist < 1f){
       //     Debug.Log("dfg");
            if(Input.GetKeyDown("e")){

                gamemanager.GetComponent<game_manager_script>().fruit_eaten(colour);
                hat.GetComponent<hat_sound_script>().eat_sound() ;
                Destroy(this.gameObject);
            }
        }
    }
}
