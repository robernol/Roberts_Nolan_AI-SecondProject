using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GetPearlAT : ActionTask {

		public BBParameter<GameObject> pearl;
		public BBParameter<float> speed;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            agent.transform.LookAt(pearl.value.transform);
			agent.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed.value * 100);

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			agent.transform.LookAt(pearl.value.transform);
			if (agent.GetComponent<Rigidbody>().linearVelocity.magnitude < 0.67f)
			{
                agent.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed.value * 100);
            }
			if (Vector3.Distance(agent.transform.position, pearl.value.transform.position) <= 3)
			{
				pearl.value.GetComponent<Pearl>().SetState(2);
                EndAction(true);
            }
			else if (pearl.value.GetComponent<Pearl>().GetState() == 1)
			{
				EndAction(false);
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