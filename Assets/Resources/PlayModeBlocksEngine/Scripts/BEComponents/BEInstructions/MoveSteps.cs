using UnityEngine;
using System.Collections;

public class MoveSteps : BEInstruction
{
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		switch (beBlock.BeInputs.stringValues[1])
		{
			case "Forward":

				if (targetObject.GetComponent<Collider>())
				{
					targetObject.transform.position += targetObject.transform.forward * beBlock.BeInputs.numberValues[0];
				}
				break;
			case "Backward":

				if (targetObject.GetComponent<Collider>())
				{
					targetObject.transform.position += targetObject.transform.forward * beBlock.BeInputs.numberValues[0] * -1;
				}
				break;
			case "Left":

				if (targetObject.GetComponent<Collider>())
				{
					targetObject.transform.position += targetObject.transform.right * beBlock.BeInputs.numberValues[0] * -1;
				}
				break;
			case "Right":

				if (targetObject.GetComponent<Collider>())
				{
					targetObject.transform.position += targetObject.transform.right * beBlock.BeInputs.numberValues[0];
				}
				break;
		}
		BeController.PlayNextOutside(beBlock);
	}
 
}
