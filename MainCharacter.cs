using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    public float speed = 20f;
    public Vector3 motion;
    private Vector3 local;
    private Rigidbody RBody;
    Vector3 velocity;
    [SerializeField]
    private GameObject PlayerCylinder;
    private Renderer playerRenderer;
    private bool IsGrounded;
    private Color newPlayerColour;
    private Color colour;


    void Start()
    {
        RBody = GetComponent<Rigidbody>();
        RBody.isKinematic = false;
        playerRenderer = PlayerCylinder.GetComponent<Renderer>();
        ChangePlayerColour();
    }

    private void Update()
    {
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        RBody.velocity = motion * speed;
    }

    private void ChangePlayerColour()
    {
        int Level = SceneManager.GetActiveScene().buildIndex;
        if (Level == 0)
        {
            colour = new Color(255, 0, 0, 1f);
            local = new Vector3(1.90f, 1.90f, 1.90f);

        }
        else if (Level == 1)
        {
            colour = new Color(255, 0, 255, 1f);
            local = new Vector3(2.10f, 2.10f, 2.10f);
        }
        else if (Level == 2)
        {
            colour = new Color(0, 0, 255, 1f);
            local = new Vector3(2.30f, 2.30f, 2.30f);
        }
        playerRenderer.material.SetColor("_Color", colour);
        playerRenderer.transform.localScale = local;
    }

}

