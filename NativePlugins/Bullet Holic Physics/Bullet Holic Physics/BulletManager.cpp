#include "pch.h"
#include "BulletManager.h"
#include "Bullet.h"
#include <vector>


BulletManager::BulletManager() {

	vector <Bullet> Bullets;
	
	NULLBULLET = Bullet();
	Bullets.push_back(NULLBULLET);
}
BulletManager::~BulletManager() {}

void BulletManager::AddBullet(Bullet BulletToAdd) {

	
	Bullets.push_back(BulletToAdd);
}
bool BulletManager::RemoveBullet(int IndexOrID, bool isId) {

	if (!isId) Bullets.erase(Bullets.begin() + IndexOrID);

	else {

		for (int i = 0; i < Bullets.size(); i++) {

			if (FindBullet(i).id == IndexOrID) {

				int tempIndex = i;
				Bullets.erase(Bullets.begin() + tempIndex);
				return true;
			}
		}

	}
	return false;
}

Bullet BulletManager::FindBullet(int id) {

	
	for (int currBullet = 0; currBullet < Bullets.size(); currBullet++) {

		if (Bullets.at(currBullet).id == id) {

			return Bullets.at(currBullet);
		}
	}
	return NULLBULLET.ReturnBullet();
}

void BulletManager::UpdateBullets() {

	
	// Create an iterator and then cycle through the bullets, updating them. 
	
	for (int currBullet = 0; currBullet < Bullets.size(); currBullet++) {

		Bullets.at(currBullet).velocity = Bullets.at(currBullet).velocity.AddVector(Bullets.at(currBullet).acceleration);
		Bullets.at(currBullet).angularVelocity = Bullets.at(currBullet).angularVelocity.AddVector(Bullets.at(currBullet).angularAcceleration);
		Bullets.at(currBullet).ScaleVelocity = Bullets.at(currBullet).ScaleVelocity.AddVector(Bullets.at(currBullet).ScaleAcceleration);

		Bullets.at(currBullet).position = Bullets.at(currBullet).position.AddVector(Bullets.at(currBullet).velocity);
		Bullets.at(currBullet).angle = Bullets.at(currBullet).angle.AddVector(Bullets.at(currBullet).angularVelocity);
		Bullets.at(currBullet).scale = Bullets.at(currBullet).scale.AddVector(Bullets.at(currBullet).ScaleVelocity);
	}
}

