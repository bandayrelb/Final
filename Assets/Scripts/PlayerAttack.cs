using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    Animation drawBow;
    //Animator bow;
    private bool isDraw = false;

	// Use this for initialization
	void Start () {
        drawBow = GetComponent<Animation>();
        //bow = GetComponent<Animator>();
        drawBow["Draw"].layer = 1;
        drawBow["Draw"].wrapMode = WrapMode.Once;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButton("Fire1") == false)
        {
            drawBow.Stop();
            drawBow.Play("IdleBow");
            isDraw = false;
        }

	    if(Input.GetButton("Fire1") && isDraw == false)
        {
            //bow.SetTrigger( "pull" );
            drawBow.Play("Draw");
            isDraw = true;
        }

        else if(!Input.GetButton("Fire1") && isDraw == true)
        {
            //bow.SetTrigger( "release" );
            drawBow.Play("IdleBow");
            isDraw = false;
        }
	}
}
