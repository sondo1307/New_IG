#pragma once
#include "DynamicObject.h"
using namespace std;
class Car : public DynamicObject {
public:
	Car(int ID, string Name, Position Position);
	void move();
};