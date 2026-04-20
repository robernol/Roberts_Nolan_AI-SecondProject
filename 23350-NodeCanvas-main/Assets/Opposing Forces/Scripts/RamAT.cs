using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RamAT : ActionTask {

		public BBParameter<GameObject> player;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			agent.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; //resets velocity
            agent.transform.LookAt(player.value.transform);
            agent.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 1000)); //looks at player and launches towards them
        }

		protected override void OnUpdate() {
            
            if (agent.GetComponent<Fish>().playerCollision) //if fish collides with player, adds a force to player to knock them back
			{
				player.value.GetComponent<Rigidbody>().AddRelativeForce((agent.GetComponent<Rigidbody>().linearVelocity).normalized * 1000);
				EndAction(true);
			}
			
		}

		protected override void OnStop() {

        }

		protected override void OnPause() {
			
		}
	}
}