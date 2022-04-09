using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class wizard_movement : MonoBehaviour
{

  //    public CharacterController hat_controller;
    public Rigidbody rb;

    public float speed = 3;
    public Vector3 move;
    public GameObject gamemanager;
    public AudioSource walk;

    public int life;

    void Start(){

        life = 1;


        this.gameObject.SetActive(true);
        // if(gamemanager.GetComponent<game_manager_script>().game_life == 0){
        //     life = 0;
        // }
    }

    // Update is called once per frame
    void Update()
    {

        

        move.x = Input.GetAxisRaw("Horizontal");
        move.y = 0;
        move.z = Input.GetAxisRaw("Vertical");

        move.Normalize();

        if((Input.GetKeyDown(KeyCode.LeftArrow))||(Input.GetKey(KeyCode.A))){
            transform.rotation = Quaternion.Euler(0,90,0);
            this.gameObject.GetComponent<hat_sound_script>().play = true;
        }

        if((Input.GetKeyDown(KeyCode.RightArrow))||(Input.GetKey(KeyCode.D))){
            transform.rotation = Quaternion.Euler(0,-90,0);
            this.gameObject.GetComponent<hat_sound_script>().play = true;
        }

        if((Input.GetKeyDown(KeyCode.UpArrow))||(Input.GetKey(KeyCode.W))){
            transform.rotation = Quaternion.Euler(0,180,0);
            this.gameObject.GetComponent<hat_sound_script>().play = true;
        }

        if((Input.GetKeyDown(KeyCode.DownArrow))||(Input.GetKey(KeyCode.S))){
            transform.rotation = Quaternion.Euler(0,0,0);
            this.gameObject.GetComponent<hat_sound_script>().play = true;
        }

        if(!( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) ){
            this.gameObject.GetComponent<hat_sound_script>().play = false;
        }

        
    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + (-1*move * speed * Time.fixedDeltaTime) );



    }

    void OnTriggerEnter(Collider other){
        //Debug.Log("hit");

        if(other.tag == "keys"){
            
            gamemanager.GetComponent<game_manager_script>().key_taken();
            this.GetComponent<hat_sound_script>().keys_sound() ;
            Debug.Log("key taken");
            //Destroy(other);
            Destroy(other.gameObject);
            
        }

        else if(other.tag == "zombie"){

            if(life==0){

                gamemanager.GetComponent<game_manager_script>().is_gameover=true;
                this.GetComponent<hat_sound_script>().killed_sound();
                this.gameObject.GetComponent<hat_sound_script>().stop_walking();
            
                this.gameObject.SetActive(false);
                life=0;
            }

            if(life==1){
            
               // gamemanager.GetComponent<game_manager_script>().is_gameover=true;
                this.GetComponent<hat_sound_script>().killed_sound();
                this.gameObject.GetComponent<hat_sound_script>().stop_walking();
            
                
                life=0;

                gamemanager.GetComponent<game_manager_script>().give_me_life();
                this.gameObject.SetActive(false);

            } 

        }
    }

    
}
