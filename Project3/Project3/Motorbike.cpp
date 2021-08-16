#include "Motorbike.h"
#include <iostream>
using namespace std;
Motorbike::Motorbike(int ID, string Name, Position Position) : DynamicObject(ID, Name, Position)
{
}

void Motorbike::move()
{
	position.posX += 10;
	position.posY += 10;
}
