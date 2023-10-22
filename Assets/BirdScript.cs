using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private Camera camera;
    private SpriteRenderer spriteRend;
    public SoundManagerScript soundMgr;

    public Transform wingJoint;
    public GameObject wings;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.showHighScore();
        spriteRend = GetComponent<SpriteRenderer>();
        wings = Instantiate(wings, wingJoint.position, wingJoint.rotation);
        camera = Camera.main;
        soundMgr = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        wings.transform.position = wingJoint.position;
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            soundMgr.PlaySound("wingFlap");
            myRigidBody2D.velocity = Vector2.up * flapStrength;
        }
        if(birdIsAlive)
        {
            HasBirdFallenOffScreen();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
    private void HasBirdFallenOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        if (screenPosition.y < 0 && !GetComponent<Renderer>().isVisible)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
        else if(screenPosition.y > camera.pixelHeight && !GetComponent<Renderer>().isVisible && myRigidBody2D.velocity.y > 0)
        {
            myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, 0);
        }
    }
}
