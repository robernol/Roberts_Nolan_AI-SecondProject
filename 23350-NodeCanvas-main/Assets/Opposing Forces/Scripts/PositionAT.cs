using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PositionAT : ActionTask {

		public BBParameter<Transform> player;
		public BBParameter<float> speed, ramTimer;
		public BBParameter<Pearl> pearl;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			
		}

		protected override void OnUpdate() {
			if (pearl.value.GetState() == 1) //if the pearl has been taken, fish no longer has a cooldown on dashes
			{
				ramTimer.value = 0;
			}
			else
			{
				ramTimer.value = 1; //reinstates the cooldown otherwise
			}
			agent.transform.LookAt(player.value.transform); //stares the player down
			if (!agent.GetComponent<Fish>().ramRange)
			{
                agent.transform.position += agent.transform.forward * Time.deltaTime * speed.value; //moves into position if too far away
            }
			else
			{
                EndAction(true); //if it in position, ends
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}