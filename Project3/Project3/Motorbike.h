#pragma once
#include "DynamicObject.h"
using namespace std;
class Motorbike : public DynamicObject {
public:
	Motorbike(int ID, string Name, Position Position);
	void move();
};
