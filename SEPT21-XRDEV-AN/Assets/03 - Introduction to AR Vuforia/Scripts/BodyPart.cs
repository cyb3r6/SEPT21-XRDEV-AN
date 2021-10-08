using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script has the public methods for the organ buttons
/// so when the button is clicked it changes the color to
/// white
/// </summary>
public class BodyPart : MonoBehaviour
{
	public Image brainIcon;
	public Image leftLungIcon;
	public Image rightLungIcon;
	public Image heartIcon;
	public Image stomachIcon;
	public Image bladderIcon;
	public Image leftKidneyIcon;
	public Image rightKidneyIcon;

	public void OnBrainFound()
	{
		brainIcon.color = new Color(1, 1, 1, 1);
	}

	public void OnLeftLungFound()
	{
		leftLungIcon.color = new Color(1, 1, 1, 1);
	}

	public void OnRightLungFound()
	{
		rightLungIcon.color = new Color(1, 1, 1, 1);
	}

	public void OnHeartFound()
	{
		heartIcon.color = new Color(1, 1, 1, 1);
	}

	public void OnStomachFound()
	{
		stomachIcon.color = new Color(1, 1, 1, 1);
	}

	public void OnBladderFound()
	{
		bladderIcon.color = new Color(1, 1, 1, 1);
	}

	public void OnLeftKidneyFound()
	{
		leftKidneyIcon.color = new Color(1, 1, 1, 1);
	}

	public void OnRightKidneyFound()
	{
		rightKidneyIcon.color = new Color(1, 1, 1, 1);
	}

}
