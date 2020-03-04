#include "pch.h"
#include "Bullet.h"





	Bullet::Bullet() {}

	Bullet::Bullet(Vector2 Position, Vector2 Velocity, Vector2 Acceleration, int Id) {

		position = Position;
		velocity = Velocity;
		acceleration = Acceleration;
		id = Id;


	}

