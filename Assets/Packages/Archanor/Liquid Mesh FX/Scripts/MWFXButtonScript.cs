﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace MeshWaterFX
{

public class MWFXButtonScript : MonoBehaviour
{
	public GameObject Button;
	Text MyButtonText;
	string projectileParticleName;		// The variable to update the text component of the button

	MWFXFireProjectile effectScript;		// A variable used to access the list of projectiles
	MWFXProjectileScript projectileScript;

	public float buttonsX;
	public float buttonsY;
	public float buttonsSizeX;
	public float buttonsSizeY;
	public float buttonsDistance;
	
	void Start ()
	{
		effectScript = GameObject.Find("MWFXFireProjectile").GetComponent<MWFXFireProjectile>();
		getProjectileNames();
		MyButtonText = Button.transform.FindChild("Text").GetComponent<Text>();
		MyButtonText.text = projectileParticleName;
	}

	void Update ()
	{
		MyButtonText.text = projectileParticleName;
//		print(projectileParticleName);
	}

	public void getProjectileNames()			// Find and diplay the name of the currently selected projectile
	{
		// Access the currently selected projectile's 'ProjectileScript'
		projectileScript = effectScript.projectiles[effectScript.currentProjectile].GetComponent<MWFXProjectileScript>();
		projectileParticleName = projectileScript.projectileParticle.name;	// Assign the name of the currently selected projectile to projectileParticleName
	}

	public bool overButton()		// This function will return either true or false
	{
		Rect button1 = new Rect(buttonsX, buttonsY, buttonsSizeX, buttonsSizeY);
		Rect button2 = new Rect(buttonsX + buttonsDistance, buttonsY, buttonsSizeX, buttonsSizeY);
		
		if(button1.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)) ||
		   button2.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
		{
			return true;
		}
		else
			return false;
	}
}
}