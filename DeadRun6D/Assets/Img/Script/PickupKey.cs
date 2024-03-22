using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    public AudioSource JumpS;
    public GameObject jumpface;
    public GameObject PText;
 

    void Start()
    {
        PText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            PText.SetActive(true);

            if (Input.GetKey(KeyCode.F)) 
            {
                PText.SetActive(false);
                jumpface.SetActive(true);
                StartCoroutine(DisImg());
                JumpS.Play();
             
                this.GetComponent<BoxCollider>().enabled = false;
               
                
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PText.SetActive(false);
    }
    
    IEnumerator DisImg()
    { 
        yield return new WaitForSeconds(1);
        jumpface.SetActive(false);
        this.gameObject.SetActive(false);
        PText.SetActive(false);
    }
   
}
