using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperMovement : MonoBehaviour {

	public float speed = 4f;
	public float gravity = 0.981f;
	public float jumpVel = 2f;
	public float rotation = 0f;
	public int dustPause = 10;
	public GameObject dust;
	public LayerMask layerMask;
    public Camera cameraMain;
    public Camera cameraCombat;
    public SpriteRenderer sprite;
    public Animator animator;

    private Vector3 moveDir = Vector3.zero;
	private CharacterController contr;
	private int dustTimer;
	private float yVel;
    private bool motionFrozen = false;

	//Parent, but not really.
	//private Component pControl;

	// Use this for initialization
	void Awake () {
		contr = GetComponent<CharacterController>();
		//sprite = GetComponent<SpriteRenderer> ();
		dustTimer = dustPause;
		yVel = 0;

        cameraMain.enabled = true;
        cameraCombat.enabled = false;
    }

	void FixedUpdate () {

		int gCount = groundedCount ();

        if (!motionFrozen)
        {

            getBelow();
            moveDir.z = Input.GetAxisRaw("Vertical");
            moveDir.x = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Velocity", Mathf.Abs(moveDir.x) + Mathf.Abs(moveDir.z));
            Debug.Log("Velocity = " + animator.GetFloat("Velocity"));

            if (gCount > 1 && (moveDir.x != 0 || moveDir.z != 0) && dustTimer > dustPause)
            {
                Object.Instantiate(dust, transform.position - new Vector3(0, 0.5f, -0.1f), new Quaternion());
                dustTimer = 0;
            }
            else
            {
                dustTimer = dustTimer + 1;
            }

            moveDir.Normalize();
            moveDir = moveDir * speed;

            if (gCount > 1)
            {
                yVel = -0.1f;
            }
            else if (gCount == 1)
            {
                yVel = 0;
            }
            else
            {
                yVel = yVel - gravity;
                //enterCombat();
            }

            moveDir.y = yVel;
            if(moveDir.x > 0)
            {
                sprite.flipX = false;
            }
            else if(moveDir.x < 0)
            {
                sprite.flipX = true;
            }

            contr.Move(moveDir);

            //transform.localRotation.Set(0, 0, 0, 0);
        }
        else
        {
            //Do the Combat thing!
        }
	}

	void Jump () {
		moveDir.y = jumpVel;
	}

	bool getBelow() {
		RaycastHit hit;

		if(Physics.Raycast(transform.position + new Vector3(0,0,0), transform.TransformDirection(Vector3.down), out hit, 1)) {
			transform.SetParent(hit.transform);
            
			return true;
		} else {
		    transform.SetParent(null);
            return false;
		}
	}

	int groundedCount() {
		//layerMask = ~layerMask;
		int count = 0;

		Debug.DrawRay(transform.position + new Vector3(0,0,0), transform.TransformDirection(Vector3.down), Color.green);

		if (Physics.Raycast (transform.position + new Vector3 (0.2f, 0, 0), transform.TransformDirection (Vector3.down), 0.7f, layerMask)) {
			count++;
		}
		if (Physics.Raycast (transform.position + new Vector3 (-0.2f, 0, 0), transform.TransformDirection (Vector3.down), 0.7f, layerMask)) {
			count++;
		}
		if (Physics.Raycast (transform.position + new Vector3 (0, 0, 0.2f), transform.TransformDirection (Vector3.down), 0.7f, layerMask)) {
			count++;
		}
		if (Physics.Raycast (transform.position + new Vector3 (0, 0, -0.2f), transform.TransformDirection (Vector3.down), 0.7f, layerMask)) {
			count++;
		}

		return count;
	}

    void enterCombat()
    {
        freezeMotion();

        cameraMain.enabled = false;
        cameraCombat.enabled = true;

        //More Combat Stuff! YAY!
    }

    public void freezeMotion()
    {
        motionFrozen = true;
    }

    public void unFreezeMotion()
    {
        motionFrozen = false;
    }

    public bool isFrozenMotion()
    {
        return motionFrozen;
    }

}
