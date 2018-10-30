
var target : GameObject; 
var mytarget : GameObject;
var bh: GameObject;
var myTransform : Transform; 
var controller : CharacterController; 
var viewRange : int=10;
var attackRange : int=2;
var moveSpeed = 1; 
var health : int;
var damage=100;
var maxdistance : int = 1000; // dummy large distance
var nav : NavMeshAgent;
var canmove : boolean;
var anim : Animation;


function Awake() {
    myTransform = transform; 
}

function Start() {
    health = 500;
    target = GameObject.FindWithTag("node2");  
    anim=this.GetComponent(Animation);
    canmove=true;
}

function Update () {



    var opposingMinion = GameObject.FindGameObjectsWithTag("RedTeamTriggerTag"); 

    for (var enemy : GameObject in opposingMinion) {
         var distance = Vector3.Distance(enemy.transform.position, transform.position);
         if ((distance < maxdistance) && (Vector3.Distance(transform.position,enemy.transform.position)<=attackRange))
              mytarget = enemy;  
    }
          


   
   	    if(canmove == true) {
        	if(nav.destination != target.transform.position)
       	 	nav.destination =  target.transform.position;
        	anim.CrossFade("Barbuo - Run");
        } 
        else {
       		 nav.destination=this.transform.position;
       		 nav.nextPosition=this.transform.position;
        }



    if(mytarget) {
    if((Vector3.Distance(transform.position,mytarget.transform.position)<=attackRange) && mytarget) {
    transform.LookAt(mytarget.transform.position);
    canmove=false;
    }
    //DestroyObject(mytarget);   //bech nraj3oha mba3d   
   
   else {
   canmove=true;
   }
   }
}




