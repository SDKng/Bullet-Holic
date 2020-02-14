#pragma once
#include "Bullet.h"

class Bodies
{

	Bodies();
	~Bodies();
	
	void AddWalls();
	void AddEnemies();
	void UpdatePositions();

	vector<Bullet>Bullets;
	//vector<Hitbox>EnemyHitboxes;
	//vector<Enemy>Enemies;
	//vector<Walls>Wall;

};

