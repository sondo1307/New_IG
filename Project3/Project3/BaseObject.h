#pragma once
#include <string>
#include "Position.h"

using namespace std;
class BaseObject {
private:
	int id;
	string name;
protected:
	Position position;
public:
	BaseObject();
	BaseObject(int ID, string Name, Position Position);
	~BaseObject();
	virtual string getName();
	virtual int getid();
	virtual void move();
	virtual void printPosition();
};
