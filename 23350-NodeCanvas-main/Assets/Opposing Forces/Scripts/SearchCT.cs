using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class SearchCT : ConditionTask {

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
			if (agent.GetComponent<Fish>().tracking) //if the fish enters the vicinity of the DetectVolume sphere, the tracking variable in the fish script will become true.
			{
				return true;
            }
			return false;
        }
	}
}