using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_script : MonoBehaviour
{
    public int colour;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "trap";
        Debug.Log("colour of trap : "+colour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
