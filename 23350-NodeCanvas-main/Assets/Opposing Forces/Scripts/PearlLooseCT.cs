using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class PearlLooseCT : ConditionTask {

		public BBParameter<Pearl> pearl;

		protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck()
		{
			if (pearl.value.GetState() == 3) {  //returns true if the pearl is "loose" (not in the clam, but not being held by anything either)
                return true; 
			}
			return false;
		}
	}
}