// Bullet Holic Physics.cpp : Defines the exported functions for the DLL.
//
#include "Vector2.h"
#include "pch.h"
#include "framework.h"
#include "Bullet Holic Physics.h"
#include "BulletManager.h"

#define PLUGINFUNCTION __declspec(dllexport)


extern "C" {

	BulletManager friendlyBullets = BulletManager();
	BulletManager enemyBullets = BulletManager();
	float number = 11.0f;
	PLUGINFUNCTION float FooPluginFunction(float X) { return X + 1.0f; }
	//FOOPLUGINFUNCTION_API  float FooPluginFinction(float X) {


	//	return X;

	//}
	//__declspec(dllexport) int IterateANumber(int iterateThis) {  }
	PLUGINFUNCTION int IterateANumber() {

		int i = 6;
		return i;
	}

	//function where we create the lists of bullets
	PLUGINFUNCTION float InitializeBullets() {
	
	

		return 1.0f;
	
	}

	PLUGINFUNCTION void CreateBullet(float PosX, float PosY, float VelX, float VelY, float AccX, float AccY, int ID, int Alignment) {

		if (Alignment == 0) friendlyBullets.AddBullet(Bullet(Vector2(PosX, PosY), Vector2(VelX, VelY), Vector2(AccX, AccY), ID));
		else if (Alignment == 1) enemyBullets.AddBullet(Bullet(Vector2(PosX, PosY), Vector2(VelX, VelY), Vector2(AccX, AccY), ID));
	}


	PLUGINFUNCTION void UpdatePhysics() {

		friendlyBullets.UpdateBullets();
		enemyBullets.UpdateBullets();
		
	}

	PLUGINFUNCTION float ReturnData(int ID, int DataIndex) {

		Bullet temp;
		
		if (friendlyBullets.FindBullet(ID).id != 0) {

			temp = friendlyBullets.FindBullet(ID);
			
		}
		else if (enemyBullets.FindBullet(ID).id != 0) {

			temp = enemyBullets.FindBullet(ID);

		}
		else { return 0.0f; }
		
		if (DataIndex == 1) return temp.position.x;
		else if (DataIndex == 2) return temp.position.y;
			
		else if (DataIndex == 3) return temp.angle.x;
		else if (DataIndex == 4) return temp.angle.y;
		
		else if (DataIndex == 5) return temp.scale.x;
		else if (DataIndex == 6) return temp.scale.y;
		else { return 0.0f; }
	}

	PLUGINFUNCTION void RemoveBullet(int ID) {

	if (friendlyBullets.RemoveBullet(ID, true) == false) {
		
		enemyBullets.RemoveBullet(ID, true);
	}
		
			
	}
		
}

	




	
//	void Start() {
//
//	}
//
//	void Update() {
//
//		
//		
//		//Reset anything that needs reseting
//
//
//		
//		//Update Bullet/ Wall Colisions/ Physics Updates
//
//		
//		//Friendly
//		//Enemy
//
//		
//			
//
//		// 
//	}
//}


