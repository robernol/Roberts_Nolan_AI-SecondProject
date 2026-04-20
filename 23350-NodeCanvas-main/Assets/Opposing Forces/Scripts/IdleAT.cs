using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class IdleAT : ActionTask {

		public float duration; 
		public BBParameter<float> speed;
		float timer;
        Vector3 direction;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			timer = Time.time + duration; //sets timer and course
			SetCourse();
        }

		protected override void OnUpdate() {
			if (Time.time >= timer)
			{
                timer = Time.time + duration; //every set interval launches the fish in the direction its facing to make him "swim" idly
				SetCourse();
				agent.GetComponent<Rigidbody>().AddForce(direction * speed.value * 100);
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}

		void SetCourse()
		{
			direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.2f, 0.2f), Random.Range(-1f, 1f)).normalized; //chooses a random direction to face
			agent.transform.LookAt(agent.transform.position + direction);
        }

	}
}