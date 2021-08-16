#include "StaticObject.h"
#include <iostream>
using namespace std;
StaticObject::StaticObject(int ID, string Name, Position Position) : BaseObject(ID, Name, Position)
{
}
void StaticObject::move()
{
	//cout << "Static object can't move" << endl;
}
