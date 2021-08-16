#pragma once
#include "BaseObject.h"
using namespace std;
class StaticObject : public BaseObject {
public:
	StaticObject(int ID, string Name, Position Position);
	void move() ;
};