using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    Animation drawBow;
    Animator idleBow;
    private bool isDraw = false;
    public Rigidbody arrow;
    public Transform bow;
    Rigidbody clone;

	void Start () {
        drawBow = GetComponent<Animation>();
        idleBow = GetComponent<Animator>();
        drawBow["Draw"].layer = 1;
        drawBow["Draw"].wrapMode = WrapMode.Once;
        drawBow["pullBowClip"].wrapMode = WrapMode.Once;
	}
	
	void Update () {

        if(Input.GetButton("Fire1") == false)
        {
            drawBow.Stop();
            drawBow.Play("IdleBow");
            isDraw = false;
        }

	    if(Input.GetButton("Fire1") && isDraw == false)
        {
            clone = Instantiate( arrow, transform.position, transform.rotation ) as Rigidbody;
            drawBow.Play( "pullBowClip" );
            drawBow.Play("Draw");
            isDraw = true;
        }

        else if(!Input.GetButton("Fire1") && isDraw == true)
        {
            drawBow.Play("IdleBow");
            clone.AddForce( transform.forward * 100 );
            idleBow.SetTrigger( "stopFire" );
            isDraw = false;
        }
	}
}