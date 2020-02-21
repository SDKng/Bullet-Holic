// Bullet Holic Physics.cpp : Defines the exported functions for the DLL.
//
#include "Vector2.h"
#include "pch.h"
#include "framework.h"
#include "Bullet Holic Physics.h"

#define FOOPLUGINFUNCTION_API __declspec(dllexport)
#define JACOBPLUGINFUNCTION_API __declspec(dllexport)

extern "C" {
	__declspec(dllexport) float FooPluginFunction(float X) {  }

	FOOPLUGINFUNCTION_API  float FooPluginFinction() {

		
		return 5.0F; 
		
	}


	void Update() {

		//Reset anything that needs reseting
		
		//Update Bullet/ Wall Colisions/ Physics Updates
		//Friendly
		//Enemy

		
			

		// 
	}
}


