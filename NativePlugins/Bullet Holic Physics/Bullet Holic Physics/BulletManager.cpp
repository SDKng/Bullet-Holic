#include "pch.h"
#include "BulletManager.h"


BulletManager::BulletManager() {

	
}
BulletManager::~BulletManager() {}

void BulletManager::AddBullet(Bullet BulletToAdd, int Id) {

	
	Bullets.push_back(BulletToAdd);
}
void RemoveBullet(Bullet BulletToRemove) {}
void UpdateBullets() {}

 