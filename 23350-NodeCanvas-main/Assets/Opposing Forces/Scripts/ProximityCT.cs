using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ProximityCT : ConditionTask {

		public BBParameter<Transform> player;
		public BBParameter<float> proximity;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			float dist = ((agent.transform.position) - (player.value.position)).magnitude; //if distance is less than the proximity value, returns true
            if (dist < proximity.value)
			{
				return true;
            }
            return false;
		}
	}
}