#pragma once
class Vector2
{
public:
	float x, y;
	
	Vector2();
	~Vector2();

	Vector2(float X, float Y) {}

	//Adding Vectors together
	Vector2 AddVector(Vector2 AddThisVector) {}
	Vector2 AddVector(Vector2 FirstVector, Vector2 SecondVector) {}

	Vector2 SubtractVector(Vector2 SubtractThisVector) {}
	Vector2 SubtractVector(Vector2 FirstVector, Vector2 SecondVector) {}

	float Magnitude(Vector2 FindMagtitude) {}




};

