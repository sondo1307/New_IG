#pragma once
#include "BaseObject.h"
using namespace std;
class DynamicObject : public BaseObject {
public:
	DynamicObject(int ID, string Name, Position Position);
	void move();
};