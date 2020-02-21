#include "pch.h"
#include "Bullet.h"



#define FOOPLUGINFUNCTION_API __declspec(dllexport)

	Bullet::Bullet() {}

	Bullet::Bullet(Vector2 Position, Vector2 Velocity, Vector2 Acceleration) {

		position = Position;
		velocity = Velocity;
		acceleration = Acceleration;


	}

	extern "C" {

		FOOPLUGINFUNCTION_API  float returnPositionX() {

			return ;
		}
	}