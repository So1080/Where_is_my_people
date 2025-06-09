using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    Vector3 startPos_cylinder;
    public Transform transform_cylinder;
    public float speed = 10.0f;
    private Animator animator;
    Rigidbody rb;
    private bool canMove = true;

    [Header("UI")]
    public GameObject eye_green;
    public GameObject nose_green;
    public GameObject hair_green;
    public GameObject eye_orange;
    public GameObject nose_orange;
    public GameObject hair_orange;

    public GameObject Entity1Check;
    public GameObject Entity2Check;
    public GameObject Entity3Check;
    public GameObject Entity4Check;
    public GameObject Entity5Check;
    public GameObject Entity6Check;
    public GameObject Ask;
    public GameObject Take;

    public GameObject Entity1Scan;
    private bool entity1visited = false;
    private bool entity2visited = false;
    private bool entity3visited = false;
    private bool entity4visited = false;
    private bool entity5visited = false;
    private bool entity6visited = false;

    private bool visitedHuman1 = false;
    private bool visitedHuman2 = false;
    private bool visitedHuman3 = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }
     
    private void Awake()
    {
        startPos_cylinder = transform_cylinder.position;

    }
    // Update is called once per frame
    private void Update()
    {
        //MoveLeftRight();
        // MoveForwardBack();
        // MoveRotate();

        MoveForwardBackAndRotate();

        // MoveFB();
        // MoveLR();
        Turn();

        if (Input.GetKeyDown(KeyCode.Return)){
            Debug.Log(true);
            Resume();
            canMove = true;
            if (Ask.activeSelf == true){
                Ask.SetActive(false);
                Resume(); 
                if (SceneManager.GetActiveScene().name == "Stage2"){
                    SceneManager.LoadScene(13);

                }
                // to do : make it so if we are at Stage 2 then it loads the scene but if not then don't load it
                // SceneManager.LoadScene(13);               
            }

            if (Take.activeSelf == true){   
                if (SceneManager.GetActiveScene().name == "Stage3"){
                    SceneManager.LoadScene(24);
                } 

                if (SceneManager.GetActiveScene().name == "Stage4"){
                    SceneManager.LoadScene(46);
                }           
            }

            // if (Entity1Check.activeSelf == true){
            //     Entity1Scan.SetActive(true);
            //     Entity1Check.SetActive(false);
            //     if (entity4visited == false){
            //         eye_orange.SetActive(true);
            //         eye_green.SetActive(false);
            //     } else {
            //         //eye_orange.SetActive(false);
            //         //eye_green.SetActive(true);
            //         hair_green.SetActive(true);
            //     }
                
            // }
            // if (Entity2Check.activeSelf == true){
            //     Entity2Check.SetActive(false);
            //     if (entity5visited == false){
            //         nose_orange.SetActive(true);
            //         nose_green.SetActive(false);
            //     } else {
            //         nose_orange.SetActive(false);
            //         nose_green.SetActive(true);
            //     }
            // }
            // if (Entity3Check.activeSelf == true){
            //     Entity3Check.SetActive(false);
            //     if (entity6visited == false){
            //         hair_orange.SetActive(true);
            //         hair_green.SetActive(false);
            //     } else {
            //         hair_orange.SetActive(false);
            //         hair_green.SetActive(true);
            //     }
            // }
            // if (Entity4Check.activeSelf == true){
            //     Entity4Check.SetActive(false);
            //     if (entity1visited == false){
            //         eye_orange.SetActive(true);
            //         eye_green.SetActive(false);
            //     } else {
            //         eye_orange.SetActive(false);
            //         eye_green.SetActive(true);
            //     }
            // }
            // if (Entity5Check.activeSelf == true){
            //     Entity5Check.SetActive(false);
            //     if (entity2visited == false){
            //         nose_orange.SetActive(true);
            //         nose_green.SetActive(false);
            //     } else {
            //         nose_orange.SetActive(false);
            //         nose_green.SetActive(true);
            //     }
            // }
            // if (Entity6Check.activeSelf == true){
            //     Entity6Check.SetActive(false);
            //     if (entity3visited == false){
            //         hair_orange.SetActive(true);
            //         hair_green.SetActive(false);
            //     } else {
            //         hair_orange.SetActive(false);
            //         hair_green.SetActive(true);
            //     }
            // }

            if ((entity1visited == true) && (entity2visited == true) && (entity3visited == true) && (entity4visited == true) && (entity5visited == true) && (entity6visited == true)) {
                SceneManager.LoadScene(4);
            }

            if (Input.GetKeyDown(KeyCode.G)){
                SceneManager.LoadScene(4);
            }
        }
    }

    

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Entity"))
        {
            if (collision.gameObject.name == "Human1" && visitedHuman1 == false)
            {
                visitedHuman1 = true;
                Debug.Log("true human 1");
                print("true human 1");
                canMove = false;

                // Stop Human1's movement
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                Ask.SetActive(true);
                Pause();
                Invoke("Resume", 2f);
            }

            if (collision.gameObject.name == "Human2" && visitedHuman2 == false)
            {
                visitedHuman2 = true;
                Debug.Log("true human 2");
                print("true human 2");
                canMove = false;

                // Stop Human1's movement
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                Ask.SetActive(true);
                Pause();
                Invoke("Resume", 2f);
            }


            if (collision.gameObject.name == "Human3")
            {
                if (SceneManager.GetActiveScene().name == "Stage3"){
                    Debug.Log("true human 4");
                    print("true human 4");
                    canMove = false;

                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;

                    Take.SetActive(true);
                    Pause();
                }

                if (SceneManager.GetActiveScene().name == "Stage4"){
                    visitedHuman3 = true;
                    Debug.Log("true human 3");
                    print("true human 3");
                    canMove = false;

                    // Stop Human1's movement
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;

                    Ask.SetActive(true);
                    Pause();
                    Invoke("Resume", 2f);
                }
            }

            if (collision.gameObject.name == "Human4")
            {
                Debug.Log("true human 4");
                print("true human 4");
                canMove = false;

                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                Take.SetActive(true);
                Pause();
            }

            // if ((collision.gameObject.name == "Entity1") && (this.entity1visited == false)){
            //     Debug.Log(true);
            //     print("true 1");
            //     this.entity1visited = true;
            //     //Destroy(collision.GameObject);
            //     canMove = false;
                
            //     Entity1Check.SetActive(true);
            //     Pause();
            //     Destroy(collision.gameObject);
            // }

            // if ((collision.gameObject.name == "Entity2") && (this.entity2visited == false)){
            //     Debug.Log(true);
            //     print("true 2");
            //     this.entity2visited = true;
            //     //Destroy(collision.GameObject);
            //     canMove = false;
                
            //     Entity2Check.SetActive(true);
            //     Pause();
            //     Destroy(collision.gameObject);
            // }

            // if ((collision.gameObject.name == "Entity3") && (this.entity3visited == false)){
                
            //     this.entity3visited = true;
            //     canMove = false;               
            //     Entity3Check.SetActive(true);
            //     Pause();
            //     Destroy(collision.gameObject);
            // }

            // if ((collision.gameObject.name == "Entity4") && (this.entity4visited == false)){
                
            //     this.entity4visited = true;
            //     canMove = false;               
            //     Entity4Check.SetActive(true);
            //     Pause();
            //     Destroy(collision.gameObject);
            // }

            // if ((collision.gameObject.name == "Entity5") && (this.entity5visited == false)){
                
            //     this.entity5visited = true;
            //     canMove = false;               
            //     Entity5Check.SetActive(true);
            //     Pause();
            //     Destroy(collision.gameObject);
            // }

            // if ((collision.gameObject.name == "Entity6") && (this.entity6visited == false)){
                
            //     this.entity6visited = true;
            //     canMove = false;               
            //     Entity6Check.SetActive(true);
            //     Pause();
            //     Destroy(collision.gameObject);
            // }
            
        }

    }

    private void Pause()
    {
        Time.timeScale = 0; // Stop time
        Debug.Log("Game Paused");
    }

    private void Resume()
    {
        Time.timeScale = 1; // Resume time
        Debug.Log("Game Resumed");
    }

    

    // Note : faire Horizontal et Vertical en meme temps pour avanver -> pour tourner utiliser z et c par exemple.
    // Donc trois fonctions : une pour avancer/reculer, une pour tourner et une pour avancer et tourner en meme temps

    void MoveFB()
    {
        // Ensure you have a Rigidbody component attached
        Rigidbody rb = transform_cylinder.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the cylinder!");
            return;
        }

        // Input for movement (forward/backward)
        float moveInputF = Input.GetAxis("Vertical");
        Debug.Log(moveInputF);

        // Calculate forward movement
        // Vector3 forwardMovementF = transform_cylinder.transform.forward * moveInputF * 15.0f;
        Vector3 forwardMovementF = rb.transform.forward * moveInputF * speed;
        //Vector3 forwardMovement = rb.transform.forward * moveInput * 10.0f;
        // Debug.Log(forwardMovementF);

        // Apply movement using Rigidbody velocity
        rb.linearVelocity = new Vector3(forwardMovementF.x, rb.linearVelocity.y, forwardMovementF.z);
        // Debug.Log(rb.linearVelocity);

        // Update animator's ForwardSpeed parameter for visualization
        animator.SetFloat("ForwardSpeed", Mathf.Abs(moveInputF));
    }

    void MoveLR()
    {
        // Ensure you have a Rigidbody component attached
        Rigidbody rb = transform_cylinder.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the cylinder!");
            return;
        }

        // Input for move and rotating (left/right)
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate side movement
        Vector3 forwardMovement = rb.transform.right * moveInput * speed;

        // transform.Rotate(Vector3.forwardMovement, 200.0f * Time.deltaTime, Space.Self);
        // transform.Translate(Vector3.forwardMovement * 10 * Time.deltaTime, Space.World);

        // Apply movement using Rigidbody velocity
        // rb.linearVelocity = new Vector3(forwardMovement.x, rb.linearVelocity.y, forwardMovement.z);
        // float rotationSpeed = moveInput * 200.0f; // Rotation speed
        // Quaternion deltaRotation = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        // rb.MoveRotation(rb.rotation * deltaRotation);

        // Update animator's ForwardSpeed parameter for visualization
        animator.SetFloat("ForwardSpeed", Mathf.Abs(moveInput));
    }

    void Turn()
    {
        // Ensure you have a Rigidbody component attached
        Rigidbody rb = transform_cylinder.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the cylinder!");
            return;
        }

        // Input for rotation (left/right)
        float rotateInput = Input.GetAxis("Rotate");

        // Calculate rotation
        float rotationSpeed = rotateInput * 100.0f; // Rotation speed
        Quaternion deltaRotation = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void MoveForwardBackAndRotate()
    {
        // Ensure you have a Rigidbody component attached
        Rigidbody rb = transform_cylinder.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the cylinder!");
            return;
        }

        // Input for movement (forward/backward)
        float moveInput = Input.GetAxis("Vertical");
        //Debug.Log(moveInput);

        // Input for rotation (left/right)
        float rotateInput = Input.GetAxis("Horizontal");

        // Apply rotation
        float rotationSpeed = rotateInput * 200.0f; // Rotation speed
        Quaternion deltaRotation = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Calculate forward movement in the current forward direction of the Rigidbody
        Vector3 forwardMovement = rb.transform.forward * moveInput * speed;

        // Apply forward movement using Rigidbody velocity
        rb.linearVelocity = new Vector3(forwardMovement.x, rb.linearVelocity.y, forwardMovement.z);

        // Update animator's ForwardSpeed parameter for visualization
        if (animator != null)
        {
            animator.SetFloat("ForwardSpeed", Mathf.Abs(moveInput));

            // Reset ForwardSpeed to 0 if there is no movement input
            if (Mathf.Approximately(moveInput, 0f))
            {
                animator.SetFloat("ForwardSpeed", 0f);
            }
        }
    }

































    //////////////////////////////////////////////////
    // POUBELLE

    void MoveForwardBackAndRotate2()
    {
        // Ensure you have a Rigidbody component attached
        Rigidbody rb = transform_cylinder.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the cylinder!");
            return;
        }

        // Input for movement (forward/backward)
        float moveInput = Input.GetAxis("Vertical");

        // Input for rotation (left/right)
        float rotateInput = Input.GetAxis("Horizontal");

        // Calculate forward movement
        Vector3 forwardMovement = transform_cylinder.transform.forward * moveInput * 15.0f;

        // Apply movement using Rigidbody velocity
        rb.linearVelocity = new Vector3(forwardMovement.x, rb.linearVelocity.y, forwardMovement.z);

        // Calculate rotation
        float rotationSpeed = rotateInput * 150.0f;

        // Apply rotation using Rigidbody
        Quaternion deltaRotation = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Update animator's ForwardSpeed parameter for movement visualization
        animator.SetFloat("ForwardSpeed", Mathf.Abs(moveInput));
    }

    void MoveForwardBack()
    {
        // Ensure you have a Rigidbody component attached
        Rigidbody rb = transform_cylinder.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the cylinder!");
            return;
        }

        // Get input for movement
        Vector3 vec_forward = Vector3.zero;
        vec_forward.z = Input.GetAxis("Vertical");

        // Calculate movement direction in local space
        Vector3 movement = transform_cylinder.TransformDirection(vec_forward) * 15.0f;

        // Apply force to the Rigidbody
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // Update animator's ForwardSpeed parameter
        animator.SetFloat("ForwardSpeed", Mathf.Abs(vec_forward.z));
    }


    void MoveRotate()
    {
        Vector3 vec_rotate = Vector3.zero;
        vec_rotate.y = Input.GetAxis("Rotate");
        Vector3 v = new Vector3(0.0f, vec_rotate.y, 0.0f) * Time.deltaTime * 15.0f;
        transform_cylinder.Rotate(v, Space.Self);
        //animator.SetFloat("ForwardSpeed", Vector3.Magnitude(rb.linearVelocity));
    }




    void MoveForwardBack2()
    {
        Vector3 vec_forward = Vector3.zero;
        vec_forward.z = Input.GetAxis("Vertical");
        Vector3 v = new Vector3(0.0f, 0.0f, vec_forward.z) * Time.deltaTime * 15.0f;
        //transform_cylinder.Translate(v, Space.Self);
        transform_cylinder.position += transform_cylinder.TransformDirection(v);
        //animator.SetFloat("ForwardSpeed", Vector3.Magnitude(rb.linearVelocity)*1000000);
        animator.SetFloat("ForwardSpeed",Mathf.Abs(vec_forward.z));
        //Debug.Log(vec_forward.z);
    }


    void MoveLeftRight()
    {
        // Ensure you have a Rigidbody component attached
        Rigidbody rb = transform_cylinder.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the cylinder!");
            return;
        }

        // Get input for rotation
        float rotateInput = Input.GetAxis("Horizontal");

        // Calculate rotation speed
        float rotationSpeed = rotateInput * 150.0f;

        // Apply rotation using Rigidbody
        Quaternion deltaRotation = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Update animator's parameter (if needed)
        animator.SetFloat("ForwardSpeed", Mathf.Abs(rotateInput));
    } 

    void MoveLeftRight4()
    {
        Vector3 vec_rotate = Vector3.zero;
        vec_rotate.y = Input.GetAxis("Horizontal");
        Vector3 v = new Vector3(0.0f, vec_rotate.y, 0.0f) * Time.deltaTime * 150.0f;
        transform_cylinder.Rotate(v, Space.Self);
        //animator.SetFloat("ForwardSpeed", Vector3.Magnitude(rb.linearVelocity));

        // Ensure you have a Rigidbody component attached
        Rigidbody rb = transform_cylinder.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the cylinder!");
            return;
        }

        // Get input for movement
        Vector3 vec_forward = Vector3.zero;
        vec_forward.y = Input.GetAxis("Horizontal");

        // Calculate movement direction in local space
        Vector3 movement = transform_cylinder.TransformDirection(vec_forward) * 15.0f;

        // Apply force to the Rigidbody
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // Update animator's ForwardSpeed parameter
        animator.SetFloat("ForwardSpeed", Mathf.Abs(vec_forward.y));
    }  

    void MoveLeftRight2()
    {
        Vector3 vec_left = Vector3.zero;
        vec_left.x = Input.GetAxis("Horizontal");
        Vector3 v = new Vector3(vec_left.x, 0.0f, 0.0f) * Time.deltaTime * 15.0f;
        //transform_cylinder.Translate(v, Space.Self);
        transform_cylinder.position += transform_cylinder.TransformDirection(v);
        //animator.SetFloat("ForwardSpeed", Vector3.Magnitude(rb.linearVelocity)*1000000);
        //Debug.Log(Vector3.Magnitude(rb.linearVelocity)*1000000);
        animator.SetFloat("ForwardSpeed", Mathf.Abs(vec_left.x));
        Debug.Log(vec_left.x);
    }

    void MoveLeftRight3()
    {
        Vector3 vec_rotate = Vector3.zero;
        vec_rotate.y = Input.GetAxis("Horizontal");
        Vector3 v = new Vector3(0.0f, vec_rotate.y, 0.0f) * Time.deltaTime * 150.0f;
        transform_cylinder.Rotate(v, Space.Self);
        //animator.SetFloat("ForwardSpeed", Vector3.Magnitude(rb.linearVelocity));
    }

}
