#include "pch.h"
#include "Vector2.h"
#include <math.h>

//Base constructor and with params
Vector2::Vector2() {}

Vector2::Vector2(float X, float Y){

	x = X;
	y = Y;
}

//Add Vectors
Vector2 Vector2::AddVector(Vector2 AddThisVector) {

	float newX = this->x + AddThisVector.x;
	float newY = this->y + AddThisVector.y;
	
	return Vector2(newX, newY);
}
Vector2 Vector2::AddVector(Vector2 FirstVector, Vector2 SecondVector) {

	float newX = FirstVector.x + SecondVector.x;
	float newY = FirstVector.y + SecondVector.y;

	return Vector2(newX, newY);
}

//Subtract Vectors
Vector2 Vector2::SubtractVector(Vector2 SubtractThisVector) {

	float newX = this->x - SubtractThisVector.x;
	float newY = this->y - SubtractThisVector.y;

		return Vector2(newX, newY);
}
Vector2 Vector2::SubtractVector(Vector2 FirstVector, Vector2 SecondVector) {

	float newX = FirstVector.x - SecondVector.x;
	float newY = FirstVector.y - SecondVector.y;

		return Vector2(newX, newY);
}

float Vector2::Magnitude(Vector2 FindMagnitude) {

	return sqrtf((FindMagnitude.x * FindMagnitude.x) + (FindMagnitude.y * FindMagnitude.y));
}






