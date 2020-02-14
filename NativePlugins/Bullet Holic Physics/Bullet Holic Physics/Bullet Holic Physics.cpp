// Bullet Holic Physics.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "Bullet Holic Physics.h"

#define FOOPLUGINFUNCTION_API __declspec(dllexport)

extern "C" {
	FOOPLUGINFUNCTION_API float FooPluginFunction() { return 5.0F; }


	void Update() {


	}
}


