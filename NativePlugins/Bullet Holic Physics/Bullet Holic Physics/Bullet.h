#pragma once
#include "Vector2.h"
using namespace std;


	class Bullet
	{
	public:
		Bullet();

		Bullet(int ID);

		Bullet(Vector2 Position, Vector2 Velocity, Vector2 Acceleration, int Id) ;

		Bullet(Vector2 Position, Vector2 Velocity, Vector2 Acceleration, 
			Vector2 Angle, Vector2 AngularVelocity, Vector2 AngularAcceleration, int Id);

		Bullet(Vector2 Position, Vector2 Velocity, Vector2 Acceleration,
			Vector2 Angle, Vector2 AngularVelocity, Vector2 AngularAcceleration, 
			Vector2 Scale, Vector2 ScaleVelocity, Vector2 ScaleAcceleration, int Id);
		
		~Bullet();

	

		//Controls Position
		Vector2 position;
		Vector2 velocity;
		Vector2 acceleration;

		//Controls Rotation 
		Vector2 angle;
		Vector2 angularVelocity;
		Vector2 angularAcceleration;

		//Controls Scale
		Vector2 scale;
		Vector2 ScaleVelocity;
		Vector2 ScaleAcceleration;

		

		//For unity to identify it's bullets
	public: int id;

		int ReturnId() {

			return id;
		}

	public: 
		Bullet ReturnBullet();

	};
