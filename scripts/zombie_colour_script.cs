using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class zombie_colour_script : MonoBehaviour
{

    public int colour;
    public AudioSource growl;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
     //   Debug.Log("hit");

        if(other.tag == "trap"){
            if(other.GetComponent<trap_script>().colour == colour){

                growl.Play();
                gameObject.SetActive(false);
                Destroy(other.gameObject);


            }
            
        }
    }
}
