using UnityEngine;
using System.Collections;

public class MoveUpDown : BEInstruction
{
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
	{
		switch (beBlock.BeInputs.stringValues[1])
		{
			case "Up":

				if (targetObject.GetComponent<Collider>())
				{
					targetObject.transform.position += targetObject.transform.up * beBlock.BeInputs.numberValues[0];
				}
				break;
			case "Down":

				if (targetObject.GetComponent<Collider>())
				{
					targetObject.transform.position += targetObject.transform.up * beBlock.BeInputs.numberValues[0] * -1;
				}
				break;
		}
		BeController.PlayNextOutside(beBlock);
	}
 
}
