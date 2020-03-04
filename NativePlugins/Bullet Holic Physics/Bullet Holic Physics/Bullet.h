#pragma once
#include "Vector2.h"
using namespace std;


	class Bullet
	{
		Bullet();
		Bullet(Vector2 Position, Vector2 Velocity, Vector2 Acceleration, int Id);
		~Bullet();


		Vector2 position;
		Vector2 velocity;
		Vector2 acceleration;

		int id;

		int ReturnId() {

			return id;
		}
	};
