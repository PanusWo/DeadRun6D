using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private Camera followCamera;

    [SerializeField] private float rotationSpeed = 10f;

    public static PlayerCon instance;

    public GameObject activeGameObject;
    public GameObject Deadpicture;
    public GameObject Howto;

    public AudioSource PaperS;
    public AudioSource Deadsound;



    public bool isDead;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Howto.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        switch (isDead) 
         {  
            case true:
                Deadpicture.SetActive(true);
                StartCoroutine(DisImg());
                
                break;
            
            case false:
            Movement();

                break;
        }

       


        if (Input.GetKeyDown(KeyCode.E))
        {
            Howto.SetActive(false);
            toggleMap();
            PaperS.Play();
        }

      
      
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0)
       * new Vector3(horizontalInput, 0, verticalInput);

        Vector3 movementDirection = movementInput.normalized;

        controller.Move(movementDirection * playerSpeed * Time.deltaTime);


        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }

    }

    public void toggleMap()
    {


        if (activeGameObject.activeSelf != true)
        {
            activeGameObject.SetActive(true);
        }
        else
        {
            activeGameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hitbox")) 
        { 
            isDead = true;
            Deadsound.Play();
        }
    }

    IEnumerator DisImg()
    {
        yield return new WaitForSeconds(1);
        Deadpicture.SetActive(false);
        
    }

}
