

	var  node1:Transform;
	var  minionPrefab:GameObject;
	var  spawn:boolean=true;
	var  did:boolean = false;
	var  sec:int;
	var time:String;
	var  gm:GameObject;


	
	// Update is called once per frame
	function Update () {
		sec= gm.GetComponent("gametime").intsec;
		time= gm.GetComponent("gametime").time;
		if (time=="0:45") {
		    if (!did) {
			spawnMinion ();
			did = true;
		    }
		}
	}


		
	function spawnMinion() {
		var i = 0;
		do {
			yield WaitForSeconds (1.5f);
			i++;
			Instantiate (minionPrefab, node1.position, Quaternion.identity);
		} while(i < 7);

		yield WaitForSeconds (30);
		did=false;
	}



