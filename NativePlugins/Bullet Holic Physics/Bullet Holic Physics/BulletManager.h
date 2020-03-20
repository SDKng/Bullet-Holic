#pragma once
#include <vector>
#include "Bullet.h"

using namespace std;

class BulletManager
{
public:
	
	vector<Bullet> Bullets;
	BulletManager();
	~BulletManager();

	Bullet NULLBULLET;
	Bullet FindBullet(int id);
	void AddBullet(Bullet BulletToAdd);
	bool RemoveBullet(int BulletToRemove, bool isId);

	void UpdateBullets();

};

