using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class IdleAT : ActionTask {

		public float duration; 
		public BBParameter<float> speed;
		float timer;
        Vector3 direction;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timer = Time.time + duration;
			SetCourse();
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (Time.time >= timer)
			{
                timer = Time.time + duration;
				SetCourse();
				agent.GetComponent<Rigidbody>().AddForce(direction * speed.value * 100);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		void SetCourse()
		{
			direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.2f, 0.2f), Random.Range(-1f, 1f)).normalized;
			agent.transform.LookAt(agent.transform.position + direction);
        }

	}
}