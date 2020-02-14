#pragma once
#include <vector>
using namespace std;
	
	class Bullet
	{
		Bullet();
		Bullet(vector<float>Position, vector<float>Velocity, vector<float>Acceleration);
		~Bullet();
		
		vector<float> position;
		vector<float> velocity; 
		vector<float> acceleration;
	};

