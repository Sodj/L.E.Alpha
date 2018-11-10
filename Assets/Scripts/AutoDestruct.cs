using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifetime);// destroy object (ghostFormation) after [lifetime] seconds
	}
}
