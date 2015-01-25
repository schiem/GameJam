using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardController : Pausable {
	public float speed = 100.0f;
	public Vector3 lastPos;
	public bool swinging;
	public MonoBehaviour textBox;

	/*
	public Vector2 savedVelocity;
	public float savedAngularVelocity;
	*/	
	public AudioClip swingSound;
		
	// Use this for initialization
	void Start () {
		int currentLevel = ((OpenDoor) FindObjectOfType(typeof(OpenDoor))).level;
		
		DescriptionBoxController tbox = (DescriptionBoxController) textBox;
		if(currentLevel == 1) {
			levelOne(tbox);
		} else if (currentLevel == 3) {
			levelThree(tbox);
		} else if (currentLevel == 2) {
			levelTwo(tbox);
		} else if (currentLevel == 4) {
			levelFour (tbox);
		} else if (currentLevel == 5) {
			levelFive (tbox);
		} else if (currentLevel == 7) {
			levelSeven(tbox);
		}	
		
		
	}
	
	void levelOne(DescriptionBoxController tbox) {
		Color red = new Color(171f/255f, 0, 0, 1);
		Color black = new Color(0, 0, 0, 1);
		Queue<string> messages = new Queue<string>(new[] 
		   {"It all started that day on the train. I was standing, waiting. It was a normal day, as normal as it gets. Then it happened.",
			"They all vanished. Everyone! Even my family - they had been right next to me. I had no idea where they had gone, but all that remained was their clothes...",
			"Shirts, pants, wallets, and jewelry all lying there. And there I was in the middle of it all alone. Where had they gone? And why was I still there?",
			"pause",
			"How can this be? Is this a dream?",
			"pause",
			"NO. YOU ARE NOT DREAMING.",
			"Who are you? What is this?",
			"I AM SOVEREIGN.",
			"Sovereign what?",
			"JUST SOVEREIGN. NO LAST NAME. I HAVE COME TO COLLECT THE ENTIRE HUMAN RACE.",
			"To what end!?",
			"MY OWN NEFARIOUS PURPOSES. WHAT ELSE? YOU ARE THE LAST; YOU WILL ALSO BE BROUGHT.",
			"Yeah right! You think I'll let you do that? I'll top you if it's.... well, maybe not the last thing I do. But I will stop you!",
			"And not just that; I'll bring everyone back to this world!",
			"AND SO YOU WILL TRY. BUT ALL OTHERS HAVE FAILED, AND YOU WILL TOO. YOU WILL FIND ONLY SERVILITY AND EVERLASTING DEATH.",
			"Nuts!"});
		Queue<Color> colors = new Queue<Color>(new[] {black, black, black, black, black, black, red, black,
		red, black, red, black, red, black, black, red, black});
		tbox.displayMultipleMessages(messages, colors);
	}
	
	void levelTwo(DescriptionBoxController tbox) {
		Color red = new Color(171f/255f, 0, 0, 1);
		Color black = new Color(0, 0, 0, 1);
			Queue<string> messages = new Queue<string>(new[] {"Nuts."});
			Queue<Color> colors = new Queue<Color>(new[] {black});
			tbox.displayMultipleMessages(messages, colors);
	}
	
	void levelThree(DescriptionBoxController tbox) {
		Color red = new Color(171f/255f, 0, 0, 1);
		Color black = new Color(0, 0, 0, 1);
		
		Queue<string> messages = new Queue<string>(new[] 
		{"So... who are you guys?",
		 "You cannot pass!",
		 "No, seriously... who are you?",
		 "Oh, sorry, speak up. We are the Underlings, servants of Sovereign, and we have orders to bring you back to His Supremacy, the Sovereign!",
		 "Do you see this sword? Out of the way!",
		 "Spoiler alert, you're going to die!",
		 "pause",
		 "Nuts."
		 });
		Queue<Color> colors = new Queue<Color>(new[] {black, red, black, red, black, red, black, black});
		tbox.displayMultipleMessages(messages, colors);
		
	}
	
	void levelFour(DescriptionBoxController tbox) {	
		Color red = new Color(171f/255f, 0, 0, 1);
		Color black = new Color(0, 0, 0, 1);
	   Queue<string> messages = new Queue<string>(new[] 
	   {"Economy class is the worst. Next time I ride business.",
	    "Yikes! That is... somethin' else.",
	    "WHAT!? HOW DID YOU GET IN HERE?",
	    "Who are you? Just let me get through. No one needs to get hurt.",
	    "YEAH, WELL... YOU NEED TO GET HURT.",
	    "Good one. But seriously, who are you?",
		"I AM DIVINITY! I'M BIGGER, TALLER, AND STRONGER THAN YOU!",
		"Well, certainly louder. Also, I'm not seeing a sword.",
		"INSOLENT HUMAN, YOU WILL PAY FOR YOUR IMPUDENCE!",
		"Nuts!"
	   });
		Queue<Color> colors = new Queue<Color>(new[] {black, black, red, black, red, black, red, black, red, black});
		tbox.displayMultipleMessages(messages, colors);
		
	}
	
	void levelFive(DescriptionBoxController tbox) {
		Color red = new Color(171f/255f, 0, 0, 1);
		Color black = new Color(0, 0, 0, 1);
		Queue<string> messages = new Queue<string>(new[] 
		{"Nuts.",
		 "WHAT!? THAT'S IMPOSSIBLE!!!",
		"Didn’t think I’d make it this far, huh?  And I got through all your underwear and that divination guy.",
		"WHAT? YOU DESTROYED ALL OF MY UNDERLINGS AND DIVINITY, MY SON!?",
		"Your son? Ah... this is awkward. But really, I did say I was going to stop you and all.",
		"FOOL! You will pay for this! I will put an end to you once and for al!",
		"But I have a sword!",
		"YEEEEEAAAARRRGGHH!!!",
		});
		Queue<Color> colors = new Queue<Color>(new[] {black, red, black, red, black, red, black, red});
		tbox.displayMultipleMessages(messages, colors);
	}
	
	void levelSeven(DescriptionBoxController tbox) {
		Color red = new Color(171f/255f, 0, 0, 1);
		Color black = new Color(0, 0, 0, 1);
		Queue<string> messages = new Queue<string>(new[] 
		{"    WELCOME TO HELL    "});
		Queue<Color> colors = new Queue<Color>(new[] {red});
		tbox.displayMultipleMessages(messages, colors);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (!paused) {
			Vector2 forcing = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			float current_magnitude = forcing.magnitude;
			if (current_magnitude > 1) {
					float ratio = (1 / current_magnitude);
					forcing.Scale (new Vector2 (ratio, ratio));
			}

		forcing *= speed;

			rigidbody2D.AddForce (forcing);
			UpdateAnimations ();
			UpdateCamera ();
		}

		GetKeys ();
	}
/*
	void showTextBoxAndPause() {
		DescriptionBoxController tbox = (DescriptionBoxController) textBox;
		Object[] objects = FindObjectsOfType(typeof(Pausable));
		foreach (var go in objects) {
			((Pausable) go).onPause();
		}
		tbox.doMessage("The quick brown fox jumps over the lazy dog.");
	}

	void destroyTextBoxAndResume() {
		DescriptionBoxController tbox = (DescriptionBoxController) textBox;
		Object[] objects = FindObjectsOfType(typeof(Pausable));
		foreach (var go in objects) {
			((Pausable) go).onResume();
		}
		
		tbox.isDoneAnimating = false;
		tbox.isAnimating = false;
		tbox.Hide();
	}
	*/

	void GetKeys() {
		DescriptionBoxController tbox = (DescriptionBoxController) textBox;
		if (Input.GetKeyDown ("escape")) {
			if(tbox.isDoneAnimating || tbox.isAnimating) {
				tbox.destroyTextBoxAndResume();
			} else {
			
				Color black = new Color(0, 0, 0, 1);
				tbox.showTextBoxAndPause("PAUSED", black);
			}
		}
		if (Input.GetKeyDown ("return")) {
			tbox.destroyTextBoxAndResume();
		}
	}

	void UpdateAnimations()
	{
		Animator animate = GetComponent<Animator> ();
		
		Vector3 curpos = transform.position;
		
		if (curpos != lastPos) {
			animate.SetBool ("isMoving", true);
		} else {
			animate.SetBool ("isMoving", false);
		}
		lastPos = curpos;
		
		if(!animate.GetCurrentAnimatorStateInfo(0).IsName ("SwingSword"))
		{
			animate.SetBool ("shouldSwing", false);
			swinging = false;
		}
		float doSwingSword = Input.GetAxisRaw ("Fire1");
		if (doSwingSword != 0.0f) {
			if(swinging != true)
			{
				AudioSource source = GetComponent<AudioSource>();
				source.PlayOneShot(swingSound);
				swinging = true; 
				animate.SetBool ("shouldSwing", true);
			}
		} 
		
		
	}
	

	void UpdateCamera()
	{
		var pos = Camera.main.WorldToScreenPoint(transform.position);
		var dir = Input.mousePosition - pos;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
	}



}
