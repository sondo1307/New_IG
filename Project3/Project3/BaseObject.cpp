#include "BaseObject.h"
#include <iostream>
#include "Position.h"

using namespace std;

BaseObject::BaseObject()
{
}

BaseObject::BaseObject(int ID, string Name, Position Position)
{
	id = ID;
	name = Name;
	position = Position;
}

BaseObject::~BaseObject()
{

}

int BaseObject::getid()
{
	return id;
}

string BaseObject::getName()
{
	return name;
}

void BaseObject::move()
{
}

void BaseObject::printPosition()
{
	cout << "Position x:" << position.posX << endl;
	cout << "Position y:" << position.posY << endl;
}
