using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RamAT : ActionTask {

		public BBParameter<GameObject> player;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			agent.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            agent.transform.LookAt(player.value.transform);
            agent.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 1000));
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            
            if (agent.GetComponent<Fish>().playerCollision)
			{
				player.value.GetComponent<Rigidbody>().AddRelativeForce((agent.GetComponent<Rigidbody>().linearVelocity).normalized * 1000);
				EndAction(true);
			}
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {

        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}