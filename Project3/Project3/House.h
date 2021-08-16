#pragma once
#include "StaticObject.h"

using namespace std;

class House : public StaticObject {
public:
	House(int ID, string Name, Position Position);
};
