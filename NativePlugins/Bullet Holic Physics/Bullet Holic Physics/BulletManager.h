#pragma once
#include <list>
#include "Bullet.h"

using namespace std;

class BulletManager
{
public:
	
	list<Bullet> Bullets;
	BulletManager() {}
	~BulletManager() {}

	void AddBullet(Bullet BulletToAdd, int Id) {}
	void RemoveBullet(Bullet BulletToRemove) {}
	void UpdateBullets() {}

};

