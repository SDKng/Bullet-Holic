#include "pch.h"
#include "Bullet.h"

Bullet::Bullet() {}

Bullet::Bullet(vector<float>Position, vector<float>Velocity, vector<float>Acceleration) {

	position = Position;
	velocity = Velocity;
	acceleration = Acceleration;
}

Bullet::~Bullet() {}

