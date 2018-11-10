using UnityEngine;
using UnityEngine.UI;
using LEAlpha;

public class LifePointsHandler : MonoBehaviour {

	public PlayerMovement playerMovement;
	public Text lifeText;
	
	// Update is called once per frame
	void Update () {
        //lifeText.text = "Life: " + playerMovement.lifePoints;
        lifeText.text = "HP: " + Lib.HP.ToString();
	}
}
