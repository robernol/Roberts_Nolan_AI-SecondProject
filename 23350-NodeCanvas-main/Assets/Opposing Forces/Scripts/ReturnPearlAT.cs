using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ReturnPearlAT : ActionTask {

		public BBParameter<GameObject> clam, pearl;
		public BBParameter<float> speed;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() { //on execute, looks towards the clam and launches towards it
            agent.transform.LookAt(clam.value.transform);
            agent.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed.value * 100);
        }

		protected override void OnUpdate() {
            agent.transform.LookAt(clam.value.transform);
            if (agent.GetComponent<Rigidbody>().linearVelocity.magnitude < 0.67f) //if fish gets too slow, gets launched towards clam again
            {
                agent.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed.value * 100);
            }
            if (Vector3.Distance(agent.transform.position, clam.value.transform.position) <= 10) //if it gets close enough to the clam, transfers the pearl back to clam
            {
                pearl.value.GetComponent<Pearl>().SetState(0); //sets pearl back to the clam state
                EndAction(true);
            }
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}