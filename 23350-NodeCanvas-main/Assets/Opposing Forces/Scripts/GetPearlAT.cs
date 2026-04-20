using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GetPearlAT : ActionTask {

		public BBParameter<GameObject> pearl;
		public BBParameter<float> speed;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
            agent.transform.LookAt(pearl.value.transform); //looks at the pearl and launches towards it
			agent.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed.value * 100);

        }

		protected override void OnUpdate() {
			agent.transform.LookAt(pearl.value.transform);
			if (agent.GetComponent<Rigidbody>().linearVelocity.magnitude < 0.67f) //if fish slows down too much, launches again
			{
                agent.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed.value * 100);
            }
			if (Vector3.Distance(agent.transform.position, pearl.value.transform.position) <= 3) //if it gets to the pearl, sets the pearl to the fish state and picks it up
			{
				pearl.value.GetComponent<Pearl>().SetState(2);
                EndAction(true);
            }
			else if (pearl.value.GetComponent<Pearl>().GetState() == 1) //if player picks it up before the fish, goes back to chasing
			{
				EndAction(false);
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}