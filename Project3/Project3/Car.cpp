#include "Car.h"
#include <iostream>

using namespace std;

Car::Car(int ID, string Name, Position Position) : DynamicObject(ID, Name, Position)
{
}

void Car::move()
{
	position.posX += 10;
	position.posY += 10;
}
