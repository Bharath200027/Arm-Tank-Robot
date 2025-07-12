using UnityEngine;
using System.Collections;

public class TurnLeftRight : BEInstruction
{
	// Use this for Functions
	public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        float currentRotation;
        currentRotation = targetObject.transform.rotation.y;
        switch (beBlock.BeInputs.stringValues[0])
        {
            case "Left":
                if (targetObject.GetComponent<Rigidbody>())
                {
                    currentRotation -= beBlock.BeInputs.numberValues[1];
                    targetObject.transform.Rotate(0, currentRotation, 0);
                }
                break;
            case "Right":
                if (targetObject.GetComponent<Rigidbody>())
                {
                    currentRotation += beBlock.BeInputs.numberValues[1];
                    targetObject.transform.Rotate(0, currentRotation, 0);
                }
                break;
        }
        BeController.PlayNextOutside(beBlock);
	}
 
}
