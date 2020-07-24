using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class rbCharecterController : MonoBehaviour
{
    #region gameObjects
    public Rigidbody2D rb;
    #endregion

    #region settings
    public float walkSpeed = 0f;
    public float sprintSpeed = 0f;
    #endregion

    #region tools
    private float speed;
    #endregion

    #region Input
    public KeyCode forward = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode back = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode sprint = KeyCode.LeftShift;
    #endregion


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        speed = walkSpeed;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        #region Input Manager
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        #endregion

        #region Movement
        float translation = v * speed * Time.deltaTime;
        float straffe = h * speed * Time.deltaTime;
        transform.Translate(straffe, translation, 0);
        #endregion


        #region Sprint
        if (Input.GetKey(sprint))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        #endregion

    }
}
