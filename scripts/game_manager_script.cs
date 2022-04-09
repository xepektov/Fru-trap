using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class game_manager_script : MonoBehaviour
{
    // red  -> 0
    // blue -> 1
    // yellow -> 2

    public bool is_paused , is_gameover , win ;
    Vector3 last_position;

    public int current_trap_colour;
    public int current_no_of_traps;
    public int max_traps;
    public int total_keys;
    public int keys_left;

    public bool all_keys_found;

    public GameObject[] traps;
    public GameObject hat;
    public GameObject created_trap;

    public GameObject ui;
    public Label key_text;
    public Label trap_text , menu_text;

    public Button resume_button , mainmenu_button , quit_button , tutorial_button;
    public VisualElement game_menu , heart;
    public AudioSource button_click;
 //   public int game_life = 1;

    //public IMGUIContainer img;
    public string[] colour_ui= { "red" , "blue" ,"yellow"};



    // Start is called before the first frame update
    void Start()
    {

        button_click.playOnAwake = false;

        last_position = hat.transform.position;


        is_gameover=false;
        is_paused = false;
        max_traps = 2;
        keys_left = 5;
        total_keys=5;
        current_no_of_traps=0;
        current_trap_colour=-1;
        all_keys_found=false;

        var root = ui.GetComponent<UIDocument>().rootVisualElement;
        key_text = root.Q<Label>("keys_left_label");
        trap_text = root.Q<Label>("traps_label");
        



        game_menu = root.Q<VisualElement>("pausemenu");
        heart = root.Q<VisualElement>("heart");

        game_menu.style.display = DisplayStyle.None;
        heart.style.display = DisplayStyle.Flex;

        resume_button = root.Q<Button>("resume_button");
        tutorial_button = root.Q<Button>("tutorial_button");
        mainmenu_button = root.Q<Button>("mainmenu_button");
        quit_button = root.Q<Button>("quit_button");
        menu_text = root.Q<Label>("heading_label");

        resume_button.clicked += resume_pressed;
        tutorial_button.clicked += tutorial_pressed;
        mainmenu_button.clicked += mainmenu_pressed;
        quit_button.clicked += quit_pressed;

       
        key_text.text = "Keys left : " + keys_left.ToString() + "/" + total_keys.ToString();
        trap_text.text = "traps : " + current_no_of_traps.ToString() + "/" + max_traps.ToString();
        menu_text.text = "PAUSE";

        
        // Time.timeScale = 0f;
        // game_menu.style.display = DisplayStyle.Flex;
        // Time.timeScale = 1f;
        // game_menu.style.display = DisplayStyle.None;

        Time.timeScale = 1f;

        
    }

    // Update is called once per frame
    void Update()
    {

        if(keys_left==0){
            all_keys_found=true;
        }



        if(Input.GetKeyDown(KeyCode.Q)  && (is_gameover==false)){
            Debug.Log("no. of traps left :"+current_no_of_traps);
            Debug.Log("gg");
            if(current_no_of_traps>=1){
                Debug.Log("no. of traps left :"+current_no_of_traps);
                Debug.Log("hh");
                created_trap =  Instantiate (traps[current_trap_colour] , hat.transform.position, Quaternion.identity) as GameObject;
                created_trap.GetComponent<trap_script>().colour = current_trap_colour;
                hat.GetComponent<hat_sound_script>().trap_laid();

                current_no_of_traps--;
                Debug.Log("no. of traps left :"+current_no_of_traps);
                trap_text.text = "traps : " + current_no_of_traps.ToString() + "/" + max_traps.ToString() + " ( " + colour_ui[current_trap_colour] + " )";
            }

        }

        if(  Input.GetKeyDown(KeyCode.Escape) && (is_gameover==false)  ){
            if(is_paused){
                Time.timeScale = 1f;
                game_menu.style.display = DisplayStyle.None;
                is_paused=false;
            }

            else{

                Time.timeScale = 0f;
                game_menu.style.display = DisplayStyle.Flex;
                is_paused=true;
            }

        }

        if(is_gameover){
            
            menu_text.text = "GAME OVER";
            resume_button.text = "Restart";
            game_menu.style.display = DisplayStyle.Flex;
        }

        if(win){
            
            menu_text.text = "YOU WIN !";
            resume_button.text = "Restart";
            game_menu.style.display = DisplayStyle.Flex;
            Time.timeScale = 0f;
        }


    }

    public void fruit_eaten(int colour){
        Debug.Log("max traps : "+max_traps);
        current_trap_colour = colour;
        current_no_of_traps = 2;
        Debug.Log("no. of traps left :"+current_no_of_traps);
        Debug.Log("colours of traps :"+current_trap_colour);

        trap_text.text = "traps : " + current_no_of_traps.ToString() + "/" + max_traps.ToString() + " ( " + colour_ui[current_trap_colour] + " )";
        //img.style.backgroundImage= trap_images[current_trap_colour];
    }

    public void key_taken(){
        keys_left--;
        last_position = hat.transform.position;

        if(keys_left==0){
            all_keys_found=true;
        }

        key_text.text = "Keys left : " + keys_left.ToString() + "/" + total_keys.ToString();
    }

    
    void resume_pressed(){
        button_click.Play();

        if((is_gameover) || (win)){
            //is_gameover=true;
            SceneManager.LoadScene("SampleScene");
        }
        else {
            Time.timeScale = 1f;
            game_menu.style.display = DisplayStyle.None;
        }
        
    }

    void tutorial_pressed(){
        button_click.Play();
        SceneManager.LoadScene("tutorial_scene");
    }

    void mainmenu_pressed(){
        button_click.Play();
        SceneManager.LoadScene("mainmenuscene");
    }

    void quit_pressed(){
        button_click.Play();
        Application.Quit();
    }

    public void near_door(){
        if(all_keys_found){
            win =true;
        }
    }

    public void give_me_life(){
        StartCoroutine("get_life_back");
        heart.style.display = DisplayStyle.None;
    }
    
    private IEnumerator get_life_back(){

        yield return new WaitForSeconds(2f);
        hat.gameObject.SetActive(true);
        hat.transform.position = last_position;
        hat.GetComponent<wizard_movement>().life = 0;
        
        

    }

}
